using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.guid;

public class NullGuidErros
{
    public static FailureModel NullSuccess { get; set; } = new FailureModel("NullSuccess", "Esse erro não deve acontecer");

    public static FailureModel NullError { get; set; } = new FailureModel("NullError", "Esse erro deve acontecer");
}

public class NullModel : Notifiable<NullModel>
{
    public NullModel(Guid? valorNulo = null, Guid valorNaoNulo = new Guid())
    {
        Ensure(valorNulo).ForContext(e => e.NullError).NotNull(NullGuidErros.NullError);

        Ensure(valorNaoNulo).ForContext(e => e.NullSuccess).NotNull(NullGuidErros.NullSuccess);
    }

    public Guid NullSuccess { get; set; }

    public Guid NullError { get; set; }
}
