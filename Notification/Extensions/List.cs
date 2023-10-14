using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications.Base;
using System.Linq;

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
                    item.GetFailures().Select(notf =>
                    {
                        var nomeRedundanteDoObjetoDaLista = notf.NotificationInfo.PropInfo.MemberName.IndexOf('.');

                        var notification = new NotificationModel(notf.Error,
                            new NotificationInfo(
                                new PropInfo()
                                {
                                    MemberName = $"{prefix}[{i}].{notf.NotificationInfo.PropInfo.MemberName.Substring(nomeRedundanteDoObjetoDaLista + 1)}",
                                    Value = notf.NotificationInfo.PropInfo.Value,
                                },
                                notf.NotificationInfo.EntityInfo
                            )
                        );

                        return notification;
                    })
                    .ToList()
                );
            }
        }

        return notifications;
    }
}
