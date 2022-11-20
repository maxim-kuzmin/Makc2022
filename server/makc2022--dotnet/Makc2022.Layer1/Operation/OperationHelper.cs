// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Operation
{
    /// <summary>
    /// Помощник операции.
    /// </summary>
    public class OperationHelper
    {
        #region Public methods

        /// <summary>
        /// Создать код операции.
        /// </summary>
        /// <returns>Код операции.</returns>
        public static string CreateOperationCode()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        #endregion Public methods
    }
}
