using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureInt<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    public AfterEnsureInt(NotificationContext notificationContext, NotificationInfo notificationInfo)
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
    public AfterEnsureInt<TEntity> ForContext(Expression<Func<TEntity, long?>> expression, [CallerArgumentExpression(nameof(expression))] string argumentExpression = null)
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
    public AfterEnsureInt<TEntity> Must(Func<long?, bool> func, FailureModel failureModel)
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
    public AfterEnsureInt<TEntity> NotNull(FailureModel failureModel)
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
    /// Garante que o valor SEJA equivalente ao informado. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="value"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureInt<TEntity> Equals(long? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !long.Equals(_notificationInfo.PropInfo.Value, value.GetValueOrDefault()),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    /// <summary>
    /// Garante que o valor esteja no intervalo informado. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureInt<TEntity> Between(long start, long end, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !(_notificationInfo.PropInfo.Value >= start && _notificationInfo.PropInfo.Value <= end),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    /// <summary>
    /// Garante que o valor NÃO seja equivalente ao informado. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="value"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureInt<TEntity> NotEquals(long? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: long.Equals(_notificationInfo.PropInfo.Value, value.GetValueOrDefault()),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }


    /// <summary>
    /// Garante que o valor seja maior que o valor informado. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="value"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureInt<TEntity> GreaterThan(long? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: value.GetValueOrDefault() >= _notificationInfo.PropInfo.Value,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    /// <summary>
    /// Garante que o valor seja maior ou igual que o valor informado. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="value"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureInt<TEntity> GreaterThanOrEqualTo(long? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: value.GetValueOrDefault() > _notificationInfo.PropInfo.Value,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    /// <summary>
    /// Garante que o valor seja menor que o valor informado. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="value"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureInt<TEntity> LessThan(long? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: value.GetValueOrDefault() <= _notificationInfo.PropInfo.Value,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    /// <summary>
    /// Garante que o valor seja menor ou igual que o valor informado. Caso contrário ira registrar falha
    /// </summary>
    /// <param name="value"></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureInt<TEntity> LessThanOrEqualTo(long? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: value.GetValueOrDefault() < _notificationInfo.PropInfo.Value,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }
}