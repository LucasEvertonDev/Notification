using Notifications.Notifiable.Notifications;

namespace Notification.Tests.NotificationTests;

public class Usuario : Notifiable<Usuario>
{
    public Usuario(string nome, List<Contato> contatos)
    {
        Ensure(nome).ForContext(u => u.Nome).NotNullOrEmpty(new Notifications.FailureModel("NomeObrigatorio", "Nome da pessoa é obrigatório"));
        Ensure(contatos).ForContext(u => u.Contatos).NoFailures();

        this.Contatos = contatos;
        this.Nome = nome;
    }

    public string Nome { get; private set; }

    public List<Contato> Contatos { get; private set; }

    public Usuario AdicionarContato(Contato contato)
    {
        Ensure(contato).ForContext(u => u.Contatos, this.Contatos).NoFailures();

        this.Contatos.Add(contato);

        return this;
    }
}


public class Contato : Notifiable<Contato>
{
    public Contato(string email, string telefone)
    {
        Ensure(email).ForContext(u => u.Email).NotNullOrEmpty(new Notifications.FailureModel("EmialObrigatorio", "Email da pessoa é obrigatório"));
        Ensure(telefone).ForContext(u => u.Telefone).NotNullOrEmpty(new Notifications.FailureModel("TelefoneObrigatorio", "Telefone da pessoa é obrigatório"));

        this.Email = email;
        this.Telefone = telefone;
    }

    public string Email { get; private set; }

    public string Telefone { get; private set; }
}