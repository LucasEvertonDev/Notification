using FluentAssertions;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.String;

namespace Notification.Tests.NotificationTests.ValidationsByType;

public class ValidationEnsureString : Notifiable
{
    

   
    [Fact]
    public void ValidateMust()
    {
        var failures = new MustModel().GetFailures();

        failures.Should().Contain(MustStringErros.MustError);
        failures.Should().NotContain(MustStringErros.MustSuccess);
    }

    [Fact]
    public void ValidateNull()
    {
        var failures = new NullModel().GetFailures();

        failures.Should().Contain(NullStringErros.NullError);
        failures.Should().NotContain(NullStringErros.NullSuccess);
    }

    [Fact]
    public void ValidateEquals()
    {
        var failures = new EqualsModel().GetFailures();

        failures.Should().Contain(EqualsStringErros.EqualsError);
        failures.Should().Contain(EqualsStringErros.NotEqualsError);

        failures.Should().NotContain(EqualsStringErros.EqualsSuccess);
        failures.Should().NotContain(EqualsStringErros.NotEqualsSuccess);
    }

    [Fact]
    public void ValidateEmailAddres()
    {
        var failures = new EmailAddressModel().GetFailures();

        failures.Should().Contain(EmailAddressStringErros.EmailAddressError);

        failures.Should().NotContain(EmailAddressStringErros.EmailAddressSuccess);
    }

    [Fact]
    public void ValidateLenght()
    {
        var failures = new LenghtModel().GetFailures();

        failures.Should().Contain(LenghtStringErros.MinLenghtError);
        failures.Should().Contain(LenghtStringErros.MaxLenghtError);


        failures.Should().NotContain(LenghtStringErros.MaxLenghtSuccess);
        failures.Should().NotContain(LenghtStringErros.MinLenghtSuccess);
    }
}
