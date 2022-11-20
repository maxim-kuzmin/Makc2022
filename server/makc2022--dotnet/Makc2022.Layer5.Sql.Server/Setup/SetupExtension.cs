// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Layer1Module = Makc2022.Layer1.Setup.SetupAppModule;
using Layer2SqlModule = Makc2022.Layer2.Sql.Setup.SetupAppModule;
using Layer2SqlModuleForSqlServerClient = Makc2022.Layer2.Sql.Clients.SqlServer.Setup.ClientSetupAppModule;
using Layer3SqlModuleForSample = Makc2022.Layer3.Sql.Sample.Setup.SetupAppModule;
using Layer3SqlModuleForSampleClientSqlServer = Makc2022.Layer3.Sql.Sample.Clients.SqlServer.Setup.ClientSetupAppModule;
using Layer3SqlModuleForSampleClientSqlServerEF = Makc2022.Layer3.Sql.Sample.Clients.SqlServer.EF.Setup.ClientSetupAppModule;
using Layer3SqlModuleForSampleMapperEF = Makc2022.Layer3.Sql.Sample.Mappers.EF.Setup.MapperSetupAppModule;
using IMapperServiceForSample = Makc2022.Layer3.Sql.Sample.Mappers.EF.IMapperService;
using Layer4SqlModuleForDomainDummyMain = Makc2022.Layer4.Sql.Domains.DummyMain.Setup.DomainSetupAppModule;
using Layer5SqlModuleForServer = Makc2022.Layer5.Sql.Server.Setup.SetupAppModule;

namespace Makc2022.Layer5.Sql.Server.Setup
{
    /// <summary>
    /// Расширение настройки.
    /// </summary>
    public static class SetupExtension
    {
        #region Public methods

        /// <summary>
        /// Добавить сервисы приложения.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            const string root = "Makc2022";

            services.AddAppModules(new AppModule[]
            {
                new Layer1Module(configuration.GetRequiredSection($"{root}:Layer1")),
                new Layer2SqlModule(configuration.GetRequiredSection($"{root}:Layer2:Sql")),
                new Layer2SqlModuleForSqlServerClient(),
                new Layer3SqlModuleForSample(configuration.GetRequiredSection($"{root}:Layer3:Sql:Sample")),
                new Layer3SqlModuleForSampleClientSqlServer(),
                new Layer3SqlModuleForSampleClientSqlServerEF(),
                new Layer3SqlModuleForSampleMapperEF(),
                new Layer4SqlModuleForDomainDummyMain(),
                new Layer5SqlModuleForServer()
            });
        }

        /// <summary>
        /// Использовать сервисы приложения.
        /// </summary>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        public static void UseAppServices(this IServiceProvider serviceProvider)
        {
            var mapperServiceForSample = serviceProvider.GetRequiredService<IMapperServiceForSample>();

            mapperServiceForSample.MigrateDatabase().Wait();

            mapperServiceForSample.SeedTestData().Wait();
        }

        #endregion Public methods
    }
}
