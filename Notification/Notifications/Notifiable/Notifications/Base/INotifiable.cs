namespace Notification.Notifications.Notifiable.Notifications.Base;

public interface INotifiable
{
    bool HasFailure();
}


public interface INotifiableModel
{
    List<NotificationModel> GetNotifications();
}