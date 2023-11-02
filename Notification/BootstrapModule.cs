using Microsoft.Extensions.DependencyInjection;
using Notification.Notifications.Context;

namespace Notification;

public static class BootstrapModule
{
    public static void AddNotification(this IServiceCollection services)
    {
        services.AddScoped<NotificationContext>();
    }
}
