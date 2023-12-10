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

    public static string TranslateLambda(dynamic propertyExpression, bool useAlias = false, bool includeSourceName = false)
    {
        if (propertyExpression == null)
        {
            throw new ArgumentNullException(nameof(propertyExpression));
        }

        string propertyName = InterpretExpression(propertyExpression.Body, useAlias, includeSourceName);

        return propertyName;
    }

    private static string InterpretExpression(Expression expression, bool useAlias = false, bool includeSourceName = false)
    {
        switch (expression)
        {
            case MemberExpression memberExpression:
                return GetNestedPropertyNameSegment(memberExpression, useAlias, includeSourceName);

            case MethodCallExpression methodCallExpression when methodCallExpression.Method.Name == "get_Item" && methodCallExpression.Arguments.Count == 1:
                var indexExpression = (ConstantExpression)methodCallExpression.Arguments[0];
                return $"{InterpretExpression(methodCallExpression.Object, useAlias, includeSourceName)}[{indexExpression.Value}]";

            case UnaryExpression unaryExpression:
                return InterpretExpression(unaryExpression.Operand, useAlias, includeSourceName);

            case var exp when exp.NodeType == ExpressionType.Parameter:
                return exp.Type.Name;

            default:
                return string.Empty;
        }
    }

    private static string GetNestedPropertyNameSegment(MemberExpression memberExpression, bool useAlias = false, bool includeSourceName = false)
    {
        if (memberExpression.Expression is null)
        {
            return memberExpression.Member.Name;
        }

        string parentSegment = InterpretExpression(memberExpression.Expression, useAlias, includeSourceName);
        return parentSegment == string.Empty ? $"{memberExpression.Member.Name}" : $"{parentSegment}.{memberExpression.Member.Name}";
    }
}