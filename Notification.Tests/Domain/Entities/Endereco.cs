using Notification.Notifications;

namespace Notification.Tests.Domain.Entities;

public class Endereco : BaseEntity<Endereco>
{
    public string Cep { get; private set; }
    public string Estado { get; private set; }
    public string Cidade { get; private set; }
    public Guid PessoaId { get; private set; }

    public Pessoa Pessoa { get; private set; }

    public Logradouro Logradouro { get; private set; }

    public Endereco CriarEndereco(string cep, string estado, string cidade, Logradouro logradouro)
    {
        Ensure(cep).ForContext(endereco => endereco.Cep).NotNullOrEmpty(new FailureModel("endereco", "Cep é obrigatório"));

        Ensure(estado).ForContext(endereco => endereco.Estado).NotNullOrEmpty(new FailureModel("endereco", "Estado é obrigatório"));

        Ensure(cidade).ForContext(endereco => endereco.Cidade).NotNullOrEmpty(new FailureModel("endereco", "Cidade é obrigatório"));

        Ensure(logradouro).ForContext(endereco => endereco.Logradouro).NoFailures();
     
        this.Cep = cep;
        this.Estado = estado;
        this.Cidade = cidade;
        this.Logradouro = logradouro;

        return this;
    }
}
