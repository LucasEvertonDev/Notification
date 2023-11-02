using Notification.Notifications.Notifiable.Notifications.Base;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities;

public partial class BaseEntity<TEntity> : Notifiable<TEntity>
{
    public BaseEntity()
    {
    }

    public Guid Id { get; protected set; }

    public int Situacao { get; protected set; }
}
