using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureInt<TEntity>
{
    private NotificationInfo _notificationInfo;
    private NotificationContext _notificationContext;

    public AfterEnsureInt(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    public AfterEnsureInt<TEntity> ForContext(Expression<Func<TEntity, long?>> expression, [CallerArgumentExpression("expression")] string argumentExpression = null)
    {
        _notificationInfo.PropInfo.MemberName = ResultService.TranslateLambda(expression);
        return this;
    }

    /// <summary>
    /// Falso para registrar falhas
    /// </summary>
    /// <param name=""></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureInt<TEntity> Must(Func<bool> func, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: !func(),
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }

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

    public AfterEnsureInt<TEntity> Between(long start, long end, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: _notificationInfo.PropInfo.Value < start || _notificationInfo.PropInfo.Value > end,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

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