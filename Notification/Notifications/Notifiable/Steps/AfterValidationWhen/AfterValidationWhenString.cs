using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using System.Text.RegularExpressions;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenString : AfterValidationWhen, IAfterValidationWhen
{
    protected string _currentvalue { get; set; }

    public AfterValidationWhenString(NotificationContext notificationContext, NotificationInfo notificationInfo) : base(notificationContext, notificationInfo)
    {
        _currentvalue = notificationInfo.PropInfo.Value;
    }

    public AddNotificationService<AfterValidationWhenString> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, ruleFor, _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenString> IsInvalidEmail()
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, !Regex.IsMatch(_currentvalue, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"), _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenString> IsNullOrEmpty()
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, string.IsNullOrEmpty(_currentvalue), _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenString> MinLength(int minLenght)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, _currentvalue?.Length < minLenght, _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenString> MaxLenght(int maxLenght)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, _currentvalue?.Length > maxLenght, _notificationInfo);
    }

    public AfterValidationWhenString Is(bool ruleFor, FailureModel failureModel)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, ruleFor, _notificationInfo).AddFailure(failureModel);
    }

    public AfterValidationWhenString IsInvalidEmail(FailureModel failureModel)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, !Regex.IsMatch(_currentvalue, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"), _notificationInfo).AddFailure(failureModel);
    }

    public AfterValidationWhenString IsNullOrEmpty(FailureModel failureModel)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, string.IsNullOrEmpty(_currentvalue), _notificationInfo).AddFailure(failureModel);
    }

    public AfterValidationWhenString MinLength(int minLenght, FailureModel failureModel)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, _currentvalue?.Length < minLenght, _notificationInfo).AddFailure(failureModel);
    }

    public AfterValidationWhenString MaxLenght(int maxLenght, FailureModel failureModel)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, _currentvalue?.Length > maxLenght, _notificationInfo).AddFailure(failureModel);
    }
}
