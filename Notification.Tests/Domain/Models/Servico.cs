using Authentication.Application.Domain.Contexts.DbAuth.MapAtendimentosServicos;
using Notifications.Notifiable.Notifications;

namespace Authentication.Application.Domain.Contexts.DbAuth.Servicos;
public class Servico : Notifiable<Servico>
{
    public Servico()
    {
        
    }
    public Servico(string nome, string descricao, int situacao)
    {
        this.Nome = nome;
        this.Descricao = descricao;
    }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public virtual ICollection<MapAtendimentoServico> MapAtendimentoServicos { get; private set; }

    public Servico UpdateServico(string nome, string descricao, int situacao)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        return this;
    }
}
