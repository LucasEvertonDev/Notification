using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;

namespace Notification.Extensions;

public static class List
{
    public static bool HasFailures<T>(this List<T> list) where T : INotifiableModel
    {
        return list.Exists(item => item.GetFailures().Any());
    }

    public static List<NotificationModel> GetNotifications<T>(this List<T> list, string prefix) where T : INotifiableModel
    {
        var notifications = new List<NotificationModel>();

        if (list == null || list.Count() == 0)
        {
            return notifications;
        }

        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            if (item.GetFailures().Any())
            {
                notifications.AddRange(
                    item.GetFailures().Select(notication =>
                    {
                        var nomeRedundanteDoObjetoDaLista = notication.NotificationInfo.PropInfo.MemberName.IndexOf('.');
                        notication.NotificationInfo.PropInfo.MemberName = $"{prefix}[{i}].{notication.NotificationInfo.PropInfo.MemberName.Substring(nomeRedundanteDoObjetoDaLista + 1)}";

                        return notication;
                    })
                    .ToList()
                );
            }
        }

        return notifications;
    }
}
