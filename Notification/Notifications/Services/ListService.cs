using Newtonsoft.Json;

namespace Notification.Notifications.Services;

public static class ListService
{
    public static T Clone<T>(T a)
    {
        string jsonString = JsonConvert.SerializeObject(a);
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
}
