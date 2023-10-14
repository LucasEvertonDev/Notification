using Notification.Notifications;
using Notification.ValueObjects.Base;

namespace Notification.ValueObjects;

public class Nome : ValueObject<Nome>
{
    public Nome() { }

    public string PrimeiroNome { get; set; }
    public string Sobrenome { get; set; }


    public string NomeCompleto() => string.Concat(PrimeiroNome, " ", Sobrenome);

    public Nome CriarNome(string primeiroNome, string sobrenome)
    {
        Set(nome => nome.PrimeiroNome, primeiroNome)
            .ValidateWhen()
            .IsNullOrEmpty()
            .AddFailure(new FailureModel("PRIMEIRO_NOME", "Primeiro nome é obrigatório"));

        Set(nome => nome.Sobrenome, sobrenome)
            .ValidateWhen()
            .IsNullOrEmpty()
            .AddFailure(new FailureModel("SOBRENOME", "SobreNome é obrigatório"));

        return this;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return PrimeiroNome;
        yield return Sobrenome;
    }
}
