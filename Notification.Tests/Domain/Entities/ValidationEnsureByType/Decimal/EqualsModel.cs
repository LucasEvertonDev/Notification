using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Decimal;

public class EqualsDecimalErros
{
    public static FailureModel EqualsSuccess { get; set; } = new FailureModel("EqualsSuccess", "Esse erro não deve acontecer");
    public static FailureModel EqualsError { get; set; } = new FailureModel("EqualsError", "Esse erro deve acontecer");
    public static FailureModel NotEqualsSuccess { get; set; } = new FailureModel("NotEqualsSuccess", "Esse erro não deve acontecer");
    public static FailureModel NotEqualsError { get; set; } = new FailureModel("NotEqualsError", "Esse erro deve acontecer");
}

public class EqualsModel : Notifiable<EqualsModel>
{
    public EqualsModel(decimal? valor =10)
    {
        Ensure(valor).ForContext(e => e.NotEqualsError).NotEquals(10, EqualsDecimalErros.NotEqualsError);

        Ensure(valor).ForContext(e => e.NotEqualsSuccess).NotEquals(11, EqualsDecimalErros.NotEqualsSuccess);

        Ensure(valor).ForContext(e => e.EqualsError).Equals(11, EqualsDecimalErros.EqualsError);

        Ensure(valor).ForContext(e => e.EqualsError).Equals(10, EqualsDecimalErros.EqualsSuccess);
    }

    public decimal NotEqualsSuccess { get; set; }

    public decimal EqualsError { get; set; }

    public decimal EqualsSuccess { get; set; }

    public decimal NotEqualsError { get; set; }
}