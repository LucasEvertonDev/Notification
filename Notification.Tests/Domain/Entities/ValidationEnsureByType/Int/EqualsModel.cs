using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Int;

public class EqualsIntErros
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
        Ensure(10).ForContext(e => e.NotEqualsError).NotEquals(10, EqualsIntErros.NotEqualsError);

        Ensure(10).ForContext(e => e.NotEqualsSuccess).NotEquals(11, EqualsIntErros.NotEqualsSuccess);

        Ensure(10).ForContext(e => e.EqualsError).Equals(11, EqualsIntErros.EqualsError);

        Ensure(10).ForContext(e => e.EqualsError).Equals(10, EqualsIntErros.EqualsSuccess);
    }

    public long NotEqualsSuccess { get; set; }

    public long EqualsError { get; set; }

    public long EqualsSuccess { get; set; }

    public long NotEqualsError { get; set; }
}