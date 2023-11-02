using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Boolean;

public class EqualsBooleanErros
{
    public static FailureModel EqualsSuccess { get; set; } = new FailureModel("EqualsSuccess", "Esse erro não deve acontecer");
    public static FailureModel EqualsError { get; set; } = new FailureModel("EqualsError", "Esse erro deve acontecer");
    public static FailureModel NotEqualsSuccess { get; set; } = new FailureModel("NotEqualsSuccess", "Esse erro não deve acontecer");
    public static FailureModel NotEqualsError { get; set; } = new FailureModel("NotEqualsError", "Esse erro deve acontecer");
}

public class EqualsModel : Notifiable<EqualsModel>
{
    public EqualsModel(bool? valor = false)
    {
        Ensure(valor).ForContext(e => e.NotEqualsError).NotEquals(false, EqualsBooleanErros.NotEqualsError);

        Ensure(valor).ForContext(e => e.NotEqualsSuccess).NotEquals(true, EqualsBooleanErros.NotEqualsSuccess);

        Ensure(valor).ForContext(e => e.EqualsError).Equals(true, EqualsBooleanErros.EqualsError);

        Ensure(valor).ForContext(e => e.EqualsError).Equals(false, EqualsBooleanErros.EqualsSuccess);
    }

    public bool NotEqualsSuccess { get; set; }

    public bool EqualsError { get; set; }

    public bool EqualsSuccess { get; set; }

    public bool NotEqualsError { get; set; }
}