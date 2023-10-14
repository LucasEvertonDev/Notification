using Notification.Notifications.Enum;

namespace Notification.Notifications;

public record NotificationModel
{
    public NotificationModel(FailureModel failure, NotificationInfo notificationInfo)
    {
        this.Error = failure;
        this.NotificationInfo = notificationInfo;
    }

    public FailureModel Error { get; private set; }
    public NotificationInfo NotificationInfo { get; private set; }
} 

public record FailureModel(string key, string message)
{

}

