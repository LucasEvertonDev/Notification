﻿using Notification.Notifications;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using System.Text.Json.Serialization;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    [JsonIgnore]
    public Result Result { get; set; }

    [JsonIgnore]
    private EntityInfo EntityInfo => new EntityInfo()
    {
        Name = typeof(TEntity).Name,
        Namespace = typeof(TEntity).Namespace
    };

    public Notifiable()
    {
        Result = new Result(new NotificationContext());
    }
}