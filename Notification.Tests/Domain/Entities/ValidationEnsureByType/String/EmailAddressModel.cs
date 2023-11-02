using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.String;

public class EmailAddressStringErros
{
    public static FailureModel EmailAddressSuccess { get; set; } = new FailureModel("EmailAddressSuccess", "Esse erro não deve acontecer");

    public static FailureModel EmailAddressError { get; set; } = new FailureModel("EmailAddressError", "Esse erro deve acontecer");
}

public class EmailAddressModel : Notifiable<EmailAddressModel>
{
    public EmailAddressModel(string emailInvalido = "123", string emailValido = "teste@teste.com")
    {
        Ensure(emailInvalido).ForContext(e => e.EmailAddressError).EmailAddress(EmailAddressStringErros.EmailAddressError);

        Ensure(emailValido).ForContext(e => e.EmailAddressSuccess).EmailAddress(EmailAddressStringErros.EmailAddressSuccess);
    }

    public string EmailAddressSuccess { get; set; }

    public string EmailAddressError { get; set; }
}

