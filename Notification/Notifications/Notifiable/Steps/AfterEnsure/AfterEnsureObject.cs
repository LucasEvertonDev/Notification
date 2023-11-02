using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using Notification.Extensions;
using System.Runtime.CompilerServices;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureObject<TEntity>
{
    private bool _addInList { get; set; }
    private NotificationInfo _notificationInfo;
    private NotificationContext _notificationContext;

    public AfterEnsureObject(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    public AfterEnsureObject<TEntity> ForContext(Expression<Func<TEntity, INotifiableModel>> expression,
        [CallerArgumentExpression("expression")] string argumentExpression = null)
    {
        _notificationInfo.PropInfo.MemberName = ResultService.TranslateLambda(expression);

        return this;
    }

    public AfterEnsureObject<TEntity> ForContext<TCollectionEntity>(Expression<Func<TEntity, List<TCollectionEntity>>> expression, List<TCollectionEntity> instance,
        [CallerArgumentExpression("expression")] string argumentExpression = null) where TCollectionEntity : INotifiableModel
    {
        _addInList = true;
        _notificationInfo.PropInfo.MemberName = ResultService.TranslateLambda(expression) + $"[{instance.Count}]";

        return this;
    }

    /// <summary>
    /// Falso para registrar falhas
    /// </summary>
    /// <param name=""></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureObject<TEntity> Must(Func<bool> func, FailureModel failureModel)
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

    public AfterEnsureObject<TEntity> NotNull(FailureModel failureModel)
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
    public AfterEnsureObject<TEntity> NoFailures()
    {
        if (_notificationInfo.PropInfo.Value == null)
        {
            return this;
        }

        if (_addInList)
        {
            for (var i = 0; i < ((INotifiableModel)_notificationInfo.PropInfo.Value)?.GetNotifications()?.Count; i++)
            {
                var translate = string.Empty;
                var failure = ((INotifiableModel)_notificationInfo.PropInfo.Value).GetNotifications()[i];

                var notification = ListService.Clone(failure);

                var separacoes = ((string)notification.NotificationInfo.PropInfo.MemberName)?.Split(".").ToList();

                if (separacoes.Count > 0)
                {
                    separacoes.RemoveAt(0);
                    translate = string.Join("", separacoes);
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

                translate = string.Join("", separacoes);
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
