// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Makc2022.Layer1.Apps.WebApp.Setup
{
    /// <summary>
    /// Расширение настройки веб-приложения.
    /// </summary>
    public static class WebAppSetupExtension
    {
        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public static void Configure(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();

            builder.Host.UseNLog();
        }

        #endregion Public methods
    }
}
