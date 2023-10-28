using Newtonsoft.Json.Linq;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenInt : AfterValidationWhen, IAfterValidationWhen
{
    public AfterValidationWhenInt(NotificationContext notificationContext, NotificationInfo notificationInfo) : base(notificationContext, notificationInfo)
    {
    }

    public AddNotificationService<AfterValidationWhenInt> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenInt>(
            notificationContext: _notificationContext,
            includeNotification: ruleFor,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenInt> IsNull()
    {
        return new AddNotificationService<AfterValidationWhenInt>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == null,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenInt> IsEquals(long? value)
    {
        return new AddNotificationService<AfterValidationWhenInt>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == value,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenInt Is(bool ruleFor, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: ruleFor,
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }

    public AddNotificationService<AfterValidationWhenInt> IsZero()
    {
        return new AddNotificationService<AfterValidationWhenInt>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == 0,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenInt IsZero(FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: _notificationInfo.PropInfo.Value == 0,
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }

    public AfterValidationWhenInt IsNull(FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: _notificationInfo.PropInfo.Value == null,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterValidationWhenInt IsEquals(long? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: _notificationInfo.PropInfo.Value == value,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AddNotificationService<AfterValidationWhenInt> IsGreaterThan(int value)
    {
        return new AddNotificationService<AfterValidationWhenInt>(
            notificationContext: _notificationContext,
            includeNotification: (int)_notificationInfo.PropInfo.Value > value,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenInt> IsLessThan(int value)
    {
        return new AddNotificationService<AfterValidationWhenInt>(
            notificationContext: _notificationContext,
            includeNotification: (int)_notificationInfo.PropInfo.Value < value,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenInt> IsOutOfRange(int minvalue, int maxValue)
    {
        return new AddNotificationService<AfterValidationWhenInt>(
            notificationContext: _notificationContext,
            includeNotification: (int)_notificationInfo.PropInfo.Value < minvalue || (int)_notificationInfo.PropInfo.Value > maxValue,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenInt IsGreaterThan(int value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: (int)_notificationInfo.PropInfo.Value > value,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterValidationWhenInt IsLessThan(int value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: (int)_notificationInfo.PropInfo.Value < value,
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterValidationWhenInt IsOutOfRange(int minvalue, int maxValue, FailureModel failureModel)
    {
        return AddNotificationService
         .AddFailure(
             current: this,
             notificationContext: _notificationContext,
             includeNotification: (int)_notificationInfo.PropInfo.Value < minvalue || (int)_notificationInfo.PropInfo.Value > maxValue,
             notificationInfo: _notificationInfo,
             erro: failureModel
         );
    }
}