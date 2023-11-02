using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;

namespace Notification.Extensions;

public static class NotifiableModelExtensions
{
    public static List<NotificationModel> GetNotifications(this INotifiableModel current)
    {
        return current.Result.GetContext().Notifications.ToList();
    }

    public static List<FailureModel> GetFailures(this INotifiableModel current)
    {
        return current.Result.GetContext().Notifications.Select(a => a.Error).ToList();
    }

    public static bool HasFailures(this INotifiableModel current)
    {
        return current.GetFailures().Any();
    }
}
