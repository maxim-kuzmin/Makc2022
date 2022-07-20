// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2022.Layer2.Sql.Clients.SqlServer.Setting
{
    /// <summary>
    /// Модуль настроек клиента.
    /// </summary>
    public class ClientSettingModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IClientProvider>(x => new ClientProvider());
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IClientProvider)
            };
        }

        #endregion Public methods
    }
}