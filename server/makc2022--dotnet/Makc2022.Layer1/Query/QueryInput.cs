// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Query
{
    /// <summary>
    /// Входные данные запроса.
    /// </summary>
    public class QueryInput
    {
        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            return new List<string>();
        }

        #endregion Public methods
    }
}
