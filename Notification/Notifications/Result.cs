using Notification.Extensions;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Services;
using System.Linq.Expressions;

namespace Notification.Notifications;

public class Result
{
    public Result(NotificationContext Notification)
    {
        NotificationContext = Notification;
        ResultService = new ResultService(Notification);
    }

    private ResultService ResultService { get; set; }

    private NotificationContext NotificationContext { get; set; }

    public NotificationContext GetContext() => NotificationContext;

    public bool HasFailures() => NotificationContext.HasNotifications;

    public IReadOnlyCollection<NotificationModel> GetFailures => NotificationContext.Notifications;

    public Result Failure<TContext>(FailureModel failure) where TContext : INotifiable
    {
        ResultService.Failure<TContext>(failure);
        return this;
    }

    public Result Failure<TNotifiableModel>(Expression<Func<TNotifiableModel, dynamic>> exp, FailureModel failure) where TNotifiableModel : INotifiableModel
    {
        ResultService.Failure<TNotifiableModel>(exp, failure);
        return this;
    }

    public Result Failure<TNotifiableModel>(TNotifiableModel notifiableModel) where TNotifiableModel : INotifiableModel
    {
        NotificationContext.AddNotifications(notifiableModel.GetNotifications());
        return this;
    }

    public Result Failure(List<NotificationModel> failures)
    {
        NotificationContext.AddNotifications(failures);
        return this;
    }

    public T GetContent<T>()
    {
        return (T)Content;
    }

    public Result SetContent(dynamic content)
    {
        Content = content;
        return this;
    }

    private dynamic Content { get; set; }
}
