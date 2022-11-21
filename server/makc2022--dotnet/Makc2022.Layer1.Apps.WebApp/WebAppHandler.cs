// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using NLog;
using NLog.Web;

namespace Makc2022.Layer1.Apps.WebApp
{
    /// <summary>
    /// Обработчик ведения журнала веб-приложения.
    /// </summary>
    public class WebAppHandler : AppHandler
    {
        #region Protected methods

        /// <inheritdoc/>
        protected sealed override Logger CreateLogger()
        {
            return LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        }

        #endregion Protected methods
    }
}
