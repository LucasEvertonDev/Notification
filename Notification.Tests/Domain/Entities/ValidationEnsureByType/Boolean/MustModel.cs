using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Boolean;

public class MustBooleanErros
{
    public static FailureModel MustSuccess { get; set; } = new FailureModel("MustSuccess", "Esse erro não deve acontecer");

    public static FailureModel MustError { get; set; } = new FailureModel("MustError", "Esse erro deve acontecer");
}

public class MustModel : Notifiable<MustModel>
{
    public MustModel(bool valor = false)
    {
        Ensure(valor).ForContext(e => e.MustError).Must((valor) =>
        {
            return valor.GetValueOrDefault();
        }, MustBooleanErros.MustError);

        Ensure(valor).ForContext(e => e.MustSuccess).Must((valor) =>
        {
            return !valor.GetValueOrDefault();
        }, MustBooleanErros.MustSuccess);
    }

    public bool MustSuccess { get; set; }

    public bool MustError { get; set; }
}
