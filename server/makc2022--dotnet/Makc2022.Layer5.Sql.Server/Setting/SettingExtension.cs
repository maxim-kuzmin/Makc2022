// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Layer1Options = Makc2022.Layer1.Setting.SettingOptions;
using Layer1Module = Makc2022.Layer1.Setting.SettingModule;
using Layer2SqlModule = Makc2022.Layer2.Sql.Setting.SettingModule;
using Layer2SqlOptions = Makc2022.Layer2.Sql.Setting.SettingOptions;
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
                new Layer1Module(configuration.GetRequiredSection("Layer1")),
                new Layer2SqlModule(configuration.GetRequiredSection("Layer2:Sql")),
                new Layer5SqlServerModule()
            });
        }

        /// <summary>
        /// Использовать сервисы приложения.
        /// </summary>
        /// <param name="serviceProvider">Поставщик сервисов.</param>
        public static void UseAppServices(this IServiceProvider serviceProvider)
        {
            var optionsOfLayer1 = serviceProvider.GetRequiredService<IOptionsMonitor<Layer1Options>>().CurrentValue;
            var optionsOfLayer2Sql = serviceProvider.GetRequiredService<IOptionsMonitor<Layer2SqlOptions>>().CurrentValue;
        }

        #endregion Public methods
    }
}
