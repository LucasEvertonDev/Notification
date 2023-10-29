using FluentAssertions;
using Newtonsoft.Json;
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
}
 