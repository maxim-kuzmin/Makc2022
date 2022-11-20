// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Operation
{
    /// <summary>
    /// Результат операции с выходными данными.
    /// </summary>
    /// <typeparam name="TOutput">Тип выходных данных.</typeparam>
    public class OperationResultWithOutput<TOutput> : OperationResult
    {
        #region Properties

        /// <summary>
        /// Выходные данные.
        /// </summary>
        public TOutput? Output { get; set; }

        #endregion Properties
    }
}
