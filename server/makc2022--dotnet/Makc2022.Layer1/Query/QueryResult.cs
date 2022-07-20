// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Query
{
    /// <summary>
    /// Результат запроса.
    /// </summary>
    public class QueryResult
    {
        #region Properties

        /// <summary>
        /// Признак успешности выполнения.
        /// </summary>
        public bool IsOk { get; set; }

        /// <summary>
        /// Сообщения об ошибках.
        /// </summary>
        public HashSet<string> ErrorMessages { get; } = new HashSet<string>();

        /// <summary>
        /// Код запроса.
        /// </summary>
        public string QueryCode { get; set; } = QueryHelper.CreateQueryCode();

        /// <summary>
        /// Сообщения об успехах.
        /// </summary>
        public HashSet<string> SuccessMessages { get; } = new HashSet<string>();

        /// <summary>
        /// Сообщения о предупреждениях.
        /// </summary>
        public HashSet<string> WarningMessages { get; } = new HashSet<string>();

        #endregion Properties
    }
}
