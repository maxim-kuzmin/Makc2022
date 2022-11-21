// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using NLog;

namespace Makc2022.Layer1.Apps.ConsoleApp
{
    /// <summary>
    /// Обработчик ведения журнала консольного приложения.
    /// </summary>
    public class ConsoleAppHandler : AppHandler
    {
        #region Protected methods

        /// <inheritdoc/>
        protected sealed override Logger CreateLogger()
        {
            return LogManager.GetCurrentClassLogger();
        }

        #endregion Protected methods
    }
}
