using Notification.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.list;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.list;

public class NullListErros
{
    public static FailureModel NullSuccess { get; set; } = new FailureModel("NullSuccess", "Esse erro não deve acontecer");

    public static FailureModel NullError { get; set; } = new FailureModel("NullError", "Esse erro deve acontecer");
}

public class NullModel : Notifiable<NullModel>
{
    public NullModel()
    {
        List<Teste> valorNulo = null;
        var valorNaoNulo = new List<Teste>() { new Teste() { Prop1 = "2" } };

        Ensure(valorNulo).ForContext(e => e.NullError).NotNull(NullListErros.NullError);

        Ensure(valorNaoNulo).ForContext(e => e.NullSuccess).NotNull(NullListErros.NullSuccess);
    }

    public List<Teste> NullSuccess { get; set; }

    public List<Teste> NullError { get; set; }
}
