using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Entities.ValidationEnsureByType.Datetime
{
    public class MinValueDateTimeErros
    {
        public static FailureModel MinValueSuccess { get; set; } = new FailureModel("MinValueSuccess", "Esse erro não deve acontecer");

        public static FailureModel MinValueError { get; set; } = new FailureModel("MinValueError", "Esse erro deve acontecer");

    }

    public class MinValueModel : Notifiable<MinValueModel>
    {
        public MinValueModel()
        {
            DateTime? valor1 = DateTime.MinValue;
            DateTime? valor2 = DateTime.Parse("2023-10-15");

            Ensure(valor1).ForContext(e => e.MinValueError).NotMinValue(MinValueDateTimeErros.MinValueError);

            Ensure(valor2).ForContext(e => e.MinValueSuccess).NotMinValue(MinValueDateTimeErros.MinValueSuccess);
        }

        public DateTime MinValueSuccess { get; set; }

        public DateTime MinValueError { get; set; }
    }

}
