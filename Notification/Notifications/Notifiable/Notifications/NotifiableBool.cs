using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AfterSet;
using Notification.Notifications.Notifiable.Steps.AfterValidationWhen;
using System.Linq.Expressions;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    protected AfterSet<AfterValidationWhenBool> Set(Expression<Func<TEntity, bool>> memberLamda, bool value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenBool>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

    protected AfterSet<AfterValidationWhenBool> Set(Expression<Func<TEntity, bool?>> memberLamda, bool? value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenBool>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }
}