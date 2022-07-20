// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Makc2022.Layer1.Serialization.Json;
using Makc2022.Layer1.Setting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer1.Query
{
    /// <summary>
    /// Обработчик запроса.
    /// </summary>
    public abstract class QueryHandler : IQueryHandler
    {
        #region Properties

        private string? QueryName { get; set; }

        private string? Title { get; set; }

        /// <summary>
        /// Ресурс запроса.
        /// </summary>
        protected IQueryResource QueryResource { get; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// Функция получения сообщений об ошибках.
        /// </summary>
        protected Func<Exception, IEnumerable<string>>? FunctionToGetErrorMessages { get; set; }

        /// <summary>
        /// Код запроса.
        /// </summary>
        protected string? QueryCode { get; private set; }

        /// <summary>
        /// Параметры настройки.
        /// </summary>
        protected IOptionsMonitor<SettingOptions> SettingOptions { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="queryName">Имя запроса.</param>
        /// <param name="queryResource">Ресурс запроса.</param>
        /// <param name="logger">Регистратор.</param>
        /// <param name="settingOptions">Параметры настройки.</param>
        public QueryHandler(
            string queryName,
            IQueryResource queryResource,
            ILogger logger,
            IOptionsMonitor<SettingOptions> settingOptions)
        {
            QueryName = queryName;
            QueryResource = queryResource;
            Logger = logger;
            SettingOptions = settingOptions;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void OnError(Exception? exception = null)
        {
            if (exception != null)
            {
                InitQueryResult(false);
            }

            string errorMessage;

            var queryResult = GetQueryResult();

            var errorMessages = GetErrorMessages(exception);

            if (errorMessages != null && errorMessages.Any())
            {
                if (queryResult != null)
                {
                    queryResult.ErrorMessages.UnionWith(errorMessages);
                }

                errorMessage = string.Join(". ", errorMessages).Replace("!.", "!").Replace("?.", "?");
            }
            else
            {
                errorMessage = QueryResource.GetErrorMessageForDefault();

                if (queryResult != null)
                {
                    queryResult.ErrorMessages.Add(errorMessage);
                }
            }


            if (Logger != null)
            {
                string titleForError = QueryResource.GetTitleForError();

                Logger.LogError(
                    exception,
                    "{Title}{titleForError}. {errorMessage}",
                    Title,
                    titleForError,
                    errorMessage);
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Сделать в начале запроса.
        /// </summary>
        /// <param name="queryCode">Код запроса.</param>
        protected virtual void DoOnStart(string? queryCode)
        {
            QueryCode = string.IsNullOrWhiteSpace(queryCode) ? QueryHelper.CreateQueryCode() : queryCode;

            string titleForQueryCode = QueryResource.GetTitleForQueryCode();

            if (!string.IsNullOrWhiteSpace(queryCode))
            {
                QueryCode = queryCode;
            }

            Title = $"{QueryName}. {titleForQueryCode}: {QueryCode}. ";

            var settingOptions = SettingOptions.CurrentValue;

            if (settingOptions.LogLevel == LogLevel.Debug)
            {
                LogDebugOnStart();
            }
        }

        /// <summary>
        /// Сделать в случае успешного выполнения запроса.
        /// </summary>
        /// <param name="functionToGetSuccessMessages">Функция получения сообщений об успехах.</param>
        /// <param name="functionToGetWarningMessages">Функция получения сообщений о предупреждениях.</param>
        protected void DoOnSuccess(
            Func<IEnumerable<string>>? functionToGetSuccessMessages,
            Func<IEnumerable<string>>? functionToGetWarningMessages
            )
        {
            var queryResult = GetQueryResult();

            if (queryResult != null && queryResult.IsOk)
            {
                if (functionToGetSuccessMessages != null)
                {
                    var messages = functionToGetSuccessMessages();

                    if (messages != null && messages.Any())
                    {
                        queryResult.SuccessMessages.UnionWith(messages);
                    }
                }

                if (functionToGetWarningMessages != null)
                {
                    var messages = functionToGetWarningMessages();

                    if (messages != null && messages.Any())
                    {
                        queryResult.WarningMessages.UnionWith(messages);
                    }
                }

                var settingOptions = SettingOptions.CurrentValue;

                if (settingOptions.LogLevel == LogLevel.Debug)
                {
                    LogDebugOnSuccess();
                }
            }
            else
            {
                OnError();
            }
        }

        /// <summary>
        /// Получить входные данные запроса.
        /// </summary>
        /// <returns>Входные данные запроса.</returns>
        protected abstract object? GetQueryInput();

        /// <summary>
        /// Получить результат выполнения запроса.
        /// </summary>
        /// <returns>Результат выполнения запроса.</returns>
        protected abstract QueryResult? GetQueryResult();

        /// <summary>
        /// Инициализировать результат запроса.
        /// </summary>
        /// <param name="isOk">Признак успешности выполнения.</param>
        protected abstract void InitQueryResult(bool isOk);

        #endregion Protected methods

        #region Private methods

        private IEnumerable<string>? GetErrorMessages(Exception? exception)
        {
            IEnumerable<string>? result = null;

            if (FunctionToGetErrorMessages != null && exception != null)
            {
                result = FunctionToGetErrorMessages.Invoke(exception);
            }

            if (result == null || !result.Any())
            {
                string? errorMessage = null;

                if (exception is CommonException)
                {
                    errorMessage = exception.Message;
                }

                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    result = new[] { errorMessage };
                }
            }

            return result;
        }

        private void LogDebugOnStart()
        {
            if (Logger != null)
            {
                object? queryInput = GetQueryInput();

                string titleForStart = QueryResource.GetTitleForStart();
                string titleForInput = QueryResource.GetTitleForInput();
                string? valueForInput = queryInput?.SerializeToJson(JsonSerializationOptions.ForLogger);

                valueForInput = !string.IsNullOrWhiteSpace(valueForInput)
                    ? $". {titleForInput}: {valueForInput}"
                    : string.Empty;

                Logger.LogDebug(
                    "{Title}{titleForStart}{valueForInput}",
                    Title,
                    titleForStart,
                    valueForInput);
            }
        }

        private void LogDebugOnSuccess()
        {
            if (Logger != null)
            {
                var queryResult = GetQueryResult();

                string titleForSuccess = QueryResource.GetTitleForSuccess();
                string titleForResult = QueryResource.GetTitleForResult();
                string? valueForResult = queryResult?.SerializeToJson(JsonSerializationOptions.ForLogger);

                Logger.LogDebug(
                    "{Title}{titleForSuccess}. {titleForResult}: {valueForResult}",
                    Title,
                    titleForSuccess,
                    titleForResult,
                    valueForResult);
            }
        }

        #endregion Private methods
    }
}
