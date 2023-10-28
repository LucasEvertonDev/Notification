using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using System.Text.RegularExpressions;

namespace Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenString : AfterValidationWhen, IAfterValidationWhen
{
    public AfterValidationWhenString(NotificationContext notificationContext, NotificationInfo notificationInfo) : base(notificationContext, notificationInfo)
    {
    }

    public AddNotificationService<AfterValidationWhenString> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenString>(
            notificationContext: _notificationContext,
            includeNotification: ruleFor,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenString> IsInvalidEmail()
    {
        return new AddNotificationService<AfterValidationWhenString>(
            notificationContext: _notificationContext,
            includeNotification: !Regex.IsMatch(_notificationInfo.PropInfo.Value, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"),
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenString> IsNullOrEmpty()
    {
        return new AddNotificationService<AfterValidationWhenString>(
            notificationContext: _notificationContext,
            includeNotification: string.IsNullOrEmpty(_notificationInfo.PropInfo.Value),
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenString> MinLength(int minLenght)
    {
        return new AddNotificationService<AfterValidationWhenString>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value?.Length < minLenght,
            notificationInfo: _notificationInfo);
    }

    public AddNotificationService<AfterValidationWhenString> MaxLenght(int maxLenght)
    {
        return new AddNotificationService<AfterValidationWhenString>(
            notificationContext: _notificationContext,
            includeNotification: _notificationInfo.PropInfo.Value?.Length > maxLenght,
            notificationInfo: _notificationInfo);
    }

    public AfterValidationWhenString Is(bool ruleFor, FailureModel failureModel)
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

    public AfterValidationWhenString IsInvalidEmail(FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !Regex.IsMatch(_notificationInfo.PropInfo.Value, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterValidationWhenString IsNullOrEmpty(FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: string.IsNullOrEmpty(_notificationInfo.PropInfo.Value),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterValidationWhenString MinLength(int minLenght, FailureModel failureModel)
    {
        return AddNotificationService
             .AddFailure(
                 current: this,
                 notificationContext: _notificationContext,
                 includeNotification: _notificationInfo.PropInfo.Value?.Length < minLenght,
                 notificationInfo: _notificationInfo,
                 erro: failureModel
             );
    }

    public AfterValidationWhenString MaxLenght(int maxLenght, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: _notificationInfo.PropInfo.Value?.Length > maxLenght,
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }
}
