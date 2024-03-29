﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Setup;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer1.Operation.Handlers
{
    /// <summary>
    /// Обработчик операции с выходными данными.
    /// </summary>
    /// <typeparam name="TOperationOutput">Тип выходных данных операции.</typeparam>    
    public class OperationWithOutputHandler<TOperationOutput> : OperationHandler, IOperationWithOutputHandler<TOperationOutput>
    {
        #region Properties

        /// <summary>
        /// Функция преобразования вывода операции.
        /// </summary>
        protected Func<TOperationOutput, TOperationOutput?>? FunctionToTransformOperationOutput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        protected Func<TOperationOutput, IEnumerable<string>>? FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        protected Func<TOperationOutput, IEnumerable<string>>? FunctionToGetWarningMessages { get; set; }

        /// <inheritdoc/>
        public OperationResultWithOutput<TOperationOutput>? OperationResult { get; private set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public OperationWithOutputHandler(
            string operationName,
            IOperationResource operationResource,
            ILogger logger,
            IOptionsMonitor<SetupOptions> setupOptions)
            : base(operationName, operationResource, logger, setupOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void OnStart(string? operationCode = null)
        {
            DoOnStart(operationCode);
        }

        /// <inheritdoc/>
        public void OnSuccess(TOperationOutput? operationOutput)
        {
            InitOperationResult(true);

            if (FunctionToTransformOperationOutput != null && operationOutput != null)
            {
                operationOutput = FunctionToTransformOperationOutput.Invoke(operationOutput);
            }

            if (OperationResult != null && operationOutput != null)
            {
                OperationResult.Output = operationOutput;
            }

            Func<IEnumerable<string>>? functionToGetSuccessMessages = null;

            if (FunctionToGetSuccessMessages != null && operationOutput != null)
            {
                functionToGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(operationOutput);
            }

            Func<IEnumerable<string>>? functionToGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null && operationOutput != null)
            {
                functionToGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(operationOutput);
            }

            DoOnSuccess(functionToGetSuccessMessages, functionToGetWarningMessages);
        }

        /// <inheritdoc/>
        public void OnSuccessWithResult(OperationResultWithOutput<TOperationOutput> operationResult)
        {
            OperationResult = operationResult;

            DoOnSuccess(null, null);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override object? GetOperationInput()
        {
            return null;
        }

        /// <inheritdoc/>
        protected sealed override OperationResult? GetOperationResult()
        {
            return OperationResult;
        }

        /// <inheritdoc/>
        protected sealed override void InitOperationResult(bool isOk)
        {
            OperationResult = new OperationResultWithOutput<TOperationOutput>
            {
                IsOk = isOk,
            };

            if (!string.IsNullOrWhiteSpace(OperationCode))
            {
                OperationResult.OperationCode = OperationCode;
            }
        }

        #endregion Protected methods
    }
}
