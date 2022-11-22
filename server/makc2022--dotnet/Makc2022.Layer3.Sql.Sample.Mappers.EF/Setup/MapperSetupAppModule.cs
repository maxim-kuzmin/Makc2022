// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Makc2022.Layer2.Sql;
using Makc2022.Layer3.Sql.Sample.Entities;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Setup
{
    /// <summary>
    /// Модуль настройки приложения сопоставителя.
    /// </summary>
    public class MapperSetupAppModule : AppModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMapperService>(x => new MapperService(
                x.GetRequiredService<IProvider>(),
                x.GetRequiredService<EntitiesOptions>(),
                x.GetRequiredService<IMapperDbContextFactory>()
                ));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IMapperService)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(EntitiesOptions),
                typeof(IProvider),
                typeof(IMapperDbContextFactory),
            };
        }

        #endregion Protected methods
    }
}
