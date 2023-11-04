﻿namespace Notification.Notifications.Context;

public class NotificationContext
{
    private readonly List<NotificationModel> _notifications;

    public NotificationContext()
    {
        _notifications = new List<NotificationModel>();
    }

    public IReadOnlyCollection<NotificationModel> Notifications => _notifications;

    public bool HasNotifications => _notifications.Any();

    public void AddNotification(NotificationModel notification)
    {
        _notifications.Add(notification);
    }

    public void AddNotifications(List<NotificationModel> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(IReadOnlyCollection<NotificationModel> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(IList<NotificationModel> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void AddNotifications(ICollection<NotificationModel> notifications)
    {
        _notifications.AddRange(notifications);
    }
}
