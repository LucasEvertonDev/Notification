﻿using Notification.Models;
using Notification.ValueObjects;

namespace Notification.Entities;

public partial class Pessoa : BaseEntity<Pessoa>
{
    public Nome Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public Endereco Endereco { get; private set; }

    public List<Endereco> Enderecos { get; private set; } = new List<Endereco>();

    public Pessoa CriarPessoa(string primeiroNome, string sobrenome, string email, DateTime? dataNascimento, Endereco endereco, List<Endereco> enderecos = null)
    {
        //Set(pessoa => pessoa.Nome, new Nome()
        //    .CriarNome(
        //        primeiroNome: primeiroNome,
        //        sobrenome: sobrenome
        //    ));

        //Set(pessoa => pessoa.Email, email)
        //    .ValidateWhen()
        //    .IsNullOrEmpty().AddFailure(Erros.Pessoa.EmailObrigatorio)
        //    .IsInvalidEmail().AddFailure(Erros.Pessoa.EmailInvalido);

        //Set(pessoa => pessoa.DataNascimento, dataNascimento);

        Set(pessoa => pessoa.Endereco, endereco);


        Set(pessoa => pessoa.Enderecos, enderecos);

        return this;
    }
}
