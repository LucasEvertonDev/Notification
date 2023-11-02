using FluentAssertions;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.Datetime;

namespace Notification.Tests.NotificationTests.ValidationsByType;

public class ValidationEnsureDatetime : Notifiable
{

    [Fact]
    public void ValidateMust()
    {
        var failures = new MustModel().GetFailures();

        failures.Should().Contain(MustDateTimeErros.MustError);
        failures.Should().NotContain(MustDateTimeErros.MustSuccess);
    }

    [Fact]
    public void ValidateNull()
    {
        var failures = new NullModel().GetFailures();

        failures.Should().Contain(NullDateTimeErros.NullError);
        failures.Should().NotContain(NullDateTimeErros.NullSuccess);
    }

    [Fact]
    public void ValidateEquals()
    {
        var failures = new EqualsModel().GetFailures();

        failures.Should().Contain(EqualsDateTimeErros.EqualsError);
        failures.Should().Contain(EqualsDateTimeErros.NotEqualsError);

        failures.Should().NotContain(EqualsDateTimeErros.EqualsSuccess);
        failures.Should().NotContain(EqualsDateTimeErros.NotEqualsSuccess);
    }

    [Fact]
    public void ValidateBetween()
    {
        var failures = new BetweenModel().GetFailures();

        failures.Should().Contain(BetweenDateTimeErros.BetweenError);

        failures.Should().NotContain(BetweenDateTimeErros.BetweenSuccess);
    }

    [Fact]
    public void ValidateMinValue()
    {
        var failures = new MinValueModel().GetFailures();

        failures.Should().Contain(MinValueDateTimeErros.MinValueError);

        failures.Should().NotContain(MinValueDateTimeErros.MinValueSuccess);
    }
}
