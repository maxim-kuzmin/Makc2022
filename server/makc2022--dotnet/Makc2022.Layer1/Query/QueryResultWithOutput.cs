// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Query
{
    /// <summary>
    /// Результат запроса с выходными данными.
    /// </summary>
    /// <typeparam name="TOutput">Тип выходных данных.</typeparam>
    public class QueryResultWithOutput<TOutput> : QueryResult
    {
        #region Properties

        /// <summary>
        /// Выходные данные.
        /// </summary>
        public TOutput? Output { get; set; }

        #endregion Properties
    }
}
