using Newtonsoft.Json;
using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using Notification.Notifications.Services;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Notification.Extensions;

public static class List
{
    public static bool HasFailures<T>(this List<T> list) where T : INotifiableModel
    {
        return list.Exists(item => item.GetNotifications().Any());
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
            if (item.GetNotifications().Any())
            {
                notifications.AddRange(
                    item.GetNotifications().Select(notf =>
                    {
                        var notification = ListService.Clone(notf);

                        var nomeRedundanteDoObjetoDaLista = notf.NotificationInfo.PropInfo.MemberName.IndexOf('.');
                        notification.NotificationInfo.PropInfo.MemberName = $"{prefix}[{i}].{notf.NotificationInfo.PropInfo.MemberName.Substring(nomeRedundanteDoObjetoDaLista + 1)}";

                        return notification;
                    })
                    .ToList()
                );
            }
        }

        return notifications;
    }
}
