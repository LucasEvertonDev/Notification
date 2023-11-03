using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.guid;

public class EqualsGuidErros
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
        Guid? valor = new Guid("a9a5c5a1-ab9b-4058-8b81-7b0ef880cda9");
        Guid valorVazio = new Guid();

        Ensure(valor).ForContext(e => e.NotEqualsError).NotEquals(valor, EqualsGuidErros.NotEqualsError);

        Ensure(valor).ForContext(e => e.NotEqualsSuccess).NotEquals(valorVazio, EqualsGuidErros.NotEqualsSuccess);

        Ensure(valor).ForContext(e => e.EqualsError).Equals(valorVazio, EqualsGuidErros.EqualsError);

        Ensure(valor).ForContext(e => e.EqualsSuccess).Equals(valor, EqualsGuidErros.EqualsSuccess);
    }

    public Guid NotEqualsSuccess { get; set; }

    public Guid EqualsError { get; set; }

    public Guid EqualsSuccess { get; set; }

    public Guid NotEqualsError { get; set; }
}