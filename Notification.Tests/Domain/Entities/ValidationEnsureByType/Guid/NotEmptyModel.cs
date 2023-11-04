using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.guid;

public class NotEmptyGuidErros
{
    public static FailureModel NotEmptySuccess { get; set; } = new FailureModel("NotEmptySuccess", "Esse erro não deve acontecer");
    public static FailureModel NotEmptyError { get; set; } = new FailureModel("NotEmptyError", "Esse erro deve acontecer");
}

public class NotEmptyModel : Notifiable<NotEmptyModel>
{
    public NotEmptyModel()
    {
        Guid? valor = new Guid("a9a5c5a1-ab9b-4058-8b81-7b0ef880cda9");
        Guid valorVazio = new();

        Ensure(valorVazio).ForContext(e => e.NotEmptyError).NotEmpty(NotEmptyGuidErros.NotEmptyError);

        Ensure(valor).ForContext(e => e.NotEmptySuccess).NotEmpty(NotEmptyGuidErros.NotEmptySuccess);
    }

    public Guid NotEmptyError { get; set; }

    public Guid NotEmptySuccess { get; set; }

}