using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Decimal;

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
    public LessThanModel(decimal valor1 = 10, decimal? valor2 = 9, decimal valor3 = 10, decimal valor4 = 7, decimal valor5 = 14)
    {
        Ensure(valor1).ForContext(e => e.LessThanError).LessThan(10, LessThanErros.LessThanError);

        Ensure(valor2).ForContext(e => e.LessThanSuccess).LessThan(10, LessThanErros.LessThanSuccess);

        Ensure(valor3).ForContext(e => e.LessThanOrEqualTo).LessThanOrEqualTo(10, LessThanErros.LessThanOrEqualTo);

        Ensure(valor4).ForContext(e => e.LessThanOrEqualToSuccess).LessThanOrEqualTo(10, LessThanErros.LessThanOrEqualToSuccess);

        Ensure(valor5).ForContext(e => e.LessThanOrEqualToError).LessThanOrEqualTo(10, LessThanErros.LessThanOrEqualToError);
    }

    public decimal LessThanSuccess { get; set; }

    public decimal LessThanError { get; set; }

    public decimal LessThanOrEqualTo { get; set; }

    public decimal LessThanOrEqualToSuccess { get; set; }

    public decimal LessThanOrEqualToError { get; set; }

}
