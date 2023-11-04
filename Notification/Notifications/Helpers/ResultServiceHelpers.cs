using System.Linq.Expressions;
using System.Reflection;
using Notification.Exceptions;
using Notification.Notifications.Enum;

namespace Notification.Notifications.Helpers;

public static class ResultServiceHelpers
{
    public static Dictionary<object, object[]> GetFailures(Result result)
    {
        Dictionary<object, object[]> dic = new ();

        var agrupados = result.GetFailures().OrderByDescending(a => (int)a.NotificationInfo.EntityInfo.NotificationType)
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

    public static string TranslateLambda(dynamic lambda)
    {
        List<string> names = new ();
        if (lambda.Body is MemberExpression memberSelectorExpression)
        {
            var property = memberSelectorExpression.Member as PropertyInfo ??
                throw new ValidationPropertWithOutGetSetException("É preciso adicionar {get; set;} a sua prop");

            names.Add(property.Name);

            dynamic expression = memberSelectorExpression;

            while (ResultServiceHelpers.ContainsProperty(expression, "Expression"))
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

                    if (ResultServiceHelpers.ContainsProperty(argumento, "Expression"))
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

    private static bool ContainsProperty(object obj, string name) => obj.GetType().GetProperty(name) != null;
}