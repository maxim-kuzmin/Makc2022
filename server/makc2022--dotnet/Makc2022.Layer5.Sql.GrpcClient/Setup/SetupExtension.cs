// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Layer1Module = Makc2022.Layer1.Setup.SetupAppModule;
using Layer5SqlModuleForGrpcClient = Makc2022.Layer5.Sql.GrpcClient.Setup.SetupAppModule;

namespace Makc2022.Layer5.Sql.GrpcClient.Setup
{
    /// <summary>
    /// Расширение настройки.
    /// </summary>
    public static class SetupExtension
    {
        #region Public methods

        /// <summary>
        /// Добавить модули приложения.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static void AddAppModules(this IServiceCollection services, IConfiguration configuration)
        {
            const string root = "Makc2022";

            services.AddAppModules(new AppModule[]
            {
                new Layer1Module(configuration.GetRequiredSection($"{root}:Layer1")),
                new Layer5SqlModuleForGrpcClient(configuration.GetRequiredSection($"{root}:Layer5:Sql:GrpcClient"))
            });
        }

        #endregion Public methods
    }
}
