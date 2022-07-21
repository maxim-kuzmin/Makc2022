// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Makc2022.Layer5.Sql.GrpcServer.Protos.Pages.DummyMain.Item;
using Makc2022.Layer5.Sql.GrpcServer.Protos.Pages.DummyMain.List;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer5.Sql.GrpcClient.Setting
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
            services.AddSingleton(new CommonEnvironment());

            services.AddLocalization(x => x.ConfigureLocalization());

            services.Configure<SettingOptions>(ConfigurationSection);

            services.AddGrpcClient<DummyMainItemPage.DummyMainItemPageClient>((serviceProvider, options) =>
            {
                options.Address = new Uri(serviceProvider.GetRequiredService<IOptions<SettingOptions>>().Value.ServerUrl!);
            });

            services.AddGrpcClient<DummyMainListPage.DummyMainListPageClient>((serviceProvider, options) =>
            {
                options.Address = new Uri(serviceProvider.GetRequiredService<IOptions<SettingOptions>>().Value.ServerUrl!);
            });
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(CommonEnvironment),                
                typeof(DummyMainItemPage.DummyMainItemPageClient),
                typeof(DummyMainListPage.DummyMainListPageClient),                
                typeof(ILogger),
                typeof(IStringLocalizer),
                typeof(SettingOptions),
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(SettingOptions),
            };
        }

        #endregion Protected method
    }
}
