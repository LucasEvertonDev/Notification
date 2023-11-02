using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.String;

public class LenghtStringErros
{
    public static FailureModel MinLenghtSuccess { get; set; } = new FailureModel("MinLenghtSuccess", "Esse erro não deve acontecer");

    public static FailureModel MinLenghtError { get; set; } = new FailureModel("MinLenghtError", "Esse erro deve acontecer");

    public static FailureModel MaxLenghtSuccess { get; set; } = new FailureModel("MaxLenghtSuccess", "Esse erro não deve acontecer");

    public static FailureModel MaxLenghtError { get; set; } = new FailureModel("MaxLenghtError", "Esse erro deve acontecer");
}

public class LenghtModel : Notifiable<LenghtModel>
{
    public LenghtModel(string valor1 = "123")
    {
        Ensure(valor1).ForContext(e => e.MinLenghtError).MinimumLenght(5, LenghtStringErros.MinLenghtError);

        Ensure(valor1).ForContext(e => e.MinLenghtSuccess).MinimumLenght(2, LenghtStringErros.MinLenghtSuccess);

        Ensure(valor1).ForContext(e => e.MaxLenghtError).MaximumLenght(2, LenghtStringErros.MaxLenghtError);

        Ensure(valor1).ForContext(e => e.MaxLenghtSuccess).MaximumLenght(4, LenghtStringErros.MaxLenghtSuccess);
    }

    public string MinLenghtSuccess { get; set; }

    public string MinLenghtError { get; set; }

    public string MaxLenghtSuccess { get; set; }

    public string MaxLenghtError { get; set; }
}

