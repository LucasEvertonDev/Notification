using FluentAssertions;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.Decimal;

namespace Notification.Tests.NotificationTests.ValidationsByType;

public class ValidationEnsureDecimal : Notifiable
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

        failures.Should().Contain(MustDecimalErros.MustError);
        failures.Should().NotContain(MustDecimalErros.MustSuccess);
    }

    [Fact]
    public void ValidateNull()
    {
        var failures = new NullModel().GetFailures();

        failures.Should().Contain(NullDecimalErros.NullError);
        failures.Should().NotContain(NullDecimalErros.NullSuccess);
    }

    [Fact]
    public void ValidateEquals()
    {
        var failures = new EqualsModel().GetFailures();

        failures.Should().Contain(EqualsDecimalErros.EqualsError);
        failures.Should().Contain(EqualsDecimalErros.NotEqualsError);

        failures.Should().NotContain(EqualsDecimalErros.EqualsSuccess);
        failures.Should().NotContain(EqualsDecimalErros.NotEqualsSuccess);
    }

    [Fact]
    public void ValidateBetween()
    {
        var failures = new BetweenModel().GetFailures();

        failures.Should().Contain(BetweenDecimalErros.BetweenError);

        failures.Should().NotContain(BetweenDecimalErros.BetweenSuccess);
    }
}
