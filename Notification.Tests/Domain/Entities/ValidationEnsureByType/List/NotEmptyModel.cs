using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.list;

public class NotEmptyListErros
{
    public static FailureModel NotEmptySuccess { get; set; } = new FailureModel("NotEmptySuccess", "Esse erro não deve acontecer");
    public static FailureModel NotEmptyError { get; set; } = new FailureModel("NotEmptyError", "Esse erro deve acontecer");
}

public class NotEmptyModel : Notifiable<NotEmptyModel>
{
    public NotEmptyModel()
    {
        List<Teste> valorNulo = new List<Teste>();
        var valorNaoNulo = new List<Teste>() { new Teste() { Prop1 = "2" } };

        Ensure(valorNulo).ForContext(e => e.NotEmptyError).NotEmpty(NotEmptyListErros.NotEmptyError);

        Ensure(valorNaoNulo).ForContext(e => e.NotEmptySuccess).NotEmpty(NotEmptyListErros.NotEmptySuccess);
    }

    public List<Teste> NotEmptyError { get; set; }

    public List<Teste> NotEmptySuccess { get; set; }

}