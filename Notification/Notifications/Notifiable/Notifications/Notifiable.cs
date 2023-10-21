using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;

namespace Notification.Notifications.Notifiable.Notifications;

public partial class Notifiable : INotifiable
{
    /// <summary>
    /// Notification Context
    /// </summary>
    protected NotificationContext Notifications { get; set; }

    protected NotificationInfo NotificationInfo { get; set; }

    /// <summary>
    /// Set Notification Context
    /// </summary>
    /// <param name="context"></param>
    public void SetNotificationContext(NotificationContext context) => Notifications = context;

    /// <summary>
    /// Indica se o dominio é válido ou não
    /// </summary>
    /// <returns></returns>
    public bool HasFailure()
    {
        return Notifications.HasNotifications;
    }
}