using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;

namespace Notification.Notifications.Notifiable.Notifications;

public partial class Notifiable : INotifiable
{
    protected NotificationContext Notifications { get; set; }

    protected NotificationInfo NotificationInfo { get; set; }

    public void SetNotificationContext(NotificationContext context) => Notifications = context;

    public bool HasFailure()
    {
        return Notifications.HasNotifications;
    }
}