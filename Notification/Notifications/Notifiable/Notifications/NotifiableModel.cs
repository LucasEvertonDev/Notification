using Notification.Notifications;
using Notification.Notifications.Context;
using Notification.Notifications.Notifiable.Notifications.Base;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Notifications.Notifiable.Notifications;

public partial class Notifiable<TEntity> : INotifiableModel
{
    [JsonIgnore]
    protected Result Result { get; set; }

    [JsonIgnore]
    protected PropInfo CurrentProp { get; set; }

    public Notifiable()
    {
        Result = new Result(new NotificationContext());
        CurrentProp = new PropInfo();
    }

    [JsonIgnore]
    protected EntityInfo EntityInfo => new EntityInfo()
    {
        Name = typeof(TEntity).Name,
        Namespace = typeof(TEntity).Namespace
    };

    public List<NotificationModel> GetNotifications()
    {
        return Result.GetContext().Notifications.ToList();
    }

    public List<FailureModel> GetFailures()
    {
        return Result.GetContext().Notifications.Select(a => a.Error).ToList();
    }

    public bool HasFailure()
    {
        return GetFailures().Any();
    }

    private void SetValue(dynamic lambda, dynamic value)
    {
        CurrentProp = new PropInfo();

        var memberSelectorExpression = lambda.Body as MemberExpression;
        if (memberSelectorExpression != null)
        {
            var property = memberSelectorExpression.Member as PropertyInfo;
            if (property != null)
            {
                property.SetValue(this, value, null);
                CurrentProp.MemberName = value is INotifiableModel ? EntityInfo.Name : string.Concat(EntityInfo.Name, ".", property.Name);
            }
            else
            {
                throw new Exception("É preciso adicionar {get; set;} a sua prop");
            }
        }
        CurrentProp.Value = value;
    }
}