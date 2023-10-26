using Microsoft.Extensions.DependencyInjection;
using Notification.Notifications.Context;

namespace Architecture.Application.Core;

public static class BootstrapModule
{
    public static void AddNotification(this IServiceCollection services)
    {
        services.AddScoped<NotificationContext>();
    }
}
