using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Datetime;

public class MustDateTimeErros
{
    public static FailureModel MustSuccess { get; set; } = new FailureModel("MustSuccess", "Esse erro não deve acontecer");

    public static FailureModel MustError { get; set; } = new FailureModel("MustError", "Esse erro deve acontecer");
}

public class MustModel : Notifiable<MustModel>
{
    public MustModel()
    {
        DateTime valorErro = DateTime.Parse("2023-10-01");
        DateTime? valorSucesso = DateTime.Parse("2023-10-15");

        Ensure(valorErro).ForContext(e => e.MustError).Must((valor) =>
        {
            return valor == DateTime.Parse("2023-10-15");
        }, MustDateTimeErros.MustError);

        Ensure(valorSucesso).ForContext(e => e.MustSuccess).Must((valor) =>
        {
            return valor.GetValueOrDefault() == DateTime.Parse("2023-10-15");
        }, MustDateTimeErros.MustSuccess);
    }

    public DateTime MustSuccess { get; set; }

    public DateTime MustError { get; set; }
}
