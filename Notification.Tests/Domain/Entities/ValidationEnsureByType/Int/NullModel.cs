using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Int;

public class NullIntErros
{
    public static FailureModel NullSuccess { get; set; } = new FailureModel("NullSuccess", "Esse erro não deve acontecer");

    public static FailureModel NullError { get; set; } = new FailureModel("NullError", "Esse erro deve acontecer");
}

public class NullModel : Notifiable<NullModel>
{
    public NullModel(int? valorNulo = null, int? valorNaoNulo = 2)
    {
        Ensure(valorNulo).ForContext(e => e.NullError).NotNull(NullIntErros.NullError);

        Ensure(valorNaoNulo).ForContext(e => e.NullSuccess).NotNull(NullIntErros.NullSuccess);
    }

    public long NullSuccess { get; set; }

    public long NullError { get; set; }
}
