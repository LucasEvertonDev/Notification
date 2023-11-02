using Notification.Notifications;

namespace Notification.Tests.Domain.Entities;

public class Logradouro : BaseEntity<Logradouro>
{
    public string Nome { get; set; }

    public List<Rua> Ruas { get; set; } = new List<Rua>();
    public Logradouro CriarLogradouro(string logradouro, List<Rua> ruas)
    {
        Ensure(logradouro).ForContext(logradouro => logradouro.Nome).NotNullOrEmpty(new FailureModel("logradouro", "logradouro é obrigatório"));

        Ensure(ruas).ForContext(logradouro => logradouro.Ruas).NoFailures();

        this.Nome = logradouro;
        this.Ruas = ruas;

        return this;
    }
}

public class Rua : BaseEntity<Rua>
{
    public string Nome { get; set; }

    public Rua CriarRua(string Rua)
    {
        Ensure(Rua).ForContext(Rua => Rua.Nome).NotNullOrEmpty(new FailureModel("Rua", "Rua é obrigatório"));

        this.Nome = Rua;
        return this;
    }
}

