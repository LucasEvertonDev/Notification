﻿using Notification.Notifications;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Steps.AfterValidationWhen;

namespace Notification.Notifications.Notifiable.Steps.AddNotification;

public class AddNotificationService<TOut> where TOut : IAfterValidationWhen
{
    private readonly NotificationContext _notificationContext;
    private readonly bool _includeNotification;
    private NotificationInfo _notificationInfo { get; set; }

    public AddNotificationService(NotificationContext notificationContext, bool includeNotification, NotificationInfo notificationInfo)
    {
        _notificationContext = notificationContext;
        _includeNotification = includeNotification;
        _notificationInfo = notificationInfo;
    }

    public TOut AddFailure(FailureModel erro)
    {
        if (_includeNotification)
        {
            _notificationContext.AddNotification(new NotificationModel(erro, _notificationInfo));
        }

        return (TOut)Activator.CreateInstance(typeof(TOut), _notificationContext, _notificationInfo);
    }
}

public class AddNotificationService
{
    public static TOut AddFailure<TOut>(TOut current, NotificationContext notificationContext, bool includeNotification, NotificationInfo notificationInfo, FailureModel erro)
    {
        if (includeNotification)
        {
            notificationContext.AddNotification(new NotificationModel(erro, notificationInfo));
        }

        return current;
    }
}