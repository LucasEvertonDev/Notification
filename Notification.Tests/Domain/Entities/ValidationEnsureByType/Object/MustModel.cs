using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Obj;

public class MustObjectErros
{
    public static FailureModel MustSuccess { get; set; } = new FailureModel("MustSuccess", "Esse erro não deve acontecer");

    public static FailureModel MustError { get; set; } = new FailureModel("MustError", "Esse erro deve acontecer");
}

public class MustModel : Notifiable<MustModel>
{
    public MustModel()
    {
        var teste = new Teste() { Prop1 = "2" };

        Ensure(teste).ForContext(e => e.MustError).Must((Teste valor) =>
        {
            return valor.Prop1 == "3";
        }, MustObjectErros.MustError);

        Ensure(teste).ForContext(e => e.MustSuccess).Must((Teste  valor) =>
        {
            return valor.Prop1 == "2";
        }, MustObjectErros.MustSuccess);
    }

    public Teste MustSuccess { get; set; }

    public Teste MustError { get; set; }
}

public class Teste : Notifiable<Teste>
{
    public string Prop1 { get; set; }
}