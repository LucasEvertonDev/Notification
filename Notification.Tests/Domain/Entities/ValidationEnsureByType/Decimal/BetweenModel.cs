using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Decimal;

public class BetweenDecimalErros
{
    public static FailureModel BetweenSuccess { get; set; } = new FailureModel("BetweenSuccess", "Esse erro não deve acontecer");

    public static FailureModel BetweenError { get; set; } = new FailureModel("BetweenError", "Esse erro deve acontecer");
}

public class BetweenModel : Notifiable<BetweenModel>
{
    public BetweenModel(decimal? valorErro = 10, decimal? valorSucesso = 11)
    {
        Ensure(valorErro).ForContext(e => e.BetweenError).Between(11, 15, BetweenDecimalErros.BetweenError);

        Ensure(valorSucesso).ForContext(e => e.BetweenSuccess).Between(11, 15, BetweenDecimalErros.BetweenSuccess);
    }

    public decimal BetweenSuccess { get; set; }

    public decimal BetweenError { get; set; }
}
