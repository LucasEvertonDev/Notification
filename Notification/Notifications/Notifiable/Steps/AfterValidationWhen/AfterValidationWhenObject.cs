using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenObject : AfterValidationWhen, IAfterValidationWhen
{
    public AfterValidationWhenObject(NotificationContext notificationContext, NotificationInfo notificationInfo) : base(notificationContext, notificationInfo)
    {
    }

    public AddNotificationService<AfterValidationWhenObject> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenObject>(
            notificationContext: _notificationContext,
            includeNotification: ruleFor,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenObject> IsNull()
    {
        return new AddNotificationService<AfterValidationWhenObject>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == null,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenObject Is(bool ruleFor, FailureModel failureModel)
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

    public AfterValidationWhenObject IsNull(FailureModel failureModel)
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
}