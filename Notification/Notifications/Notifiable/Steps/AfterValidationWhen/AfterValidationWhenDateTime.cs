using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenDateTime : AfterValidationWhen, IAfterValidationWhen
{
    public AfterValidationWhenDateTime(NotificationContext notificationContext, NotificationInfo notificationInfo) : base(notificationContext, notificationInfo)
    {
    }

    public AddNotificationService<AfterValidationWhenDateTime> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenDateTime>(
            notificationContext: _notificationContext,
            includeNotification: ruleFor,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenDateTime> IsNull()
    {
        return new AddNotificationService<AfterValidationWhenDateTime>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == null,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenInt> IsMinValue()
    {
        return new AddNotificationService<AfterValidationWhenInt>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value == DateTime.MinValue,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenInt IsMinValue(FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: _notificationInfo.PropInfo.Value == DateTime.MinValue,
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }

    public AfterValidationWhenDateTime Is(bool ruleFor, FailureModel failureModel)
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

    public AfterValidationWhenDateTime IsNull(FailureModel failureModel)
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