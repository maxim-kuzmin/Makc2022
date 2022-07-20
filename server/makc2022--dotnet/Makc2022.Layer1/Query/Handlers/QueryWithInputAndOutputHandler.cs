﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Setting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса с входными и выходными данными.
    /// </summary>
    /// <typeparam name="TQueryInput">Тип входных данных запроса.</typeparam>
    /// <typeparam name="TQueryOutput">Тип выходных данных запроса.</typeparam>    
    public class QueryWithInputAndOutputHandler<TQueryInput, TQueryOutput> : QueryHandler,
        IQueryWithInputAndOutputHandler<TQueryInput, TQueryOutput>
    {
        #region Properties

        /// <summary>
        /// Функция преобразования ввода запроса.
        /// </summary>
        protected Func<TQueryInput, TQueryInput>? FunctionToTransformQueryInput { get; set; }

        /// <summary>
        /// Функция преобразования вывода запроса.
        /// </summary>
        protected Func<TQueryOutput, TQueryOutput>? FunctionToTransformQueryOutput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        protected Func<TQueryInput, TQueryOutput, IEnumerable<string>>? FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        protected Func<TQueryInput, TQueryOutput, IEnumerable<string>>? FunctionToGetWarningMessages { get; set; }

        /// <inheritdoc/>
        public TQueryInput? QueryInput { get; private set; }

        /// <inheritdoc/>
        public QueryResultWithOutput<TQueryOutput>? QueryResult { get; private set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public QueryWithInputAndOutputHandler(
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
        public void OnStart(TQueryInput queryInput, string? queryCode = null)
        {
            QueryInput = FunctionToTransformQueryInput != null
                ? FunctionToTransformQueryInput.Invoke(queryInput)
                : queryInput;

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

            if (FunctionToGetSuccessMessages != null && QueryInput != null)
            {
                functionToGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(QueryInput, queryOutput);
            }

            Func<IEnumerable<string>>? functionToGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null && QueryInput != null)
            {
                functionToGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(QueryInput, queryOutput);
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
            return QueryInput;
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
