using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Obj;

public class NullObjectErros
{
    public static FailureModel NullSuccess { get; set; } = new FailureModel("NullSuccess", "Esse erro não deve acontecer");

    public static FailureModel NullError { get; set; } = new FailureModel("NullError", "Esse erro deve acontecer");
}

public class NullModel : Notifiable<NullModel>
{
    public NullModel()
    {
        var valorNaoNulo = new Teste() { Prop1 = "2" };
        Teste nulo = null;

        Ensure(nulo).ForContext(e => e.NullError).NotNull(NullObjectErros.NullError);

        Ensure(valorNaoNulo).ForContext(e => e.NullSuccess).NotNull(NullObjectErros.NullSuccess);
    }

    public Teste NullSuccess { get; set; }

    public Teste NullError { get; set; }
}
