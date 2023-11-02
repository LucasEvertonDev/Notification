using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Models;

public class Carro : Notifiable<Carro>
{
    public Carro()
    {
        var rodas = new List<Roda>() { new Roda(), new Roda(), new Roda(), new Roda() };

        Ensure(rodas).ForContext(c => c.Rodas).NoFailures();

        this.Rodas = rodas;
    }

    public List<Roda> Rodas { get; set; } = new List<Roda>();
}

public class Roda : Notifiable<Roda>
{
    public Roda()
    {
        var parafusos = new List<Parafuso>() { new Parafuso(), new Parafuso() };

        Ensure(string.Empty).ForContext(c => c.Pneu).NotNullOrEmpty(new Notifications.FailureModel("", "Pneu é obrigatório"));

        Ensure(string.Empty).ForContext(c => c.Aro).NotNullOrEmpty(new Notifications.FailureModel("", "Aro é obrigatório"));

        Ensure(parafusos).ForContext(c => c.Parafusos).NoFailures();


        this.Aro = "";
        this.Pneu = "";
        this.Parafusos = parafusos;
    }

    public string Pneu { get; set; }

    public string Aro { get; set; }

    public List<Parafuso> Parafusos { get; set; } = new List<Parafuso> { };  
}

public class Parafuso : Notifiable<Parafuso>
{
    public Parafuso()
    {
        Ensure(string.Empty).ForContext(c => c.Porca).NotNullOrEmpty(new Notifications.FailureModel("", "Porca é obrigatório"));

        Ensure(string.Empty).ForContext(c => c.Tamanho).NotNullOrEmpty(new Notifications.FailureModel("", "Tamanho é obrigatório"));

        this.Tamanho = "";
        this.Porca = "";
    }

    public string Tamanho { get; set; }

    public string Porca { get; set; }
}