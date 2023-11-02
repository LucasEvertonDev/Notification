using Notification.Extensions;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureList<TEntity>
{
    private NotificationInfo _notificationInfo;
    private NotificationContext _notificationContext;

    public AfterEnsureList(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    public AfterEnsureList<TEntity> ForContext<TCollectionEntity>(Expression<Func<TEntity, List<TCollectionEntity>>> expression,
        [CallerArgumentExpression("expression")] string argumentExpression = null) where TCollectionEntity : INotifiableModel
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
    public AfterEnsureList<TEntity> Must(Func<bool> func, FailureModel failureModel)
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
    ///  As falhas serão injetadas automaticamente
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