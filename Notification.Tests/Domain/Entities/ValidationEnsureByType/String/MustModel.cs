using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.String;

public class MustStringErros
{
    public static FailureModel MustSuccess { get; set; } = new FailureModel("MustSuccess", "Esse erro não deve acontecer");

    public static FailureModel MustError { get; set; } = new FailureModel("MustError", "Esse erro deve acontecer");
}

public class MustModel : Notifiable<MustModel>
{
    public MustModel(string valor1 = "texto1", string valor2 = "texto2")
    {
        Ensure(valor1).ForContext(e => e.MustError).Must((valor) =>
        {
            return valor == "texto";
        }, MustStringErros.MustError);

        Ensure(valor2).ForContext(e => e.MustSuccess).Must((valor) =>
        {
            return valor == "texto2";
        }, MustStringErros.MustSuccess);
    }

    public string MustSuccess { get; set; }

    public string MustError { get; set; }
}
