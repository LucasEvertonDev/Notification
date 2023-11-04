using Microsoft.Extensions.DependencyInjection;
using Notification.Notifications.Context;

namespace Notification;

/// <summary>
/// Classe para a inicialização dos serviçõs do pacote.
/// </summary>
public static class BootstrapModule
{
    /// <summary>
    /// Registra a configuração dos serviços para o uso de notification.
    /// </summary>
    /// <param name="services">Representa a coleção de serviços.</param>
    public static void AddNotification(this IServiceCollection services)
    {
        services.AddScoped<NotificationContext>();
    }
}
