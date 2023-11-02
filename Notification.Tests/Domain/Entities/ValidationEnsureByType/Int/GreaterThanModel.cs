using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Int;

public class GreaterThanErros
{
    public static FailureModel GreaterThanSuccess { get; set; } = new FailureModel("GreaterThanSuccess", "Esse erro não deve acontecer");

    public static FailureModel GreaterThanError { get; set; } = new FailureModel("GreaterThanError", "Esse erro deve acontecer");

    public static FailureModel GreaterThanOrEqualToSuccess { get; set; } = new FailureModel("GreaterThanOrEqualToSuccess", "Esse erro não deve acontecer");

    public static FailureModel GreaterThanOrEqualToError { get; set; } = new FailureModel("GreaterThanOrEqualToError", "Esse erro deve acontecer");

    public static FailureModel GreaterThanOrEqualTo { get; set; } = new FailureModel("GreaterThanOrEqualTo", "Não deve acontecer teste de igual");

}

public class GreaterThanModel : Notifiable<GreaterThanModel>
{
    public GreaterThanModel()
    {
        Ensure(10).ForContext(e => e.GreaterThanError).GreaterThan(10, GreaterThanErros.GreaterThanError);

        Ensure(11).ForContext(e => e.GreaterThanSuccess).GreaterThan(10, GreaterThanErros.GreaterThanSuccess);

        Ensure(10).ForContext(e => e.GreaterThanOrEqualTo).GreaterThanOrEqualTo(10, GreaterThanErros.GreaterThanOrEqualTo);

        Ensure(13).ForContext(e => e.GreaterThanOrEqualToSuccess).GreaterThanOrEqualTo(10, GreaterThanErros.GreaterThanOrEqualToSuccess);

        Ensure(9).ForContext(e => e.GreaterThanOrEqualToError).GreaterThanOrEqualTo(10, GreaterThanErros.GreaterThanOrEqualToError);
    }

    public long GreaterThanSuccess { get; set; }

    public long GreaterThanError { get; set; }

    public long GreaterThanOrEqualTo { get; set; }

    public long GreaterThanOrEqualToSuccess { get; set; }

    public long GreaterThanOrEqualToError { get; set; }

}
