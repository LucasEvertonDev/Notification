using Notification.Notifications;
using Notification.Tests.Domain.ValueObjects.Base;

namespace Notification.Tests.Domain.ValueObjects;

public class Nome : ValueObject<Nome>
{
    public Nome(string primeiroNome, string sobrenome)
    {
        Ensure(primeiroNome).ForContext(nome => nome.PrimeiroNome).NotNullOrEmpty(new FailureModel("PRIMEIRO_NOME", "Primeiro nome é obrigatório"));

        Ensure(sobrenome).ForContext(nome => nome.Sobrenome).NotNullOrEmpty(new FailureModel("SOBRENOME", "SobreNome é obrigatório"));

        this.PrimeiroNome = primeiroNome;
        this.Sobrenome = sobrenome;
    }

    public Nome() { }

    public string PrimeiroNome { get; set; }
    public string Sobrenome { get; set; }

    public string NomeCompleto() => string.Concat(PrimeiroNome, " ", Sobrenome);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return PrimeiroNome;
        yield return Sobrenome;
    }
}
