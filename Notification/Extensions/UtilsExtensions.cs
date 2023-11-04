using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Services;

namespace Notification.Extensions;

public static class UtilsExtensions
{
    public static bool HasFailures<T>(this List<T> list)
        where T : INotifiableModel
    {
        return list.Exists(item => item.GetNotifications().Any());
    }

    public static List<NotificationModel> GetNotifications<T>(this List<T> list, string prefix)
        where T : INotifiableModel
    {
        return ListService.GetNotifications(list, prefix);
    }
}
