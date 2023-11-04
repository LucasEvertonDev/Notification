using System.Linq.Expressions;
using Notification.Notifications.Context;
using Notification.Notifications.Helpers;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

/// <summary>
/// Representa a etapa após ensure para propriedades Datetime.
/// </summary>
/// <typeparam name="TEntity">Reprensenta a entidade que implementou a classe notifiable.</typeparam>
public class AfterEnsureDatetime<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="AfterEnsureDatetime{TEntity}"/> class.
    /// Construtor para continuar a arquiterura de steps.
    /// </summary>
    /// <param name="notificationContext">Indica o contexto em que será registrada as notificações.</param>
    /// <param name="notificationInfo">Representa as informações adicionais para compor o contexto da notificação.</param>
    public AfterEnsureDatetime(NotificationContext notificationContext, NotificationInfo notificationInfo)
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
    public AfterEnsureDatetime<TEntity> ForContext(Expression<Func<TEntity, DateTime?>> expression)
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
    public AfterEnsureDatetime<TEntity> Must(Func<DateTime?, bool> func, FailureModel failureModel)
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
    public AfterEnsureDatetime<TEntity> NotNull(FailureModel failureModel)
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
    ///  Garante que o valor nunca seja igual a DateTime.MinValue Caso contrário irá registrar falha.
    /// </summary>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureDatetime<TEntity> NotMinValue(FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: DateTime.Equals(_notificationInfo.PropInfo.Value, DateTime.MinValue),
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor SEJA equivalente ao recebido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="value">Parâmetro para o valor que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureDatetime<TEntity> Equals(DateTime? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !DateTime.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor NÃO seja equivalente ao recebido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="value">Parâmetro para o valor que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureDatetime<TEntity> NotEquals(DateTime? value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: DateTime.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor esteja no intervalor informado. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="start">Parâmetro para o valor de início que será usado na comparação.</param>
    /// <param name="end">Parâmetro para o valor de fim que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureDatetime<TEntity> Between(DateTime start, DateTime end, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: _notificationInfo.PropInfo.Value <= start || _notificationInfo.PropInfo.Value >= end,
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }
}