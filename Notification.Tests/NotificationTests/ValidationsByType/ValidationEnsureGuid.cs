using FluentAssertions;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.guid;

namespace Notification.Tests.NotificationTests.ValidationsByType;

public class ValidationEnsureGuid : Notifiable
{

    [Fact]
    public void ValidateMust()
    {
        var failures = new MustModel().GetFailures();

        failures.Should().Contain(MustGuidErros.MustError);
        failures.Should().NotContain(MustGuidErros.MustSuccess);
    }

    [Fact]
    public void ValidateNull()
    {
        var failures = new NullModel().GetFailures();

        failures.Should().Contain(NullGuidErros.NullError);
        failures.Should().NotContain(NullGuidErros.NullSuccess);
    }

    [Fact]
    public void ValidateEquals()
    {
        var failures = new EqualsModel().GetFailures();

        failures.Should().Contain(EqualsGuidErros.EqualsError);
        failures.Should().Contain(EqualsGuidErros.NotEqualsError);

        failures.Should().NotContain(EqualsGuidErros.EqualsSuccess);
        failures.Should().NotContain(EqualsGuidErros.NotEqualsSuccess);
    }
}
