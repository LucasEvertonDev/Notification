using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AfterEnsure;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    protected AfterEnsureObject<TEntity> Ensure(INotifiableModel valor)
    {
        return new AfterEnsureObject<TEntity>(Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }

    protected AfterEnsureList<TEntity> Ensure<TEntityCollection>(List<TEntityCollection> valor) where TEntityCollection : INotifiableModel
    {
        return new AfterEnsureList<TEntity> (Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }
}