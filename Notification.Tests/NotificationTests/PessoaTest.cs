using FluentAssertions;
using Notification.Entities;
using Notification.Extensions;
using Notification.Models;
using Notification.Notifications.Notifiable.Notifications;

namespace Notification.Tests.NotificationTests;

public class PessoaTest : Notifiable
{
    [Fact]
    public void ValidateSucess()
    {
        var endereco1 = new Endereco()
            .CriarEndereco(
                cep: "endereco",
                cidade: "cidade", 
                estado: "estado",
                logradouro: new Logradouro().CriarLogradouro(
                        logradouro: "logradouro",
                        ruas: new List<Rua>()
                        {
                            new Rua().CriarRua(Rua: "Rua 1"),
                            new Rua().CriarRua(Rua: "Rua 2")
                        }
                    )
            );


        var endereco2 = new Endereco()
            .CriarEndereco(
                cep: "endereco",
                cidade: "cidade",
                estado: "estado",
                logradouro: new Logradouro().CriarLogradouro(
                        logradouro: "logradouro",
                        ruas: new List<Rua>()
                        {
                            new Rua().CriarRua(Rua: "Rua 1"),
                            new Rua().CriarRua(Rua: "Rua 2")
                        }
                    )
            );

        var pessoa = new Pessoa()
            .CriarPessoa(
                primeiroNome: "Pessoa com nome válido",
                sobrenome: "sobrenome",
                email: "email@teste.com",
                dataNascimento: DateTime.Now,
                endereco: endereco1,
                enderecos: new List<Endereco>()
                {
                    endereco1,
                    endereco2
                }
            );

        pessoa.HasFailure().Should().BeFalse();
    }


    [Fact]
    public void ValidateErrorList()
    {
        var endereco1 = new Endereco()
            .CriarEndereco(
                cep: "endereco",
                cidade: "cidade",
                estado: "estado",
                logradouro: new Logradouro().CriarLogradouro(
                        logradouro: "logradouro",
                        ruas: new List<Rua>()
                        {
                            new Rua().CriarRua(Rua: "Rua 1"),
                            new Rua().CriarRua(Rua: "Rua 2")
                        }
                    )
            );


        var endereco2 = new Endereco()
            .CriarEndereco(
                cep: "endereco",
                cidade: "cidade",
                estado: "estado",
                logradouro: new Logradouro().CriarLogradouro(
                        logradouro: "logradouro",
                        ruas: new List<Rua>()
                        {
                            new Rua().CriarRua(Rua: "Rua 1"),
                            new Rua().CriarRua(Rua: "Rua 2")
                        }
                    )
            );

        var pessoa = new Pessoa()
            .CriarPessoa(
                primeiroNome: "Pessoa com nome válido",
                sobrenome: "sobrenome",
                email: "email@teste.com",
                dataNascimento: DateTime.Now,
                endereco: endereco2
            );

        var failues = pessoa.GetFailures();

        pessoa.GetFailures().Select(a => a.Error).Should().Contain(Erros.Pessoa.EnderecosEObrigatorio);
    }

    [Fact]
    public void ValidateSupremeErrorList()
    {
        var endereco1 = new Endereco()
            .CriarEndereco(
                cep: "",
                cidade: "",
                estado: "",
                logradouro: new Logradouro().CriarLogradouro(
                        logradouro: "",
                        ruas: new List<Rua>()
                        {
                            new Rua().CriarRua(Rua: ""),
                            new Rua().CriarRua(Rua: "")
                        }
                    )
            );

        var endereco2 = new Endereco()
            .CriarEndereco(
                cep: "",
                cidade: "",
                estado: "",
                logradouro: new Logradouro().CriarLogradouro(
                        logradouro: "",
                        ruas: new List<Rua>()
                        {
                            new Rua().CriarRua(Rua: ""),
                            new Rua().CriarRua(Rua: "")
                        }
                    )
            );

        var enderecos = new List<Endereco>() { endereco1, endereco2 };

        var pessoa = new Pessoa()
            .CriarPessoa(
                primeiroNome: "",
                sobrenome: "",
                email: "",
                dataNascimento: DateTime.Now,
                endereco: endereco2,
                enderecos : enderecos
            );

        var failues = pessoa.GetFailures().Select(a => new
        {
            prop = a.NotificationInfo.PropInfo.MemberName,
            message = a.Error.message
        }).ToList();

        pessoa.GetFailures().Select(a => a.Error).Should().Contain(Erros.Pessoa.EnderecosEObrigatorio);
    }



    [Fact]
    public void FazNada()
    {

    }
}
