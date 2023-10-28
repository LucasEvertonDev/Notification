using Notification.Notifications;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhen : IAfterValidationWhen
{
    protected NotificationInfo _notificationInfo { get; set; }
    protected readonly NotificationContext _notificationContext;
    protected readonly dynamic _value;

    public AfterValidationWhen(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationContext = notificationContext;
        _notificationInfo = notificationInfo;
        _value = notificationInfo.PropInfo.Value;
    }
}
