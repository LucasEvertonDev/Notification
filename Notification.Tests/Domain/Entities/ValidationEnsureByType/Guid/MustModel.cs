using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.guid;

public class MustGuidErros
{
    public static FailureModel MustSuccess { get; set; } = new FailureModel("MustSuccess", "Esse erro não deve acontecer");

    public static FailureModel MustError { get; set; } = new FailureModel("MustError", "Esse erro deve acontecer");
}

public class MustModel : Notifiable<MustModel>
{
    public MustModel()
    {
        Guid valor = new Guid("a9a5c5a1-ab9b-4058-8b81-7b0ef880cda9");

        Ensure(valor).ForContext(e => e.MustError).Must((valor) =>
        {
            return valor.GetValueOrDefault() == Guid.NewGuid();
        }, MustGuidErros.MustError);

        Ensure(valor).ForContext(e => e.MustSuccess).Must((valor) =>
        {
            return valor.GetValueOrDefault() == valor;
        }, MustGuidErros.MustSuccess);
    }

    public Guid MustSuccess { get; set; }

    public Guid MustError { get; set; }
}
