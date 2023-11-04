using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AddNotification;
using Notification.Notifications.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

public class AfterEnsureString<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    public AfterEnsureString(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    public AfterEnsureString<TEntity> ForContext(Expression<Func<TEntity, string>> expression)
    {
        _notificationInfo.PropInfo.MemberName = ResultService.TranslateLambda(expression);
        return this;
    }

    /// <summary>
    /// Falso para registrar falhas
    /// </summary>
    /// <param name=""></param>
    /// <param name="failureModel"></param>
    /// <returns></returns>
    public AfterEnsureString<TEntity> Must(Func<string, bool> func, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: !func(_notificationInfo.PropInfo.Value),
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }

    public AfterEnsureString<TEntity> NotNullOrEmpty(FailureModel failureModel)
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

    public AfterEnsureString<TEntity> Equals(string value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !string.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterEnsureString<TEntity> NotEquals(string value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: string.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterEnsureString<TEntity> EmailAddress(FailureModel failureModel)
    {
        if (_notificationInfo.PropInfo.Value == null)
        {
            return this;
        }

        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !Regex.IsMatch(_notificationInfo.PropInfo.Value, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"),
                notificationInfo: _notificationInfo,
                erro: failureModel
            );
    }

    public AfterEnsureString<TEntity> MaximumLenght(int maxLenght, FailureModel failureModel)
    {
        return AddNotificationService
             .AddFailure(
                 current: this,
                 notificationContext: _notificationContext,
                 includeNotification: !(_notificationInfo.PropInfo.Value?.Length <= maxLenght),
                 notificationInfo: _notificationInfo,
                 erro: failureModel
             );
    }

    public AfterEnsureString<TEntity> MinimumLenght(int minlenght, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: !(_notificationInfo.PropInfo.Value?.Length >= minlenght),
               notificationInfo: _notificationInfo,
               erro: failureModel
           );
    }
}