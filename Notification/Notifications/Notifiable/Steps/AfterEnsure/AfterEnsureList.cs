using System.Linq.Expressions;
using Notification.Notifications.Context;
using Notification.Notifications.Helpers;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

/// <summary>
/// Representa a etapa após ensure para propriedades list.
/// </summary>
/// <typeparam name="TEntity">Reprensenta a entidade que implementou a classe notifiable.</typeparam>
public class AfterEnsureList<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="AfterEnsureList{TEntity}"/> class.
    /// Construtor para continuar a arquiterura de steps.
    /// </summary>
    /// <param name="notificationContext">Indica o contexto em que será registrada as notificações.</param>
    /// <param name="notificationInfo">Representa as informações adicionais para compor o contexto da notificação.</param>
    public AfterEnsureList(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    /// <summary>
    /// Associa as validações a determinada propriedade da classe.
    /// Em caso de uso deve ser informado após o ensure.
    /// </summary>
    /// <typeparam name="TCollectionEntity">Reprensa o tipo para o item da lista o mesmo deve ser um objeto que é notificável.</typeparam>
    /// <param name="expression">Lambda indicando a propriedade da classe que irá receber o valor a ser validado.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureList<TEntity> ForContext<TCollectionEntity>(Expression<Func<TEntity, List<TCollectionEntity>>> expression)
        where TCollectionEntity : INotifiableModel
    {
        _notificationInfo.PropInfo.MemberName = ResultServiceHelpers.TranslateLambda(expression);

        return this;
    }

    /// <summary>
    ///  Garante validações personalizadas por meio de arrow function. Quando o retorno for false irá registrar falha.
    /// </summary>
    /// <typeparam name="TCollectionEntity">Reprensa o tipo para o item da lista o mesmo deve ser um objeto que é notificável.</typeparam>
    /// <param name="func">Arrow function que deve retornar um booleano.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureList<TEntity> Must<TCollectionEntity>(Func<List<TCollectionEntity>, bool> func, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: !func(_notificationInfo.PropInfo.Value),
               notificationInfo: _notificationInfo,
               erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor nunca seja nulo. Caso contrário irá registrar falha.
    /// </summary>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureList<TEntity> NotNull(FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: _notificationInfo.PropInfo.Value == null,
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor nunca seja nulo ou com número de itens == 0. Caso contrário irá registrar falha.
    /// </summary>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureList<TEntity> NotEmpty(FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: _notificationInfo.PropInfo.Value == null || _notificationInfo.PropInfo.Value.Count == 0,
               notificationInfo: _notificationInfo,
               erro: failureModel);
    }

    /// <summary>
    /// Garante o registro das falhas dos itens da lista quando os mesmos possuirem falhas.
    /// </summary>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureList<TEntity> NoFailures()
    {
        if (_notificationInfo.PropInfo.Value != null)
        {
            var failures = ListService.GetNotifications(_notificationInfo.PropInfo.Value, _notificationInfo.PropInfo.MemberName);

            for (var i = 0; i < failures?.Count; i++)
            {
                var failure = failures[i];

                _notificationContext.AddNotification(failure);
            }
        }

        return this;
    }
}