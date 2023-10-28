using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenDecimal : AfterValidationWhen, IAfterValidationWhen
{
    public AfterValidationWhenDecimal(NotificationContext notificationContext, NotificationInfo notificationInfo) : base(notificationContext, notificationInfo)
    {
    }

    public AddNotificationService<AfterValidationWhenDecimal> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenDecimal>(
            notificationContext: _notificationContext,
            includeNotification: ruleFor,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenDecimal> IsNull()
    {
        return new AddNotificationService<AfterValidationWhenDecimal>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == null,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenDecimal> IsEquals(long? value)
    {
        return new AddNotificationService<AfterValidationWhenDecimal>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == value,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenDecimal Is(bool ruleFor, FailureModel failureModel)
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

    public AddNotificationService<AfterValidationWhenDecimal> IsZero()
    {
        return new AddNotificationService<AfterValidationWhenDecimal>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == 0,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenDecimal IsZero(FailureModel failureModel)
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

    public AfterValidationWhenDecimal IsNull(FailureModel failureModel)
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

    public AfterValidationWhenDecimal IsEquals(long? value, FailureModel failureModel)
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

    public AddNotificationService<AfterValidationWhenDecimal> IsGreaterThan(int value)
    {
        return new AddNotificationService<AfterValidationWhenDecimal>(
            notificationContext: _notificationContext,
            includeNotification: (int)_notificationInfo.PropInfo.Value > value,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenDecimal> IsLessThan(int value)
    {
        return new AddNotificationService<AfterValidationWhenDecimal>(
            notificationContext: _notificationContext,
            includeNotification: (int)_notificationInfo.PropInfo.Value < value,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenDecimal> IsOutOfRange(int minvalue, int maxValue)
    {
        return new AddNotificationService<AfterValidationWhenDecimal>(
            notificationContext: _notificationContext,
            includeNotification: (int)_notificationInfo.PropInfo.Value < minvalue || (int)_notificationInfo.PropInfo.Value > maxValue,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenDecimal IsGreaterThan(int value, FailureModel failureModel)
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

    public AfterValidationWhenDecimal IsLessThan(int value, FailureModel failureModel)
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

    public AfterValidationWhenDecimal IsOutOfRange(int minvalue, int maxValue, FailureModel failureModel)
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