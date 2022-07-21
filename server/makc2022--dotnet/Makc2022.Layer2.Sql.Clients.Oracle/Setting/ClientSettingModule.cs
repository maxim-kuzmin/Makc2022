// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer2.Sql.Clients.Oracle.Setting
{
    /// <summary>
    /// Модуль клиента.
    /// </summary>
    public class ClientSettingModule : CommonModule
    {
        #region Properties

        private IConfigurationSection ConfigurationSection { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configurationSection">Раздел конфигурации.</param>
        public ClientSettingModule(IConfigurationSection configurationSection)
        {
            ConfigurationSection = configurationSection;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ClientSettingOptions>(ConfigurationSection);

            services.AddSingleton<IClientService>(x => new ClientService(
                x.GetRequiredService<IOptionsMonitor<ClientSettingOptions>>()
                ));            
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IClientService),
                typeof(ClientSettingOptions)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(ClientSettingOptions)
            };
        }

        #endregion Protected methods
    }
}
