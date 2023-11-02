using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AfterEnsure;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    protected AfterEnsureDatetime<TEntity> Ensure(DateTime? valor)
    {
        return new AfterEnsureDatetime<TEntity>(Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }
}