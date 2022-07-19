// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2022.Layer5.Sql.Server.Setting
{
    /// <summary>
    /// Модуль настройки.
    /// </summary>
    public class SettingModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new CommonEnvironment());

            services.AddLocalization(x => x.ConfigureLocalization());
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(CommonEnvironment)
            };
        }

        #endregion Public methods
    }
}
