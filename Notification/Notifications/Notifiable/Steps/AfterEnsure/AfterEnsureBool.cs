using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureBool<TEntity>
{
    private NotificationInfo _notificationInfo;
    private NotificationContext _notificationContext;

    public AfterEnsureBool(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    public AfterEnsureBool<TEntity> ForContext(Expression<Func<TEntity, bool>> expression, [CallerArgumentExpression("expression")] string argumentExpression = null)
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
