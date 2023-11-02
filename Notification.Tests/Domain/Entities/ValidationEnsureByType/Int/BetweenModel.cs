using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Int;

public class BetweenIntErros
{
    public static FailureModel BetweenSuccess { get; set; } = new FailureModel("BetweenSuccess", "Esse erro não deve acontecer");

    public static FailureModel BetweenError { get; set; } = new FailureModel("BetweenError", "Esse erro deve acontecer");
}

public class BetweenModel : Notifiable<BetweenModel>
{
    public BetweenModel(int? valorErro = 10, int? valorSucesso = 11)
    {
        Ensure(10).ForContext(e => e.BetweenError).Between(11, 15,  BetweenIntErros.BetweenError);

        Ensure(11).ForContext(e => e.BetweenSuccess).Between(11, 15, BetweenIntErros.BetweenSuccess);
    }

    public long BetweenSuccess { get; set; }

    public long BetweenError { get; set; }
}
