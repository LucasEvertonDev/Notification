using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenBool : AfterValidationWhen, IAfterValidationWhen
{
    public AfterValidationWhenBool(NotificationContext notificationContext, NotificationInfo notificationInfo) : base(notificationContext, notificationInfo)
    {
    }

    public AddNotificationService<AfterValidationWhenBool> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenBool>(
            notificationContext: _notificationContext,
            includeNotification: ruleFor,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenBool> IsNull()
    {
        return new AddNotificationService<AfterValidationWhenBool>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == null,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenBool Is(bool ruleFor, FailureModel failureModel)
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

    public AfterValidationWhenBool IsNull(FailureModel failureModel)
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

    public AddNotificationService<AfterValidationWhenBool> IsFalse()
    {
        return new AddNotificationService<AfterValidationWhenBool>(
            notificationContext: _notificationContext,
            includeNotification: !_notificationInfo.PropInfo.Value,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenBool IsTrue(FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: _notificationInfo.PropInfo.Value,
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }

}