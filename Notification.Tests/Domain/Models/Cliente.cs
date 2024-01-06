using Authentication.Application.Domain.Contexts.DbAuth.Atendimentos;
using Notifications.Notifiable.Notifications;

namespace Authentication.Application.Domain.Contexts.DbAuth.Clientes;
public class Cliente : Notifiable<Cliente>
{
    public Cliente()
    {
        
    }
    public Cliente(string cpf, string nome, DateTime? dataNascimento, string telefone)
    {
        Cpf = cpf;
        Nome = nome;
        DataNascimento = dataNascimento;
        Telefone = telefone;
    }

    public string Cpf { get; private set; }

    public string Nome { get; private set; }

    public DateTime? DataNascimento { get; private set; }

    public string Telefone { get; private set; }

    public virtual ICollection<Atendimento> Atendimentos { get; private set; }

    public void UpdateUsuario(string cpf, string nome, DateTime? dataNascimento, string telefone, int situacao)
    {
        Cpf = cpf;
        Nome = nome;
        DataNascimento = dataNascimento;
        Telefone = telefone;
    }
}
