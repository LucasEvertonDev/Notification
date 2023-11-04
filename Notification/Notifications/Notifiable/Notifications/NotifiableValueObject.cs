using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AfterEnsure;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    /// <summary>
    /// Tem o objetivo de garantir algumas regras para objetos que são notificáveis
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    protected AfterEnsureObject<TEntity> Ensure(INotifiableModel valor)
    {
        return new AfterEnsureObject<TEntity>(Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }

    /// <summary>
    /// Tem o objetivo de garantir algumas regras para listas de objetos notificaveis
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    protected AfterEnsureList<TEntity> Ensure<TEntityCollection>(List<TEntityCollection> valor) where TEntityCollection : INotifiableModel
    {
        return new AfterEnsureList<TEntity> (Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }
}