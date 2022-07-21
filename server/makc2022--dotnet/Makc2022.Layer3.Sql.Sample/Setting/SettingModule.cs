// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer3.Sql.Sample.Setting
{
    /// <summary>
    /// Модуль настройки.
    /// </summary>
    public class SettingModule : CommonModule
    {
        #region Properties

        private IConfigurationSection ConfigurationSection { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configurationSection">Раздел конфигурации.</param>
        public SettingModule(IConfigurationSection configurationSection)
        {
            ConfigurationSection = configurationSection;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SettingOptions>(ConfigurationSection);
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(SettingOptions),
            };
        }

        #endregion Public methods
    }
}
