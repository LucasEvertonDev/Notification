﻿using Authentication.Application.Domain.Contexts.DbAuth.Clientes;
using Authentication.Application.Domain.Contexts.DbAuth.MapAtendimentosServicos;
using Notifications.Notifiable.Notifications;

namespace Authentication.Application.Domain.Contexts.DbAuth.Atendimentos;

public class Atendimento : Notifiable<Atendimento>
{
    // Toda vez que se recebe uma entidade deve ter um construtor vazio para o entity entender
    public Atendimento(
        DateTime data,
        Cliente cliente,
        bool clienteAtrasado,
        decimal? valorAtendimento,
        decimal? valorPago,
        string observacaoAtendimento,
        int situacao)
    {
        Ensure(cliente).ForContext(a => a.Cliente)
            .NotNull(AtendimentoFailures.ClienteObrigatorio)
            .NoFailures();

        Data = data;
        Cliente = cliente;
        ClienteAtrasado = clienteAtrasado;
        ValorAtendimento = valorAtendimento;
        ValorPago = valorPago;
        Situacao = situacao;
        ObservacaoAtendimento = observacaoAtendimento;
        MapAtendimentosServicos = new List<MapAtendimentoServico>();
    }

    public DateTime Data { get; private set; }

    public Guid ClienteId { get; private set; }

    public bool ClienteAtrasado { get; private set; }

    public decimal? ValorAtendimento { get; private set; }

    public decimal? ValorPago { get; private set; }

    public string ObservacaoAtendimento { get; private set; }

    public int Situacao { get; private set; }

    public virtual Cliente Cliente { get; private set; }

    public virtual ICollection<MapAtendimentoServico> MapAtendimentosServicos { get; private set; }

    public void AddServico(MapAtendimentoServico mapAtendimentoServico)
    {
        Ensure(mapAtendimentoServico).ForContext(atendimento => atendimento.MapAtendimentosServicos, this.MapAtendimentosServicos)
            .NoFailures();

        this.MapAtendimentosServicos.Add(mapAtendimentoServico);
    }
}
