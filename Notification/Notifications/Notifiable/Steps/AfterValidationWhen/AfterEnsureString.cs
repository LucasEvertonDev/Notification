using Notification.Notifications.Notifiable.Notifications.Base;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterEnsure<TEntity> where TEntity : INotifiableModel
{
    private NotificationInfo _notificationInfo;

    public AfterEnsure(NotificationInfo notificationInfo)
    {
        this._notificationInfo = notificationInfo;
    }

    public void ForContext() { }

}