﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Operation.Handlers
{
    /// <summary>
    /// Интерфейс обработчика операции без входных и выходных данных.
    /// </summary>
    public interface IOperationWithoutInputAndOutputHandler : IOperationHandler
    {
        #region Properties

        /// <summary>
        /// Результат выполнения операции.
        /// </summary>
        OperationResult? OperationResult { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Обработать начало.
        /// </summary>
        /// <param name="operationCode">Код операции.</param>
        void OnStart(string? operationCode = null);

        /// <summary>
        /// Обработать успех.
        /// </summary>
        public void OnSuccess();

        /// <summary>
        /// Обработать успех с результатом.
        /// </summary>
        /// <param name="operationResult">Результат операции.</param>
        void OnSuccessWithResult(OperationResult operationResult);

        #endregion Methods
    }
}
