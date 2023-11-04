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
    protected AfterEnsureBool<TEntity> Ensure(bool? valor)
    {
        return new AfterEnsureBool<TEntity>(Result.GetContext(), new NotificationInfo(new PropInfo() { Value = valor }, EntityInfo));
    }
}