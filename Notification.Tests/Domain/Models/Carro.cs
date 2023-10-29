using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Models;

public class Carro : Notifiable<Carro>
{
    public Carro()
    {
        var rodas = new List<Roda>() { new Roda(), new Roda(), new Roda(), new Roda() };

        Set(c => c.Rodas, rodas);
    }

    public List<Roda> Rodas { get; set; } = new List<Roda>();
}

public class Roda : Notifiable<Roda>
{
    public Roda()
    {
        var parafusos = new List<Parafuso>() { new Parafuso(), new Parafuso() };

        Set(r => r.Pneu, string.Empty).AndValidate()
            .IsNullOrEmpty(new Notifications.FailureModel("", "Pneu é obrigatório"));

        Set(r => r.Aro, string.Empty).AndValidate()
             .IsNullOrEmpty(new Notifications.FailureModel("", "Aro é obrigatório"));

        Set(r => r.Parafusos, parafusos);
    }

    public string Pneu { get; set; }

    public string Aro { get; set; }

    public List<Parafuso> Parafusos { get; set; } = new List<Parafuso> { };  
}

public class Parafuso : Notifiable<Parafuso>
{
    public Parafuso()
    {
        Set(p => p.Porca, string.Empty).AndValidate()
            .IsNullOrEmpty(new Notifications.FailureModel("", "Porca é obrigatório"));

        Set(p => p.Tamanho, string.Empty).AndValidate()
            .IsNullOrEmpty(new Notifications.FailureModel("", "Tamanho é obrigatório"));
    }

    public string Tamanho { get; set; }

    public string Porca { get; set; }
}