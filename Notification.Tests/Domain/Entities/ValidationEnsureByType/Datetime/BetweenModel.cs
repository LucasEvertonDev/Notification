using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Datetime;

public class BetweenDateTimeErros
{
    public static FailureModel BetweenSuccess { get; set; } = new FailureModel("BetweenSuccess", "Esse erro não deve acontecer");

    public static FailureModel BetweenError { get; set; } = new FailureModel("BetweenError", "Esse erro deve acontecer");
}

public class BetweenModel : Notifiable<BetweenModel>
{
    public BetweenModel()
    {
        DateTime valorErro = DateTime.Parse("2023-10-01");
        DateTime? valorSucesso = DateTime.Parse("2023-10-15");

        Ensure(valorErro).ForContext(e => e.BetweenError).Between(DateTime.Parse("2023-10-14"), DateTime.Parse("2023-10-30"), BetweenDateTimeErros.BetweenError);

        Ensure(valorSucesso).ForContext(e => e.BetweenSuccess).Between(DateTime.Parse("2023-10-14"), DateTime.Parse("2023-10-30"), BetweenDateTimeErros.BetweenSuccess);
    }

    public DateTime BetweenSuccess { get; set; }

    public DateTime BetweenError { get; set; }
}
