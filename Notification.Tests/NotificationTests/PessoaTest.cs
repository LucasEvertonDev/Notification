using Authentication.Application.Domain.Contexts.DbAuth.Atendimentos;
using Authentication.Application.Domain.Contexts.DbAuth.Clientes;
using Authentication.Application.Domain.Contexts.DbAuth.MapAtendimentosServicos;
using FluentAssertions;
using Newtonsoft.Json;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain;
using Notification.Tests.Domain.Entities;
using System.Threading;
using static Notification.Tests.Domain.Erros;
using Pessoa = Notification.Tests.Domain.Entities.Pessoa;

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

        pessoa.HasFailures().Should().BeFalse();
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

        var pessoa = new Domain.Entities.Pessoa()
            .CriarPessoa(
                primeiroNome: "Pessoa com nome válido",
                sobrenome: "sobrenome",
                email: "email@teste.com",
                dataNascimento: DateTime.Now,
                endereco: null,
                enderecos: null
            );

        var failues = pessoa.GetFailures();

        pessoa.GetFailures().Should().Contain(Erros.Pessoa.EnderecosEObrigatorio);
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

        var failures = pessoa.GetNotifications().Select(a => new
        {
            prop = a.NotificationInfo.PropInfo.MemberName,
            message = a.Error.message
        }).ToList();

        var json = JsonConvert.SerializeObject(failures);

        var jsonOld = "[{\"prop\":\"Pessoa.Nome.PrimeiroNome\",\"message\":\"Primeiro nome é obrigatório\"},{\"prop\":\"Pessoa.Nome.Sobrenome\",\"message\":\"SobreNome é obrigatório\"},{\"prop\":\"Pessoa.Email\",\"message\":\"Email é obrigatório\"},{\"prop\":\"Pessoa.Email\",\"message\":\"Email Inválido\"},{\"prop\":\"Pessoa.Endereco.Cep\",\"message\":\"Cep é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Estado\",\"message\":\"Estado é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Cidade\",\"message\":\"Cidade é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Logradouro.Nome\",\"message\":\"logradouro é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Logradouro.Ruas[0].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Endereco.Logradouro.Ruas[1].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Cep\",\"message\":\"Cep é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Estado\",\"message\":\"Estado é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Cidade\",\"message\":\"Cidade é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Logradouro.Nome\",\"message\":\"logradouro é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Logradouro.Ruas[0].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[0].Logradouro.Ruas[1].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Cep\",\"message\":\"Cep é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Estado\",\"message\":\"Estado é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Cidade\",\"message\":\"Cidade é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Logradouro.Nome\",\"message\":\"logradouro é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Logradouro.Ruas[0].Nome\",\"message\":\"Rua é obrigatório\"},{\"prop\":\"Pessoa.Enderecos[1].Logradouro.Ruas[1].Nome\",\"message\":\"Rua é obrigatório\"}]";

        json.Equals(jsonOld).Should().BeTrue();
    }



    [Fact]
    public void FazNada()
    {
        var atendimento = new Atendimento(
            data: DateTime.Now,
            cliente: null,
            clienteAtrasado: false,
            valorAtendimento: 0,
            valorPago: 0,
            observacaoAtendimento: "",
            situacao: 1);

        var mapServicoAtendimento = new MapAtendimentoServico(
            servico: null,
            atendimento: atendimento,
            valorCobrado: 0);
         

        atendimento.AddServico(mapServicoAtendimento);


        var failures = atendimento.GetNotifications().Select(a => new
        {
            prop = a.NotificationInfo.PropInfo.MemberName,
            message = a.Error.message
        }).ToList();


        failures.Where(a => a.prop == "Atendimento.MapAtendimentosServicos[0].Atendimento.Cliente").Should().NotBeNull();
    }
}
