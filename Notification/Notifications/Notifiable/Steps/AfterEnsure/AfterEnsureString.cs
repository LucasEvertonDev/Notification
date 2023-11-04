using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Notification.Notifications.Context;
using Notification.Notifications.Helpers;
using Notification.Notifications.Notifiable.Steps.AddNotification;

namespace Notification.Notifications.Notifiable.Steps.AfterEnsure;

/// <summary>
/// Representa a etapa após ensure para propriedades list.
/// </summary>
/// <typeparam name="TEntity">Reprensenta a entidade que implementou a classe notifiable.</typeparam>
public class AfterEnsureString<TEntity>
{
    private readonly NotificationInfo _notificationInfo;
    private readonly NotificationContext _notificationContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="AfterEnsureString{TEntity}"/> class.
    /// Construtor para continuar a arquiterura de steps.
    /// </summary>
    /// <param name="notificationContext">Indica o contexto em que será registrada as notificações.</param>
    /// <param name="notificationInfo">Representa as informações adicionais para compor o contexto da notificação.</param>
    public AfterEnsureString(NotificationContext notificationContext, NotificationInfo notificationInfo)
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
    public AfterEnsureString<TEntity> ForContext(Expression<Func<TEntity, string>> expression)
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
    public AfterEnsureString<TEntity> Must(Func<string, bool> func, FailureModel failureModel)
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
    ///  Garante que o valor nunca seja nulo ou vazio. Caso contrário irá registrar falha.
    /// </summary>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureString<TEntity> NotNullOrEmpty(FailureModel failureModel)
    {
        return AddNotificationService
          .AddFailure(
              current: this,
              notificationContext: _notificationContext,
              includeNotification: string.IsNullOrEmpty(_notificationInfo.PropInfo.Value),
              notificationInfo: _notificationInfo,
              erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor SEJA equivalente ao recebido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="value">Parâmetro para o valor que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureString<TEntity> Equals(string value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: !string.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor NÃO seja equivalente ao recebido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="value">Parâmetro para o valor que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureString<TEntity> NotEquals(string value, FailureModel failureModel)
    {
        return AddNotificationService
            .AddFailure(
                current: this,
                notificationContext: _notificationContext,
                includeNotification: string.Equals(_notificationInfo.PropInfo.Value, value),
                notificationInfo: _notificationInfo,
                erro: failureModel);
    }

    /// <summary>
    /// Garante que o valor seja um email válido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
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
                erro: failureModel);
    }

    /// <summary>
    /// Garante que a string tenha tamanho válido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="maxLenght">Parâmetro para o valor que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureString<TEntity> MaximumLenght(int maxLenght, FailureModel failureModel)
    {
        return AddNotificationService
             .AddFailure(
                 current: this,
                 notificationContext: _notificationContext,
                 includeNotification: !(_notificationInfo.PropInfo.Value?.Length <= maxLenght),
                 notificationInfo: _notificationInfo,
                 erro: failureModel);
    }

    /// <summary>
    /// Garante que a string tenha tamanho válido. Caso contrário ira registrar falha.
    /// </summary>
    /// <param name="minlenght">Parâmetro para o valor que será usado na comparação.</param>
    /// <param name="failureModel">Objeto de falha que deve ser criado em arquivo de erros.</param>
    /// <returns>Retorna novas possibilidades de validações.</returns>
    public AfterEnsureString<TEntity> MinimumLenght(int minlenght, FailureModel failureModel)
    {
        return AddNotificationService
           .AddFailure(
               current: this,
               notificationContext: _notificationContext,
               includeNotification: !(_notificationInfo.PropInfo.Value?.Length >= minlenght),
               notificationInfo: _notificationInfo,
               erro: failureModel);
    }
}