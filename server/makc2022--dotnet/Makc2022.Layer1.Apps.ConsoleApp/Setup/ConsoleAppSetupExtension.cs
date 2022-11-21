// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Makc2022.Layer1.Apps.ConsoleApp.Setup
{
    /// <summary>
    /// Расширение настройки консольного приложения.
    /// </summary>
    public static class ConsoleAppLoggingExtension
    {
        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public static void Configure(this IServiceCollection services)
        {
            var config = AppHelper.CreateConfiguration();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();

                loggingBuilder.SetMinimumLevel(LogLevel.Trace);

                loggingBuilder.AddNLog(config);
            });
        }

        #endregion Public methods
    }
}
