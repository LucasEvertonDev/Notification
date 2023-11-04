using Notification.Notifications.Context;

namespace Notification.Notifications.Notifiable.Steps.AddNotification;

/// <summary>
/// Classe Estatica para simplificar lançamento de falhas.
/// </summary>
public static class AddNotificationService
{
    /// <summary>
    /// Método para registrar falhas.
    /// </summary>
    /// <typeparam name="TOut">Indica o tipo que será retornado.</typeparam>
    /// <param name="current">Representa a inância da classe que será retornada. Para não reinstancia-la e consumir mais performance.</param>
    /// <param name="notificationContext">Indica o contexto que será salvo as notificações.</param>
    /// <param name="includeNotification">Flag que indica se será adicionada ou não a falha.</param>
    /// <param name="notificationInfo">Carrega informações para compor a notificação de falha.</param>
    /// <param name="erro">Objeto que carrega a falha em si.</param>
    /// <returns>Retorna a mesma instância da classe origem para novas validações.</returns>
    public static TOut AddFailure<TOut>(TOut current, NotificationContext notificationContext, bool includeNotification, NotificationInfo notificationInfo, FailureModel erro)
    {
        if (includeNotification)
        {
            notificationContext.AddNotification(new NotificationModel(erro, notificationInfo));
        }

        return current;
    }
}