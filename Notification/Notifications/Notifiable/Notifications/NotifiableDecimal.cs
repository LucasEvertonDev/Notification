using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AfterSet;
using Notification.Notifications.Notifiable.Steps.AfterValidationWhen;
using System.Linq.Expressions;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    protected AfterSet<AfterValidationWhenDecimal> Set(Expression<Func<TEntity, Decimal>> memberLamda, Decimal value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenDecimal>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

    protected AfterSet<AfterValidationWhenDecimal> Set(Expression<Func<TEntity, Decimal?>> memberLamda, Decimal? value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenDecimal>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }
}