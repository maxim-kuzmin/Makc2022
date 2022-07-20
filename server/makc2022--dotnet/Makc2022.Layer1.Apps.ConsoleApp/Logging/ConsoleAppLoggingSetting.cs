// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace Makc2022.Layer1.Apps.ConsoleApp.Logging
{
    /// <summary>
    /// Настройка логирования в консольном приложении.
    /// </summary>
    public class ConsoleAppLoggingSetting : LoggingSetting
    {
        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void Configure(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory()) //From NuGet Package Microsoft.Extensions.Configuration.Json
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            services.AddLogging(loggingBuilder =>
            {
                // configure Logging with NLog
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog(config);
            });
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override Logger CreateLogger()
        {
            return LogManager.GetCurrentClassLogger();
        }

        #endregion Protected methods
    }
}
