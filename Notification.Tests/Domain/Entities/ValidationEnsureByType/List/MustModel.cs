using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.list;

public class MustListErros
{
    public static FailureModel MustSuccess { get; set; } = new FailureModel("MustSuccess", "Esse erro não deve acontecer");

    public static FailureModel MustError { get; set; } = new FailureModel("MustError", "Esse erro deve acontecer");
}

public class MustModel : Notifiable<MustModel>
{
    public MustModel()
    {
        var prop = new Teste { Prop1 = "Teste1" };

        var list = new List<Teste>() { prop };

        Ensure(list).ForContext(e => e.MustError).Must((List<Teste> valor) =>
        {
            return valor.Contains(new Teste { Prop1 = "234445" });
        }, MustListErros.MustError);

        Ensure(list).ForContext(e => e.MustSuccess).Must((List<Teste> valor) =>
        {
            return valor.Contains(prop);
        }, MustListErros.MustSuccess);
    }

    public List<Teste> MustSuccess { get; set; }

    public List<Teste> MustError { get; set; }
}


public class Teste : Notifiable<Teste>
{
    public string Prop1 { get; set; }
}