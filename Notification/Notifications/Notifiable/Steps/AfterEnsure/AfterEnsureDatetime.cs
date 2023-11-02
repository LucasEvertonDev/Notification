using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureDatetime<TEntity>
{
    private NotificationInfo _notificationInfo;
    private NotificationContext _notificationContext;

    public AfterEnsureDatetime(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    public AfterEnsureDatetime<TEntity> ForContext(Expression<Func<TEntity, DateTime?>> expression, [CallerArgumentExpression("expression")] string argumentExpression = null)
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
    public AfterEnsureDatetime<TEntity> Must(Func<bool> func, FailureModel failureModel)
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

    public AfterEnsureDatetime<TEntity> Between(DateTime start, DateTime end, FailureModel failureModel)
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
}

