using FluentAssertions;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.Obj;

namespace Notification.Tests.NotificationTests.ValidationsByType;

public class ValidationEnsureObject : Notifiable
{

    [Fact]
    public void ValidateMust()
    {
        var failures = new MustModel().GetFailures();

        failures.Should().Contain(MustObjectErros.MustError);
        failures.Should().NotContain(MustObjectErros.MustSuccess);
    }

    [Fact]
    public void ValidateNull()
    {
        var failures = new NullModel().GetFailures();

        failures.Should().Contain(NullObjectErros.NullError);
        failures.Should().NotContain(NullObjectErros.NullSuccess);
    }
}
