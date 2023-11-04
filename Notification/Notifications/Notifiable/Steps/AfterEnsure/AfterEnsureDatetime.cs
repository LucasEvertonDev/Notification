using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureDatetime<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    public AfterEnsureDatetime(NotificationContext notificationContext, NotificationInfo notificationInfo)
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
    public AfterEnsureDatetime<TEntity> ForContext(Expression<Func<TEntity, DateTime?>> expression, [CallerArgumentExpression(nameof(expression))] string argumentExpression = null)
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
    public AfterEnsureDatetime<TEntity> Must(Func<DateTime? ,bool> func, FailureModel failureModel)
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
    public AfterEnsureDatetime<TEntity> NotNull(FailureModel failureModel)
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
    /// Garante que o valor nunca seja igual a DateTime.MinValue Caso contrário irá registrar falha
    /// </summary>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureDatetime<TEntity> NotMinValue(FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: DateTime.Equals(_notificationInfo.PropInfo.Value, DateTime.MinValue),
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
    public AfterEnsureDatetime<TEntity> Equals(DateTime? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !DateTime.Equals(_notificationInfo.PropInfo.Value, value),
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
    public AfterEnsureDatetime<TEntity> NotEquals(DateTime? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: DateTime.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    /// <summary>
    /// Garante que o valor esteja no intervalor informado. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureDatetime<TEntity> Between(DateTime start, DateTime end, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: _notificationInfo.PropInfo.Value <= start || _notificationInfo.PropInfo.Value >= end,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }
}

