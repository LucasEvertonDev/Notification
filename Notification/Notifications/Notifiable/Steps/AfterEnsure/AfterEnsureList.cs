using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureList<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    public AfterEnsureList(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    /// <summary>
    /// Associa as validações a determinada propriedade da classe
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="argumentExpression"></param>
    /// <returns></returns>
    public AfterEnsureList<TEntity> ForContext<TCollectionEntity>(Expression<Func<TEntity, List<TCollectionEntity>>> expression) where TCollectionEntity : INotifiableModel
    {
        _notificationInfo.PropInfo.MemberName = ResultService.TranslateLambda(expression);

        return this;
    }

    /// <summary>
    /// Garante validações personalizadas por meio de arrow function. Quando o retorno for false irá registrar falha
    /// </summary>
    /// <param name=""></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureList<TEntity> Must<TCollectionEntity>(Func<List<TCollectionEntity>, bool> func, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: !func(_notificationInfo.PropInfo.Value),
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }

    /// <summary>
    /// Garante que o valor nunca seja nulo. Caso contrário irá registrar falha
    /// </summary>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureList<TEntity> NotNull(FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: _notificationInfo.PropInfo.Value == null,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    /// <summary>
    /// Garante que o valor nunca seja nulo ou com número de itens == 0. Caso contrário irá registrar falha
    /// </summary>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureList<TEntity> NotEmpty(FailureModel notEmptyError)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: _notificationInfo.PropInfo.Value == null || _notificationInfo.PropInfo.Value.Count == 0,
               notificationInfo: _notificationInfo,
               erro: notEmptyError
           );
    }

    /// <summary>
    /// Garante o registro das falhas dos itens da lista quando os mesmos possuirem falhas.
    /// </summary>
    /// <returns></returns>
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