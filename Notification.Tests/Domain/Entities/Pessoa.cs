using Notification.Tests.Domain.ValueObjects;

namespace Notification.Tests.Domain.Entities;

public partial class Pessoa : BaseEntity<Pessoa>
{
    public Nome Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public Endereco Endereco { get; private set; }
    public List<Endereco> Enderecos { get; private set; } = new List<Endereco>();

    public Pessoa CriarPessoa(string primeiroNome, string sobrenome, string email, DateTime? dataNascimento, Endereco endereco, List<Endereco> enderecos = null)
    {
        var nome = new Nome(primeiroNome, sobrenome);

        Ensure(nome).ForContext(p => p.Nome).NoFailures();

        Ensure(email).ForContext(p => p.Email).NotNullOrEmpty(Erros.Pessoa.EmailObrigatorio).EmailAddress(Erros.Pessoa.EmailInvalido);

        Ensure(endereco).ForContext(p => p.Endereco).NotNull(Erros.Pessoa.EnderecoEObrigatorio).NoFailures();

        Ensure(enderecos).ForContext(p => p.Enderecos).NotNull(Erros.Pessoa.EnderecosEObrigatorio).NoFailures();
   
        this.Nome = nome;
        this.Email = email;
        this.DataNascimento = dataNascimento;
        this.Endereco = endereco;
        this.Enderecos = enderecos;

        return this;
    }
}
