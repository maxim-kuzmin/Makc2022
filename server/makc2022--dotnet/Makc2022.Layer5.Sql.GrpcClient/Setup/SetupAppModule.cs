// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Makc2022.Layer5.Sql.GrpcServer.Protos.Pages.DummyMain.Item;
using Makc2022.Layer5.Sql.GrpcServer.Protos.Pages.DummyMain.List;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer5.Sql.GrpcClient.Setup
{
    /// <summary>
    /// Модуль настройки приложения.
    /// </summary>
    public class SetupAppModule : AppModule
    {
        #region Properties

        private IConfigurationSection ConfigurationSection { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configurationSection">Раздел конфигурации.</param>
        public SetupAppModule(IConfigurationSection configurationSection)
        {
            ConfigurationSection = configurationSection;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(x => x.ConfigureLocalization());

            services.Configure<SetupOptions>(ConfigurationSection);

            services.AddGrpcClient<DummyMainItemPage.DummyMainItemPageClient>((serviceProvider, options) =>
            {
                options.Address = new Uri(serviceProvider.GetRequiredService<IOptions<SetupOptions>>().Value.ServerUrl!);
            });

            services.AddGrpcClient<DummyMainListPage.DummyMainListPageClient>((serviceProvider, options) =>
            {
                options.Address = new Uri(serviceProvider.GetRequiredService<IOptions<SetupOptions>>().Value.ServerUrl!);
            });
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(DummyMainItemPage.DummyMainItemPageClient),
                typeof(DummyMainListPage.DummyMainListPageClient),                
                typeof(ILogger),
                typeof(IStringLocalizer),
                typeof(SetupOptions),
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(SetupOptions),
            };
        }

        #endregion Protected method
    }
}
