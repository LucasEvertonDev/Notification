using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Datetime;

public class EqualsDateTimeErros
{
    public static FailureModel EqualsSuccess { get; set; } = new FailureModel("EqualsSuccess", "Esse erro não deve acontecer");
    public static FailureModel EqualsError { get; set; } = new FailureModel("EqualsError", "Esse erro deve acontecer");
    public static FailureModel NotEqualsSuccess { get; set; } = new FailureModel("NotEqualsSuccess", "Esse erro não deve acontecer");
    public static FailureModel NotEqualsError { get; set; } = new FailureModel("NotEqualsError", "Esse erro deve acontecer");
}

public class EqualsModel : Notifiable<EqualsModel>
{
    public EqualsModel()
    {
        DateTime? valor = DateTime.Parse("2023-10-01");

        Ensure(valor).ForContext(e => e.NotEqualsError).NotEquals(DateTime.Parse("2023-10-01"), EqualsDateTimeErros.NotEqualsError);

        Ensure(valor).ForContext(e => e.NotEqualsSuccess).NotEquals(DateTime.Parse("2023-10-11"), EqualsDateTimeErros.NotEqualsSuccess);

        Ensure(valor).ForContext(e => e.EqualsError).Equals(DateTime.Parse("2023-10-11"), EqualsDateTimeErros.EqualsError);

        Ensure(valor).ForContext(e => e.EqualsError).Equals(DateTime.Parse("2023-10-01"), EqualsDateTimeErros.EqualsSuccess);
    }

    public DateTime NotEqualsSuccess { get; set; }

    public DateTime EqualsError { get; set; }

    public DateTime EqualsSuccess { get; set; }

    public DateTime NotEqualsError { get; set; }
}