using System.Linq.Expressions;
using Notification.Extensions;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Services;

namespace Notification.Notifications;

/// <summary>
/// Classe principal responsável pelos patterns de result e notification da aplicação.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="notification">Contexto com o que o resultado irá manipular todas as notificações.</param>
    public Result(NotificationContext notification)
    {
        NotificationContext = notification;
        ResultService = new ResultService(notification);
    }

    private dynamic Content { get; set; }

    private ResultService ResultService { get; set; }

    private NotificationContext NotificationContext { get; set; }

    /// <summary>
    /// Permite o acesso do notification context para manipulações de resultado.
    /// </summary>
    /// <returns>Realiza o retorno do contexto de notificações do resultado.</returns>
    public NotificationContext GetContext() => NotificationContext;

    /// <summary>
    /// Indica se ocorreu alguma falha.
    /// </summary>
    /// <returns>Retorna um booleano.</returns>
    public bool HasFailures() => NotificationContext.HasNotifications;

    /// <summary>
    /// Metodo responsável por recuperar todas as notifcações do resultado.
    /// </summary>
    /// <returns>Retorna uma lista de notificações.</returns>
    public IReadOnlyCollection<NotificationModel> GetFailures()
    {
        return NotificationContext.Notifications;
    }

    /// <summary>
    /// Registra uma falha esperada na execução.
    /// </summary>
    /// <typeparam name="TContext">Representa um handler, service, contexto em que ocorreu a falha.</typeparam>
    /// <param name="failure">Represnata a falha em si.</param>
    /// <returns>Retorna o próprio resultado.</returns>
    public Result Failure<TContext>(FailureModel failure)
        where TContext : INotifiable
    {
        ResultService.Failure<TContext>(failure);
        return this;
    }

    /// <summary>
    /// Registra uma falha esperada na execução.
    /// </summary>
    /// <typeparam name="TNotifiableModel">Reprensenta um domínio, value object, modelo notificável.</typeparam>
    /// <param name="exp">Reprensenta a propriedade que será associada a falha.</param>
    /// <param name="failure">Represnata a falha em si.</param>
    /// <returns>Retorna o próprio resultado.</returns>
    public Result Failure<TNotifiableModel>(Expression<Func<TNotifiableModel, dynamic>> exp, FailureModel failure)
        where TNotifiableModel : INotifiableModel
    {
        ResultService.Failure<TNotifiableModel>(exp, failure);
        return this;
    }

    /// <summary>
    /// Registra as falhas de determinada entidade.
    /// </summary>
    /// <typeparam name="TNotifiableModel">Reprensenta o tipo da entidade que irá ser associada as falhas.</typeparam>
    /// <param name="notifiableModel">Representa a instância da entidade que iremos obter as falhas.</param>
    /// <returns>Retorna o próprio resultado.</returns>
    public Result Failure<TNotifiableModel>(TNotifiableModel notifiableModel)
        where TNotifiableModel : INotifiableModel
    {
        NotificationContext.AddNotifications(notifiableModel.GetNotifications());
        return this;
    }

    /// <summary>
    /// Registra uma lista de falhas.
    /// </summary>
    /// <param name="failures">Representa a lista de falhas que será armazenada.</param>
    /// <returns>Retorna o próprio resultado.</returns>
    public Result Failure(List<NotificationModel> failures)
    {
        NotificationContext.AddNotifications(failures);
        return this;
    }

    /// <summary>
    /// Realiza a conversão tipada do conteudo do resultado.
    /// </summary>
    /// <typeparam name="T">Representa o conteudo do resultado.</typeparam>
    /// <returns>Retorna o próprio resultado.</returns>
    public T GetContent<T>()
    {
        return (T)Content;
    }

    /// <summary>
    /// Realiza o set do conteudo do resultaod.
    /// </summary>
    /// <param name="content">Representa o conteudo do resultado.</param>
    /// <returns>Retorna o próprio resultado.</returns>
    public Result Ok(dynamic content)
    {
        this.Content = content;
        return this;
    }
}