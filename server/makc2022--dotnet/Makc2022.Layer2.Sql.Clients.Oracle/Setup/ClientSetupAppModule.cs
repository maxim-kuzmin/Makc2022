﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer2.Sql.Clients.Oracle.Setup
{
    /// <summary>
    /// Модуль настройки приложения клиента.
    /// </summary>
    public class ClientSetupAppModule : AppModule
    {
        #region Properties

        private IConfigurationSection ConfigurationSection { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configurationSection">Раздел конфигурации.</param>
        public ClientSetupAppModule(IConfigurationSection configurationSection)
        {
            ConfigurationSection = configurationSection;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ClientSetupOptions>(ConfigurationSection);

            services.AddSingleton<IClientService>(x => new ClientService(
                x.GetRequiredService<IOptionsMonitor<ClientSetupOptions>>()
                ));            
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IClientService),
                typeof(ClientSetupOptions)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(ClientSetupOptions)
            };
        }

        #endregion Protected methods
    }
}
