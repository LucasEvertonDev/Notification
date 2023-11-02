using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Int;

public class LessThanErros
{
    public static FailureModel LessThanSuccess { get; set; } = new FailureModel("LessThanSuccess", "Esse erro não deve acontecer");

    public static FailureModel LessThanError { get; set; } = new FailureModel("LessThanError", "Esse erro deve acontecer");

    public static FailureModel LessThanOrEqualToSuccess { get; set; } = new FailureModel("LessThanOrEqualToSuccess", "Esse erro não deve acontecer");

    public static FailureModel LessThanOrEqualToError { get; set; } = new FailureModel("LessThanOrEqualToError", "Esse erro deve acontecer");

    public static FailureModel LessThanOrEqualTo { get; set; } = new FailureModel("LessThanOrEqualTo", "Não deve acontecer teste de igual");

}

public class LessThanModel : Notifiable<LessThanModel>
{
    public LessThanModel()
    {
        Ensure(10).ForContext(e => e.LessThanError).LessThan(10, LessThanErros.LessThanError);

        Ensure(9).ForContext(e => e.LessThanSuccess).LessThan(10, LessThanErros.LessThanSuccess);

        Ensure(10).ForContext(e => e.LessThanOrEqualTo).LessThanOrEqualTo(10, LessThanErros.LessThanOrEqualTo);

        Ensure(7).ForContext(e => e.LessThanOrEqualToSuccess).LessThanOrEqualTo(10, LessThanErros.LessThanOrEqualToSuccess);

        Ensure(14).ForContext(e => e.LessThanOrEqualToError).LessThanOrEqualTo(10, LessThanErros.LessThanOrEqualToError);
    }

    public long LessThanSuccess { get; set; }

    public long LessThanError { get; set; }

    public long LessThanOrEqualTo { get; set; }

    public long LessThanOrEqualToSuccess { get; set; }

    public long LessThanOrEqualToError { get; set; }

}
