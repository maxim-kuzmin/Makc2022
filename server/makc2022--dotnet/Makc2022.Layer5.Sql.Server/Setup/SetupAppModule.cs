// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Makc2022.Layer2.Sql.Common;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.List;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using IClientProviderForSqlServer = Makc2022.Layer2.Sql.Clients.SqlServer.IClientProvider;
using IDummyMainDomainItemGetOperationHandler = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get.IDomainItemGetOperationHandler;
using IDummyMainDomainListGetOperationHandler = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get.IDomainListGetOperationHandler;
using IDummyMainDomainService = Makc2022.Layer4.Sql.Domains.DummyMain.IDomainService;

namespace Makc2022.Layer5.Sql.Server.Setup
{
    /// <summary>
    /// Модуль настройки приложения.
    /// </summary>
    public class SetupAppModule : AppModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(x => x.ConfigureLocalization());

            services.AddSingleton<ICommonProvider>(x => x.GetRequiredService<IClientProviderForSqlServer>());

            services.AddScoped<IDummyMainItemPageService>(x => new DummyMainItemPageService(
                x.GetRequiredService<IDummyMainDomainItemGetOperationHandler>(),
                x.GetRequiredService<IDummyMainDomainService>()
                ));

            services.AddScoped<IDummyMainListPageService>(x => new DummyMainListPageService(
                x.GetRequiredService<IDummyMainDomainListGetOperationHandler>(),
                x.GetRequiredService<IDummyMainDomainService>()
                ));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(ICommonProvider),
                typeof(IConfiguration),
                typeof(IDummyMainItemPageService),
                typeof(IDummyMainListPageService),
                typeof(ILogger),
                typeof(IStringLocalizer),
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(IClientProviderForSqlServer),
                typeof(IDummyMainItemPageService),
                typeof(IDummyMainListPageService),
                typeof(IDummyMainDomainService)
            };
        }

        #endregion Protected method
    }
}
