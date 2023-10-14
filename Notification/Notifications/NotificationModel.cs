using Notification.Notifications.Enum;

namespace Notification.Notifications;

public record NotificationModel
{
    public NotificationModel(FailureModel failure, NotificationInfo notificationInfo)
    {
        this.Error = failure;
        this.NotificationInfo = notificationInfo;
    }

    public FailureModel Error { get; set; }
    public NotificationInfo NotificationInfo { get; set; }
} 

public record FailureModel(string key, string message)
{

}

