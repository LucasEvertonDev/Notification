using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenInt : AfterValidationWhen, IAfterValidationWhen
{
    protected object _currentvalue { get; set; }

    public AfterValidationWhenInt(NotificationContext notificationContext, NotificationInfo notificationInfo) : base(notificationContext, notificationInfo)
    {
        _currentvalue = notificationInfo.PropInfo.Value;
    }

    public AddNotificationService<AfterValidationWhenInt> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenInt>(_notificationContext, ruleFor, _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenInt> IsGreaterThan(int value)
    {
        return new AddNotificationService<AfterValidationWhenInt>(_notificationContext, (int)_currentvalue > value, _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenInt> IsLessThan(int value)
    {
        return new AddNotificationService<AfterValidationWhenInt>(_notificationContext, (int)_currentvalue < value, _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenInt> IsOutOfRange(int minvalue, int maxValue)
    {
        return new AddNotificationService<AfterValidationWhenInt>(_notificationContext, (int)_currentvalue < minvalue || (int)_currentvalue > maxValue, _notificationInfo);
    }
}