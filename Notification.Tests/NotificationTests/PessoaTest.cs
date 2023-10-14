using FluentAssertions;
using Newtonsoft.Json;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain;
using Notification.Tests.Domain.Entities;

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
                endereco: null,
                enderecos: null
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

        var failures = pessoa.GetFailures().Select(a => new
        {
            prop = a.NotificationInfo.PropInfo.MemberName,
            message = a.Error.message
        }).ToList();

        var json = JsonConvert.SerializeObject(failures );

        var jsonOld = "[{\"prop\":\"Pessoa.Nome.PrimeiroNome\",\"message\":\"Primeiro nome é obrigatório\"},{\"prop\":\"Pessoa.Nome.Sobrenome\",\"message\":\"SobreNome é obrigatório\"},{\"prop\":\"Pessoa.Email\",\"message\":\"Email é obrigatório\"},{\"prop\":\"Pessoa.Email\",\"message\":\"Email Inválido\"},{\"prop\":\"Pessoa.Endereco.Cep\",\"message\":\"Cep é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Estado\",\"message\":\"Estado é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Cidade\",\"message\":\"Cidade é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Logradouro.Nome\",\"message\":\"logradouro é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Logradouro.Ruas[0].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Logradouro.Ruas[1].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Cep\",\"message\":\"Cep é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Estado\",\"message\":\"Estado é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Cidade\",\"message\":\"Cidade é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Logradouro.Nome\",\"message\":\"logradouro é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Logradouro.Ruas[0].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Logradouro.Ruas[1].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Cep\",\"message\":\"Cep é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Estado\",\"message\":\"Estado é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Cidade\",\"message\":\"Cidade é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Logradouro.Nome\",\"message\":\"logradouro é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Logradouro.Ruas[0].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Logradouro.Ruas[1].Nome\",\"message\":\"Rua é obrigatório\"}]";

        json.Equals(jsonOld).Should().BeTrue();
    }



    [Fact]
    public void FazNada()
    {

    }
}
