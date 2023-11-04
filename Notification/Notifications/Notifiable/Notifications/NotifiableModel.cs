using Notification.Notifications;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using System.Text.Json.Serialization;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    [JsonIgnore]
    public Result Result { get; set; }

    [JsonIgnore]
    private static EntityInfo EntityInfo => new()
    {
        Name = typeof(TEntity).Name,
        Namespace = typeof(TEntity).Namespace,
        NotificationType = Notification.Notifications.Enum.NotificationType.DomainNotification
    };

    public Notifiable()
    {
        Result = new Result(new NotificationContext());
    }
}