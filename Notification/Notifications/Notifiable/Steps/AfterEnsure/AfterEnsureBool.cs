using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureBool<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    public AfterEnsureBool(NotificationContext notificationContext, NotificationInfo notificationInfo)
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
    public AfterEnsureBool<TEntity> ForContext(Expression<Func<TEntity, bool>> expression, [CallerArgumentExpression(nameof(expression))] string argumentExpression = null)
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
    public AfterEnsureBool<TEntity> Must(Func<bool?, bool> func, FailureModel failureModel)
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
    public AfterEnsureBool<TEntity> NotNull(FailureModel failureModel)
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
    /// Garante que o valor SEJA equivalente ao recebido. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="value"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureBool<TEntity> Equals(bool? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !bool.Equals(_notificationInfo.PropInfo.Value, value.GetValueOrDefault()),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    /// <summary>
    /// Garante que o valor NÃO seja equivalente ao recebido. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="value"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureBool<TEntity> NotEquals(bool? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: bool.Equals(_notificationInfo.PropInfo.Value, value.GetValueOrDefault()),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }
}
