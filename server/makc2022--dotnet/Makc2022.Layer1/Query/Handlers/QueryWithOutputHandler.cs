// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Setting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса с выходными данными.
    /// </summary>
    /// <typeparam name="TQueryOutput">Тип выходных данных запроса.</typeparam>    
    public class QueryWithOutputHandler<TQueryOutput> : QueryHandler, IQueryWithOutputHandler<TQueryOutput>
    {
        #region Properties

        /// <summary>
        /// Функция преобразования вывода запроса.
        /// </summary>
        protected Func<TQueryOutput, TQueryOutput>? FunctionToTransformQueryOutput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        protected Func<TQueryOutput, IEnumerable<string>>? FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        protected Func<TQueryOutput, IEnumerable<string>>? FunctionToGetWarningMessages { get; set; }

        /// <inheritdoc/>
        public QueryResultWithOutput<TQueryOutput>? QueryResult { get; private set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public QueryWithOutputHandler(
            string queryName,
            IQueryResource queryResource,
            ILogger logger,
            IOptionsMonitor<SettingOptions> settingOptions)
            : base(queryName, queryResource, logger, settingOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void OnStart(string? queryCode = null)
        {
            DoOnStart(queryCode);
        }

        /// <inheritdoc/>
        public void OnSuccess(TQueryOutput queryOutput)
        {
            InitQueryResult(true);

            if (FunctionToTransformQueryOutput != null)
            {
                queryOutput = FunctionToTransformQueryOutput.Invoke(queryOutput);
            }

            if (QueryResult != null)
            {
                QueryResult.Output = queryOutput;
            }

            Func<IEnumerable<string>>? functionToGetSuccessMessages = null;

            if (FunctionToGetSuccessMessages != null)
            {
                functionToGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(queryOutput);
            }

            Func<IEnumerable<string>>? functionToGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null)
            {
                functionToGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(queryOutput);
            }

            DoOnSuccess(functionToGetSuccessMessages, functionToGetWarningMessages);
        }

        /// <inheritdoc/>
        public void OnSuccessWithResult(QueryResultWithOutput<TQueryOutput> queryResult)
        {
            QueryResult = queryResult;

            DoOnSuccess(null, null);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override object? GetQueryInput()
        {
            return null;
        }

        /// <inheritdoc/>
        protected sealed override QueryResult? GetQueryResult()
        {
            return QueryResult;
        }

        /// <inheritdoc/>
        protected sealed override void InitQueryResult(bool isOk)
        {
            QueryResult = new QueryResultWithOutput<TQueryOutput>
            {
                IsOk = isOk,
            };

            if (!string.IsNullOrWhiteSpace(QueryCode))
            {
                QueryResult.QueryCode = QueryCode;
            }
        }

        #endregion Protected methods
    }
}
