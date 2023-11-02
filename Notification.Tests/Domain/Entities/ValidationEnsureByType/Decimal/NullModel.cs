using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Decimal;

public class NullDecimalErros
{
    public static FailureModel NullSuccess { get; set; } = new FailureModel("NullSuccess", "Esse erro não deve acontecer");

    public static FailureModel NullError { get; set; } = new FailureModel("NullError", "Esse erro deve acontecer");
}

public class NullModel : Notifiable<NullModel>
{
    public NullModel(decimal? valorNulo = null, decimal? valorNaoNulo = 2)
    {
        Ensure(valorNulo).ForContext(e => e.NullError).NotNull(NullDecimalErros.NullError);

        Ensure(valorNaoNulo).ForContext(e => e.NullSuccess).NotNull(NullDecimalErros.NullSuccess);
    }

    public decimal NullSuccess { get; set; }

    public decimal NullError { get; set; }
}
