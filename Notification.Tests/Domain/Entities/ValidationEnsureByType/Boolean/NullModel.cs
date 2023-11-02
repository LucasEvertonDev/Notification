using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Boolean;

public class NullBooleanErros
{
    public static FailureModel NullSuccess { get; set; } = new FailureModel("NullSuccess", "Esse erro não deve acontecer");

    public static FailureModel NullError { get; set; } = new FailureModel("NullError", "Esse erro deve acontecer");
}

public class NullModel : Notifiable<NullModel>
{
    public NullModel(bool? valorNulo = null, bool valorNaoNulo = false)
    {
        Ensure(valorNulo).ForContext(e => e.NullError).NotNull(NullBooleanErros.NullError);

        Ensure(valorNaoNulo).ForContext(e => e.NullSuccess).NotNull(NullBooleanErros.NullSuccess);
    }

    public bool NullSuccess { get; set; }

    public bool NullError { get; set; }
}
