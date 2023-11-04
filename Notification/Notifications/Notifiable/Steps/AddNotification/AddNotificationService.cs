using Notification.Notifications.Context;

namespace Notification.Notifications.Notifiable.Steps.AddNotification;

public static class AddNotificationService
{
    public static TOut AddFailure<TOut>(TOut current, NotificationContext notificationContext, bool includeNotification, NotificationInfo notificationInfo, FailureModel erro)
    {
        if (includeNotification)
        {
            notificationContext.AddNotification(new NotificationModel(erro, notificationInfo));
        }

        return current;
    }
}