using Notification.Exceptions;
using Notification.Notifications.Context;
using Notification.Notifications.Enum;
using Notification.Notifications.Notifiable.Notifications.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace Notification.Notifications.Services;

public class ResultService
{
    public ResultService(NotificationContext Notification)
    {
        NotificationContext = Notification;
    }

    private NotificationContext NotificationContext { get; set; }

    public void Failure<T>(FailureModel failure) where T : INotifiable
    {
        var notificationType = NotificationType.BusinessNotification;
        if (typeof(T).GetInterfaces().ToList().Exists(x => x.Name == nameof(INotifiableModel)))
        {
            notificationType = NotificationType.DomainNotification;
        }

        var notificationInfo = new NotificationInfo(new PropInfo(), new EntityInfo()
        {
            NotificationType = notificationType,
            Name = typeof(T).Name,
            Namespace = typeof(T).Namespace
        });

        NotificationContext.AddNotification(new NotificationModel(failure, notificationInfo));
    }

    public void Failure<T>(Expression<Func<T, dynamic>> exp, FailureModel failure) where T : INotifiableModel
    {
        var notificationType = NotificationType.BusinessNotification;
        if (typeof(T).GetInterfaces().ToList().Exists(x => x.Name == nameof(INotifiableModel)))
        {
            notificationType = NotificationType.DomainNotification;
        }

        var notificationInfo = new NotificationInfo(
            new PropInfo()
            {
                Value = null,
                MemberName = TranslateLambda(exp)
            },
            new EntityInfo()
            {
                NotificationType = notificationType,
                Name = typeof(T).Name,
                Namespace = typeof(T).Namespace
            });

        NotificationContext.AddNotification(new NotificationModel(failure, notificationInfo));
    }

    private static bool ContainsProperty(object obj, string name) => obj.GetType().GetProperty(name) != null;

    public static string TranslateLambda(dynamic lambda)
    {
        List<string> names = new();
        if (lambda.Body is MemberExpression memberSelectorExpression)
        {
            var property = memberSelectorExpression.Member as PropertyInfo ??
                throw new ValidationPropertWithOutGetSetException("É preciso adicionar {get; set;} a sua prop");

            names.Add(property.Name);

            dynamic expression = memberSelectorExpression;

            while (ContainsProperty(expression, "Expression"))
            {
                if (expression.Expression is MemberExpression subMemberExpression)
                {
                    names.Add(subMemberExpression.Type.Name);
                    expression = expression.Expression;
                }
                else if (expression.Expression is ParameterExpression subParameterExpression)
                {
                    names.Add(subParameterExpression.Type.Name);
                    expression = expression.Expression;
                }
                else if (expression.Expression is MethodCallExpression)
                {
                    var argumento = expression.Expression.Arguments[0];

                    if (ContainsProperty(argumento, "Expression"))
                    {
                        if (argumento.Expression is ConstantExpression subContantExpression)
                        {
                            var valor = subContantExpression.Value;
                            names.Add($"[{valor.GetType().GetField("i").GetValue(valor)}]");
                        }
                    }
                    else if (argumento is ConstantExpression argContantExpression)
                    {
                        names.Add($"[{argContantExpression.Value}]");
                    }

                    if (expression.Expression.Object is MemberExpression subMethodMemberExpression)
                    {
                        names.Add(subMethodMemberExpression.Member.Name);
                    }
                    expression = expression.Expression.Object;
                }
            }
        }

        names.Reverse(0, names.Count);

        return string.Join(".", names).Replace(".[", "[");
    }

    public static Dictionary<object, object[]> GetFailures(Result result)
    {
        Dictionary<object, object[]> dic = new();

        var agrupados = result.GetFailures.OrderByDescending(a => (int)a.NotificationInfo.EntityInfo.NotificationType)
            .Select(a => new
            {
                key = a.NotificationInfo.PropInfo.MemberName ?? nameof(NotificationType.BusinessNotification),
                a.Error.message,
            })
            .GroupBy(a => a.key).Select(a => new
            {
                key = a.Key,
                messages = a.Select(a => a.message).ToArray()
            })
            .ToList();

        agrupados.ForEach(i =>
        {
            dic.Add(i.key, i.messages);
        });

        return dic;
    }
}
