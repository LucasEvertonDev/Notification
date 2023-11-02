using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Datetime;

public class NullDateTimeErros
{
    public static FailureModel NullSuccess { get; set; } = new FailureModel("NullSuccess", "Esse erro não deve acontecer");

    public static FailureModel NullError { get; set; } = new FailureModel("NullError", "Esse erro deve acontecer");

}

public class NullModel : Notifiable<NullModel>
{
    public NullModel()
    {
        DateTime? valorNulo = null;
        DateTime? valorNaoNulo = DateTime.Parse("2023-10-15");

        Ensure(valorNulo).ForContext(e => e.NullError).NotNull(NullDateTimeErros.NullError);

        Ensure(valorNaoNulo).ForContext(e => e.NullSuccess).NotNull(NullDateTimeErros.NullSuccess);
    }

    public DateTime NullSuccess { get; set; }

    public DateTime NullError { get; set; }
}
