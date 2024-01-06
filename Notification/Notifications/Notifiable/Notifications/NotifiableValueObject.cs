using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AfterEnsure;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    /// <summary>
    /// Tem o objetivo de garantir algumas regras para propriedades.
    /// </summary>
    /// <param name="valor">Parâmetro de valor a ser validado.</param>
    /// <returns>Retorna possibilidades de validações com objetivo de garantir somente cenários válidos.</returns>
    protected AfterEnsureObject<TEntity> Ensure(INotifiableModel valor)
    {
        return new AfterEnsureObject<TEntity>(Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }

    /// <summary>
    /// Tem o objetivo de garantir algumas regras para propriedades.
    /// </summary>
    /// <typeparam name="TEntityCollection">Indica o tipo do item da lista deve ser um objeto notificavel.</typeparam>
    /// <param name="valor">Parâmetro de valor a ser validado.</param>
    /// <returns>Retorna possibilidades de validações com objetivo de garantir somente cenários válidos.</returns>
    protected AfterEnsureList<TEntity> Ensure<TEntityCollection>(List<TEntityCollection> valor)
        where TEntityCollection : INotifiableModel
    {
        return new AfterEnsureList<TEntity>(Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }

    /// <summary>
    /// Tem o objetivo de garantir algumas regras para propriedades.
    /// </summary>
    /// <typeparam name="TEntityCollection">Indica o tipo do item da lista deve ser um objeto notificavel.</typeparam>
    /// <param name="valor">Parâmetro de valor a ser validado.</param>
    /// <returns>Retorna possibilidades de validações com objetivo de garantir somente cenários válidos.</returns>
    protected AfterEnsureList<TEntity> Ensure<TEntityCollection>(ICollection<TEntityCollection> valor)
        where TEntityCollection : INotifiableModel
    {
        return new AfterEnsureList<TEntity>(Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }
}