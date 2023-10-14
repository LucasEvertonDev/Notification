using Notification.Extensions;
using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AfterSet;
using Notification.Notifications.Notifiable.Steps.AfterValidationWhen;
using System.Linq.Expressions;

namespace Architecture.Application.Core.Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    /// <summary>
    ///  Quando record as notificaçoes são integradas de forma interna 
    /// </summary>
    /// <param name="memberLamda"></param>
    /// <param name="value"></param>
    protected AfterSet<AfterValidationWhenObject> Set(Expression<Func<TEntity, INotifiableModel>> memberLamda, INotifiableModel value)
    {
        this.SetValue(memberLamda, value);

        for (var i = 0; i < value?.GetFailures()?.Count(); i++)
        {
            var failure = value.GetFailures()[i];

            failure.NotificationInfo.PropInfo.SetMemberNamePrefix(CurrentProp.MemberName);

            this.Result.GetContext().AddNotification(new NotificationModel(
                 failure.Error,
                 new NotificationInfo(
                     new PropInfo()
                     {
                         MemberName = failure.NotificationInfo.PropInfo.MemberName,
                         Value = failure.NotificationInfo.PropInfo.Value,
                     },
                     failure.NotificationInfo.EntityInfo
                 )
            ));
        }

        return new AfterSet<AfterValidationWhenObject>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

    /// <summary>
    ///  Quando record as notificaçoes são integradas de forma interna 
    /// </summary>
    /// <param name="memberLamda"></param>
    /// <param name="value"></param>
    protected AfterSet<AfterValidationWhenObject> Set<T>(Expression<Func<TEntity, List<T>>> memberLamda, List<T> value) where T : INotifiableModel
    {
        this.SetValue(memberLamda, value);

        var failures = value.GetNotifications(CurrentProp.MemberName);

        for (var i = 0; i < failures.Count; i++)
        {
            var failure = failures[i];

            this.Result.GetContext().AddNotification(failure);
        }

        return new AfterSet<AfterValidationWhenObject>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }
}