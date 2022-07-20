// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace Makc2022.Layer1.Apps.WebApp.Logging
{
    /// <summary>
    /// Настройка логирования в веб-приложении.
    /// </summary>
    public class WebAppLoggingSetting : LoggingSetting
    {
        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        /// <param name="builder">Построитель веб-приложения.</param>
        public void Configure(WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override Logger CreateLogger()
        {
            return LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        }

        #endregion Protected methods
    }
}
