using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.String;

public class EqualsStringErros
{
    public static FailureModel EqualsSuccess { get; set; } = new FailureModel("EqualsSuccess", "Esse erro não deve acontecer");
    public static FailureModel EqualsError { get; set; } = new FailureModel("EqualsError", "Esse erro deve acontecer");
    public static FailureModel NotEqualsSuccess { get; set; } = new FailureModel("NotEqualsSuccess", "Esse erro não deve acontecer");
    public static FailureModel NotEqualsError { get; set; } = new FailureModel("NotEqualsError", "Esse erro deve acontecer");
}

public class EqualsModel : Notifiable<EqualsModel>
{
    public EqualsModel(string valor = "10")
    {
        Ensure(valor).ForContext(e => e.NotEqualsError).NotEquals("10", EqualsStringErros.NotEqualsError);

        Ensure(valor).ForContext(e => e.NotEqualsSuccess).NotEquals("11", EqualsStringErros.NotEqualsSuccess);

        Ensure(valor).ForContext(e => e.EqualsError).Equals("11", EqualsStringErros.EqualsError);

        Ensure(valor).ForContext(e => e.EqualsError).Equals("10", EqualsStringErros.EqualsSuccess);
    }

    public string NotEqualsSuccess { get; set; }

    public string EqualsError { get; set; }

    public string EqualsSuccess { get; set; }

    public string NotEqualsError { get; set; }
}