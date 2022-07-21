// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Layer1Module = Makc2022.Layer1.Setting.SettingModule;
using Layer2SqlModule = Makc2022.Layer2.Sql.Setting.SettingModule;
using Layer3SqlModuleForSample = Makc2022.Layer3.Sql.Sample.Setting.SettingModule;
using Layer5SqlServerModule = Makc2022.Layer5.Sql.Server.Setting.SettingModule;

namespace Makc2022.Layer5.Sql.Server.Setting
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
            services.AddAppModules(new CommonModule[]
            {
                new Layer1Module(configuration.GetRequiredSection("Makc2022:Layer1")),
                new Layer2SqlModule(configuration.GetRequiredSection("Makc2022:Layer2:Sql")),
                new Layer3SqlModuleForSample(configuration.GetRequiredSection("Makc2022:Layer3:Sql:Sample")),
                new Layer5SqlServerModule()
            });
        }

        /// <summary>
        /// Использовать сервисы приложения.
        /// </summary>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        public static void UseAppServices(this IServiceProvider serviceProvider)
        {
        }

        #endregion Public methods
    }
}
