using Notification.Notifications.Enum;

namespace Notification.Notifications;

public class NotificationInfo
{
    public NotificationInfo (PropInfo propInfo, EntityInfo entityInfo)
    {
        this.PropInfo = propInfo;
        this.EntityInfo = entityInfo;
    }

    public PropInfo PropInfo { get; set; }

    public EntityInfo EntityInfo { get; set; }
}


public class PropInfo
{
    public dynamic Value { get; set; }

    public string MemberName { get; set; }

    public string ClearName { get; set; }

    public void SetMemberNamePrefix(string prefix)
    {
        this.MemberName = string.IsNullOrEmpty(prefix) ? this.MemberName : string.Concat(prefix, ".", this.MemberName);
    }
}

public class EntityInfo
{
    public string Name { get; set; }

    public string Namespace { get; set; }

    public NotificationType NotificationType { get; set; } = NotificationType.BusinessNotification;
}