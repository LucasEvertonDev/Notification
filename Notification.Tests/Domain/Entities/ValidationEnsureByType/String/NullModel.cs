using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.String;

public class NullStringErros
{
    public static FailureModel NullSuccess { get; set; } = new FailureModel("NullSuccess", "Esse erro não deve acontecer");

    public static FailureModel NullError { get; set; } = new FailureModel("NullError", "Esse erro deve acontecer");
}

public class NullModel : Notifiable<NullModel>
{
    public NullModel(string valorNulo = null, string valorNaoNulo = "2")
    {
        Ensure(valorNulo).ForContext(e => e.NullError).NotNullOrEmpty(NullStringErros.NullError);

        Ensure(valorNaoNulo).ForContext(e => e.NullSuccess).NotNullOrEmpty(NullStringErros.NullSuccess);
    }

    public string NullSuccess { get; set; }

    public string NullError { get; set; }
}
