using System.Linq.Expressions;
using Notification.Notifications.Context;
using Notification.Notifications.Enum;
using Notification.Notifications.Helpers;
using Notification.Notifications.Notifiable.Notifications.Base;

namespace Notification.Notifications.Services;

public class ResultService
{
    public ResultService(NotificationContext notification)
    {
        NotificationContext = notification;
    }

    private NotificationContext NotificationContext { get; set; }

    public void Failure<T>(FailureModel failure)
        where T : INotifiable
    {
        var notificationType = NotificationType.BusinessNotification;
        if (typeof(T).GetInterfaces().ToList().Exists(x => x.Name == nameof(INotifiableModel)))
        {
            notificationType = NotificationType.DomainNotification;
        }

        var notificationInfo = new NotificationInfo(new PropInfo(), new EntityInfo()
        {
            NotificationType = notificationType,
            Name = typeof(T).Name,
            Namespace = typeof(T).Namespace
        });

        NotificationContext.AddNotification(new NotificationModel(failure, notificationInfo));
    }

    public void Failure<T>(Expression<Func<T, dynamic>> exp, FailureModel failure)
        where T : INotifiableModel
    {
        var notificationType = NotificationType.BusinessNotification;
        if (typeof(T).GetInterfaces().ToList().Exists(x => x.Name == nameof(INotifiableModel)))
        {
            notificationType = NotificationType.DomainNotification;
        }

        var notificationInfo = new NotificationInfo(
            new PropInfo()
            {
                Value = null,
                MemberName = ResultServiceHelpers.TranslateLambda(exp)
            },
            new EntityInfo()
            {
                NotificationType = notificationType,
                Name = typeof(T).Name,
                Namespace = typeof(T).Namespace
            });

        NotificationContext.AddNotification(new NotificationModel(failure, notificationInfo));
    }
}
