// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Layer1Module = Makc2022.Layer1.Setting.SettingModule;
using Layer5SqlModuleForGrpcClient = Makc2022.Layer5.Sql.GrpcClient.Setting.SettingModule;

namespace Makc2022.Layer5.Sql.GrpcClient.Setting
{
    /// <summary>
    /// Расширение настройки.
    /// </summary>
    public static class SettingExtension
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

            services.AddAppModules(new CommonModule[]
            {
                new Layer1Module(configuration.GetRequiredSection($"{root}:Layer1")),
                new Layer5SqlModuleForGrpcClient(configuration.GetRequiredSection($"{root}:Layer5:Sql:GrpcClient"))
            });
        }

        #endregion Public methods
    }
}
