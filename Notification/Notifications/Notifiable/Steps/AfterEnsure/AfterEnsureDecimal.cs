using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureDecimal<TEntity>
{
    private NotificationInfo _notificationInfo;
    private NotificationContext _notificationContext;

    public AfterEnsureDecimal(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    public AfterEnsureDecimal<TEntity> ForContext(Expression<Func<TEntity, decimal?>> expression, [CallerArgumentExpression("expression")] string argumentExpression = null)
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
    public AfterEnsureDecimal<TEntity> Must(Func<bool> func, FailureModel failureModel)
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

    public AfterEnsureDecimal<TEntity> Equals(decimal? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !decimal.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterEnsureDecimal<TEntity> Between(decimal start, decimal end, FailureModel failureModel)
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

    public AfterEnsureDecimal<TEntity> NotEquals(decimal? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: decimal.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterEnsureDecimal<TEntity> GreaterThan(decimal? value, FailureModel failureModel)
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

    public AfterEnsureDecimal<TEntity> GreaterThanOrEqualTo(decimal? value, FailureModel failureModel)
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

    public AfterEnsureDecimal<TEntity> LessThan(decimal? value, FailureModel failureModel)
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

    public AfterEnsureDecimal<TEntity> LessThanOrEqualTo(decimal? value, FailureModel failureModel)
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