// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2022.Layer1.Operation
{
    /// <summary>
    /// Интерфейс обработчика операции.
    /// </summary>
    public interface IOperationHandler
    {
        #region Methods

        /// <summary>
        /// Обработать ошибку.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        void OnError(Exception exception);

        #endregion Methods
    }
}
