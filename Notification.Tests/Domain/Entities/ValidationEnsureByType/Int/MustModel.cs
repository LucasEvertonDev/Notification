using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Int;

public class MustIntErros
{
    public static FailureModel MustSuccess { get; set; } = new FailureModel("MustSuccess", "Esse erro não deve acontecer");

    public static FailureModel MustError { get; set; } = new FailureModel("MustError", "Esse erro deve acontecer");
}

public class MustModel : Notifiable<MustModel>
{
    public MustModel()
    {
        Ensure(10).ForContext(e => e.MustError).Must((valor) =>
        {
            return valor == 20;
        }, MustIntErros.MustError);

        Ensure(11).ForContext(e => e.MustSuccess).Must((valor) =>
        {
            return valor == 11;
        }, MustIntErros.MustSuccess);
    }

    public long MustSuccess { get; set; }

    public long MustError { get; set; }
}
