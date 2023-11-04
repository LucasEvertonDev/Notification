using System.Linq.Expressions;
using Notification.Notifications.Context;
using Notification.Notifications.Helpers;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

/// <summary>
/// Representa a etapa após ensure para propriedades booleanas.
/// </summary>
/// <typeparam name="TEntity">Reprensenta a entidade que implementou a classe notifiable.</typeparam>
public class AfterEnsureBool<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="AfterEnsureBool{TEntity}"/> class.
    /// Construtor para continuar a arquiterura de steps.
    /// </summary>
    /// <param name="notificationContext">Indica o contexto em que será registrada as notificações.</param>
    /// <param name="notificationInfo">Representa as informações adicionais para compor o contexto da notificação.</param>
    public AfterEnsureBool(NotificationContext notificationContext, NotificationInfo notificationInfo)
    {
        _notificationInfo = notificationInfo;
        _notificationContext = notificationContext;
    }

    /// <summary>
    /// Associa as validações a determinada propriedade da classe.
    /// Em caso de uso deve ser informado após o ensure.
    /// </summary>
    /// <param name="expression">Lambda indicando a propriedade da classe que irá receber o valor a ser validado.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureBool<TEntity> ForContext(Expression<Func<TEntity, bool>> expression)
    {
        _notificationInfo.PropInfo.MemberName = ResultServiceHelpers.TranslateLambda(expression);
        return this;
    }

    /// <summary>
    ///  Garante validações personalizadas por meio de arrow function. Quando o retorno for false irá registrar falha.
    /// </summary>
    /// <param name="func">Arrow function que deve retornar um booleano.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureBool<TEntity> Must(Func<bool?, bool> func, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: !func(_notificationInfo.PropInfo.Value),
               notificationInfo: _notificationInfo,
               erro: failureModel);
    }

    /// <summary>
    ///  Garante que o valor nunca seja nulo. Caso contrário irá registrar falha.
    /// </summary>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureBool<TEntity> NotNull(FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: _notificationInfo.PropInfo.Value == null,
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor SEJA equivalente ao recebido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="value">Parâmetro para o valor que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureBool<TEntity> Equals(bool? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !bool.Equals(_notificationInfo.PropInfo.Value, value.GetValueOrDefault()),
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor NÃO seja equivalente ao recebido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="value">Parâmetro para o valor que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureBool<TEntity> NotEquals(bool? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: bool.Equals(_notificationInfo.PropInfo.Value, value.GetValueOrDefault()),
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }
}
