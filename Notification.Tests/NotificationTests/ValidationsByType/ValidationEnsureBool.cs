using FluentAssertions;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.Boolean;

namespace Notification.Tests.NotificationTests.ValidationsByType;

public class ValidationEnsureBool : Notifiable
{

    [Fact]
    public void ValidateMust()
    {
        var failures = new MustModel().GetFailures();

        failures.Should().Contain(MustBooleanErros.MustError);
        failures.Should().NotContain(MustBooleanErros.MustSuccess);
    }

    [Fact]
    public void ValidateNull()
    {
        var failures = new NullModel().GetFailures();

        failures.Should().Contain(NullBooleanErros.NullError);
        failures.Should().NotContain(NullBooleanErros.NullSuccess);
    }

    [Fact]
    public void ValidateEquals()
    {
        var failures = new EqualsModel().GetFailures();

        failures.Should().Contain(EqualsBooleanErros.EqualsError);
        failures.Should().Contain(EqualsBooleanErros.NotEqualsError);

        failures.Should().NotContain(EqualsBooleanErros.EqualsSuccess);
        failures.Should().NotContain(EqualsBooleanErros.NotEqualsSuccess);
    }
}
