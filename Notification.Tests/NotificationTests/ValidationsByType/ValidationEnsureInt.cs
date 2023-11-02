using FluentAssertions;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.Int;

namespace Notification.Tests.NotificationTests.ValidationsByType;

public class ValidationEnsureInt : Notifiable
{
    [Fact]
    public void ValidateGreaterThan()
    {
        var failures = new GreaterThanModel().GetFailures();

        failures.Should().Contain(GreaterThanErros.GreaterThanOrEqualToError);
        failures.Should().Contain(GreaterThanErros.GreaterThanError);


        failures.Should().NotContain(GreaterThanErros.GreaterThanOrEqualTo);
        failures.Should().NotContain(GreaterThanErros.GreaterThanOrEqualToSuccess);
        failures.Should().NotContain(GreaterThanErros.GreaterThanSuccess);
    }

    [Fact]
    public void ValidateLessThan()
    {
        var failures = new LessThanModel().GetFailures();

        failures.Should().Contain(LessThanErros.LessThanOrEqualToError);
        failures.Should().Contain(LessThanErros.LessThanError);


        failures.Should().NotContain(LessThanErros.LessThanOrEqualTo);
        failures.Should().NotContain(LessThanErros.LessThanOrEqualToSuccess);
        failures.Should().NotContain(LessThanErros.LessThanSuccess);
    }

    [Fact]
    public void ValidateMust()
    {
        var failures = new MustModel().GetFailures();

        failures.Should().Contain(MustIntErros.MustError);
        failures.Should().NotContain(MustIntErros.MustSuccess);
    }

    [Fact]
    public void ValidateNull()
    {
        var failures = new NullModel().GetFailures();

        failures.Should().Contain(NullIntErros.NullError);
        failures.Should().NotContain(NullIntErros.NullSuccess);
    }

    [Fact]
    public void ValidateEquals()
    {
        var failures = new EqualsModel().GetFailures();

        failures.Should().Contain(EqualsIntErros.EqualsError);
        failures.Should().Contain(EqualsIntErros.NotEqualsError);

        failures.Should().NotContain(EqualsIntErros.EqualsSuccess);
        failures.Should().NotContain(EqualsIntErros.NotEqualsSuccess);
    }

    [Fact]
    public void ValidateBetween()
    {
        var failures = new BetweenModel().GetFailures();

        failures.Should().Contain(BetweenIntErros.BetweenError);

        failures.Should().NotContain(BetweenIntErros.BetweenSuccess);
    }
}
