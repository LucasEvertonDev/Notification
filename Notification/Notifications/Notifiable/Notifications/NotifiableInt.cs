﻿using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Notifiable.Steps.AfterSet;
using Notification.Notifications.Notifiable.Steps.AfterValidationWhen;
using System.Linq.Expressions;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    protected AfterSet<AfterValidationWhenObject> Set(Expression<Func<TEntity, short>> memberLamda, short value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenObject>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

    protected AfterSet<AfterValidationWhenObject> Set(Expression<Func<TEntity, short?>> memberLamda, short? value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenObject>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

    protected AfterSet<AfterValidationWhenInt> Set(Expression<Func<TEntity, int>> memberLamda, int value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenInt>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

    protected AfterSet<AfterValidationWhenObject> Set(Expression<Func<TEntity, int?>> memberLamda, int? value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenObject>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

    protected AfterSet<AfterValidationWhenObject> Set(Expression<Func<TEntity, long>> memberLamda, long value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenObject>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

    protected AfterSet<AfterValidationWhenObject> Set(Expression<Func<TEntity, long?>> memberLamda, long? value)
    {
        this.SetValue(memberLamda, value);

        return new AfterSet<AfterValidationWhenObject>(Result.GetContext(), new NotificationInfo(CurrentProp, EntityInfo));
    }

}
