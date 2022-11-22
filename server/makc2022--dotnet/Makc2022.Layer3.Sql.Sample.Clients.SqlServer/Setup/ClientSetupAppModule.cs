// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Makc2022.Layer3.Sql.Sample.Clients.SqlServer.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2022.Layer3.Sql.Sample.Clients.SqlServer.Setup
{
    /// <summary>
    /// Модуль настройки приложения клиента.
    /// </summary>
    public class ClientSetupAppModule : AppModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(x => ClientEntitiesOptions.Instance); // EntitiesOptions
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(TypesOptions)
            };
        }

        #endregion Public methods
    }
}
