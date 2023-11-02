using Newtonsoft.Json;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications.Base;

namespace Notification.Notifications.Services;

public static class ListService
{
    public static T Clone<T>(T a)
    {
        string jsonString = JsonConvert.SerializeObject(a);
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
    public static List<NotificationModel> GetNotifications(dynamic list, string prefix)
    {
        var notifications = new List<NotificationModel>();

        if (list == null || list.Count == 0)
        {
            return notifications;
        }

        for (var i = 0; i < list.Count; i++)
        {
            var item = (INotifiableModel)list[i];
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
