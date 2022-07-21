// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Makc2022.Layer1.Converting;
using Makc2022.Layer1.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer1.Setting
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

            services.AddSingleton<ICommonResource>(x => new CommonResource(
                x.GetRequiredService<IStringLocalizer<CommonResource>>()
                ));

            services.AddSingleton<IConvertingResource>(x => new ConvertingResource(
                x.GetRequiredService<IStringLocalizer<ConvertingResource>>()
                ));

            services.AddSingleton<IQueryResource>(x => new QueryResource(
                x.GetRequiredService<IStringLocalizer<QueryResource>>()
                ));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(ICommonResource),
                typeof(IConvertingResource),
                typeof(IQueryResource),
                typeof(SettingOptions),
            };
        }

        #endregion Public methods
    }
}
