using FluentAssertions;
using Newtonsoft.Json;
using Notification.Extensions;
using Notification.Notifications;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Models;

namespace Notification.Tests.NotificationTests;

public class CarroTest : Notifiable
{
    [Fact]
    public void ValidateError()
    {
        var carro = new Carro();

        var failures = carro.GetNotifications().Select(x => new { x.NotificationInfo.PropInfo.MemberName, x.Error });

        var json = JsonConvert.SerializeObject(failures);

        var jsonOld = "[{\"MemberName\":\"Carro.Rodas[0].Pneu\",\"Error\":{\"key\":\"\",\"message\":\"Pneu é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[0].Aro\",\"Error\":{\"key\":\"\",\"message\":\"Aro é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[0].Parafusos[0].Porca\",\"Error\":{\"key\":\"\",\"message\":\"Porca é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[0].Parafusos[0].Tamanho\",\"Error\":{\"key\":\"\",\"message\":\"Tamanho é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[0].Parafusos[1].Porca\",\"Error\":{\"key\":\"\",\"message\":\"Porca é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[0].Parafusos[1].Tamanho\",\"Error\":{\"key\":\"\",\"message\":\"Tamanho é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[1].Pneu\",\"Error\":{\"key\":\"\",\"message\":\"Pneu é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[1].Aro\",\"Error\":{\"key\":\"\",\"message\":\"Aro é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[1].Parafusos[0].Porca\",\"Error\":{\"key\":\"\",\"message\":\"Porca é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[1].Parafusos[0].Tamanho\",\"Error\":{\"key\":\"\",\"message\":\"Tamanho é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[1].Parafusos[1].Porca\",\"Error\":{\"key\":\"\",\"message\":\"Porca é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[1].Parafusos[1].Tamanho\",\"Error\":{\"key\":\"\",\"message\":\"Tamanho é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[2].Pneu\",\"Error\":{\"key\":\"\",\"message\":\"Pneu é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[2].Aro\",\"Error\":{\"key\":\"\",\"message\":\"Aro é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[2].Parafusos[0].Porca\",\"Error\":{\"key\":\"\",\"message\":\"Porca é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[2].Parafusos[0].Tamanho\",\"Error\":{\"key\":\"\",\"message\":\"Tamanho é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[2].Parafusos[1].Porca\",\"Error\":{\"key\":\"\",\"message\":\"Porca é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[2].Parafusos[1].Tamanho\",\"Error\":{\"key\":\"\",\"message\":\"Tamanho é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[3].Pneu\",\"Error\":{\"key\":\"\",\"message\":\"Pneu é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[3].Aro\",\"Error\":{\"key\":\"\",\"message\":\"Aro é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[3].Parafusos[0].Porca\",\"Error\":{\"key\":\"\",\"message\":\"Porca é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[3].Parafusos[0].Tamanho\",\"Error\":{\"key\":\"\",\"message\":\"Tamanho é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[3].Parafusos[1].Porca\",\"Error\":{\"key\":\"\",\"message\":\"Porca é obrigatório\"}},{\"MemberName\":\"Carro.Rodas[3].Parafusos[1].Tamanho\",\"Error\":{\"key\":\"\",\"message\":\"Tamanho é obrigatório\"}}]";

        json.Equals(jsonOld).Should().BeTrue();
    }

    [Fact]
    public void ValidateUsuarioError()
    {
        var result = new Result(new Notification.Notifications.Context.NotificationContext());

        var usuario = new Usuario("", new List<Contato>() { new Contato("", "") });

        usuario.AdicionarContato(new Contato("Email", ""));

        if (usuario.HasFailures())
        {
            result.Failure<Usuario>(usuario);

            result.Failure<Usuario>(u => u.Contatos[1].Email, new FailureModel("Email Invalido", "Email invalido"));
        }

        var falhas = result.GetFailures().Select(x => new { x.NotificationInfo.PropInfo.MemberName, x.Error });

        var json = JsonConvert.SerializeObject(falhas);

        var jsonOld = "[{\"MemberName\":\"Usuario.Nome\",\"Error\":{\"key\":\"NomeObrigatorio\",\"message\":\"Nome da pessoa é obrigatório\"}},{\"MemberName\":\"Usuario.Contatos[0].Email\",\"Error\":{\"key\":\"EmialObrigatorio\",\"message\":\"Email da pessoa é obrigatório\"}},{\"MemberName\":\"Usuario.Contatos[0].Telefone\",\"Error\":{\"key\":\"TelefoneObrigatorio\",\"message\":\"Telefone da pessoa é obrigatório\"}},{\"MemberName\":\"Usuario.Contatos[1].Telefone\",\"Error\":{\"key\":\"TelefoneObrigatorio\",\"message\":\"Telefone da pessoa é obrigatório\"}},{\"MemberName\":\"Usuario.Contatos[1].Email\",\"Error\":{\"key\":\"Email Invalido\",\"message\":\"Email invalido\"}}]";

        json.Equals(jsonOld).Should().BeTrue();
    }
}
 