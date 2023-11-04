using System.Text.Json.Serialization;
using Notification.Notifications;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    [JsonIgnore]
    public Result Result { get; set; } = new Result(new NotificationContext());

    [JsonIgnore]
    private static EntityInfo EntityInfo => new ()
    {
        Name = typeof(TEntity).Name,
        Namespace = typeof(TEntity).Namespace,
        NotificationType = Notification.Notifications.Enum.NotificationType.DomainNotification
    };
}