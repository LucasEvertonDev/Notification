using System.Linq.Expressions;
using Notification.Extensions;
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
public class AfterEnsureObject<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;
    private bool _isAddOnList;

    /// <summary>
    /// Initializes a new instance of the <see cref="AfterEnsureObject{TEntity}"/> class.
    /// Construtor para continuar a arquiterura de steps.
    /// </summary>
    /// <param name="notificationContext">Indica o contexto em que será registrada as notificações.</param>
    /// <param name="notificationInfo">Representa as informações adicionais para compor o contexto da notificação.</param>
    public AfterEnsureObject(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
        _isAddOnList = false;
    }

    /// <summary>
    /// Associa as validações a determinada propriedade da classe.
    /// Em caso de uso deve ser informado após o ensure.
    /// </summary>
    /// <param name="expression">Lambda indicando a propriedade da classe que irá receber o valor a ser validado.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureObject<TEntity> ForContext(Expression<Func<TEntity, INotifiableModel>> expression)
    {
        _notificationInfo.PropInfo.MemberName = ResultServiceHelpers.TranslateLambda(expression);

        return this;
    }

    /// <summary>
    /// Associa as validações a determinada propriedade da classe.
    /// Em caso de uso deve ser informado após o ensure.
    /// </summary>
    /// <typeparam name="TCollectionEntity">Reprensa o tipo para o item da lista o mesmo deve ser um objeto que é notificável.</typeparam>
    /// <param name="expression">Lambda indicando a propriedade da classe que irá receber o valor a ser validado.</param>
    /// <param name="instance">Tem objetivo de passar a referência da lista que está sendo adcionada.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureObject<TEntity> ForContext<TCollectionEntity>(Expression<Func<TEntity, List<TCollectionEntity>>> expression, List<TCollectionEntity> instance)
        where TCollectionEntity : INotifiableModel
    {
        _isAddOnList = true;
        _notificationInfo.PropInfo.MemberName = ResultServiceHelpers.TranslateLambda(expression) + $"[{instance.Count}]";
        return this;
    }

    /// <summary>
    ///  Garante validações personalizadas por meio de arrow function. Quando o retorno for false irá registrar falha.
    /// </summary>
    /// <typeparam name="TNotifiableModel">Reprensa o tipo do objeto a ser validado.</typeparam>
    /// <param name="func">Arrow function que deve retornar um booleano.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureObject<TEntity> Must<TNotifiableModel>(Func<TNotifiableModel, bool> func, FailureModel failureModel)
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
    ///  Garante que o valor nunca seja nulo. Caso contrário irá registrar falha.
    /// </summary>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureObject<TEntity> NotNull(FailureModel failureModel)
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
    ///  Garante o registro das falhas do valor quando o mesmo possuir falhas..
    /// </summary>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureObject<TEntity> NoFailures()
    {
        if (_notificationInfo.PropInfo.Value == null)
        {
            return this;
        }

        if (_isAddOnList)
        {
            for (var i = 0; i < ((INotifiableModel)_notificationInfo.PropInfo.Value)?.GetNotifications()?.Count; i++)
            {
                var translate = string.Empty;
                var failure = ((INotifiableModel)_notificationInfo.PropInfo.Value).GetNotifications()[i];

                var notification = ListService.Clone(failure);

                var separacoes = notification.NotificationInfo.PropInfo.MemberName?.Split(".").ToList();

                if (separacoes != null && separacoes.Count > 0)
                {
                    separacoes.RemoveAt(0);
                    translate = string.Join(string.Empty, separacoes);
                }

                notification.NotificationInfo.PropInfo.MemberName = translate;

                notification.NotificationInfo.PropInfo.SetMemberNamePrefix(_notificationInfo.PropInfo.MemberName);

                _notificationContext.AddNotification(notification);
            }
        }
        else
        {
            var translate = string.Empty;
            var separacoes = _notificationInfo.PropInfo.MemberName.Split(".").ToList();

            if (separacoes.Count > 0)
            {
                separacoes.RemoveAt(separacoes.Count - 1);

                translate = string.Join(string.Empty, separacoes);
            }

            for (var i = 0; i < ((INotifiableModel)_notificationInfo.PropInfo.Value)?.GetNotifications()?.Count; i++)
            {
                var failure = ((INotifiableModel)_notificationInfo.PropInfo.Value).GetNotifications()[i];

                var notification = ListService.Clone(failure);

                notification.NotificationInfo.PropInfo.SetMemberNamePrefix(translate);

                _notificationContext.AddNotification(notification);
            }
        }

        return this;
    }
}
