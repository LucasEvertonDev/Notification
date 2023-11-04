using FluentAssertions;
using Notification.Extensions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Entities.ValidationEnsureByType.list;

namespace Notification.Tests.NotificationTests.ValidationsByType;

public class ValidationEnsureList : Notifiable
{

    [Fact]
    public void ValidateMust()
    {
        var failures = new MustModel().GetFailures();

        failures.Should().Contain(MustListErros.MustError);
        failures.Should().NotContain(MustListErros.MustSuccess);
    }

    [Fact]
    public void ValidateNull()
    {
        var failures = new NullModel().GetFailures();

        failures.Should().Contain(NullListErros.NullError);
        failures.Should().NotContain(NullListErros.NullSuccess);
    }


    [Fact]
    public void ValidateNotEmpty()
    {
        var failures = new NotEmptyModel().GetFailures();

        failures.Should().Contain(NotEmptyListErros.NotEmptyError);

        failures.Should().NotContain(NotEmptyListErros.NotEmptySuccess);
    }
}
