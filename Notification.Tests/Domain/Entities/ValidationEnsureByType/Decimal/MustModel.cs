using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Decimal;

public class MustDecimalErros
{
    public static FailureModel MustSuccess { get; set; } = new FailureModel("MustSuccess", "Esse erro não deve acontecer");

    public static FailureModel MustError { get; set; } = new FailureModel("MustError", "Esse erro deve acontecer");
}

public class MustModel : Notifiable<MustModel>
{
    public MustModel(decimal valor1 = (decimal)12, decimal valor2 = 20)
    {
        Ensure(valor1).ForContext(e => e.MustError).Must((valor) =>
        {
            return valor == (decimal)12.4;
        }, MustDecimalErros.MustError);

        Ensure(valor2).ForContext(e => e.MustSuccess).Must((valor) =>
        {
            return valor.GetValueOrDefault() == 20;
        }, MustDecimalErros.MustSuccess);
    }

    public decimal MustSuccess { get; set; }

    public decimal MustError { get; set; }
}
