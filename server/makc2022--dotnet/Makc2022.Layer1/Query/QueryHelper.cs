// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Query
{
    /// <summary>
    /// Помощник запроса.
    /// </summary>
    public class QueryHelper
    {
        #region Public methods

        /// <summary>
        /// Создать код запроса.
        /// </summary>
        /// <returns>Код запроса.</returns>
        public static string CreateQueryCode()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        #endregion Public methods
    }
}
