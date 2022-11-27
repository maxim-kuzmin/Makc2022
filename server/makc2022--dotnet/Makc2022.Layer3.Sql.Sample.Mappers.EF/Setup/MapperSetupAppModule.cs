// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Makc2022.Layer2.Sql;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Makc2022.Layer3.Sql.Sample.Setup;
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
            services.AddSingleton<ISetupService>(x => new MapperSetupService(
                x.GetRequiredService<IProvider>(),
                x.GetRequiredService<TypesOptions>(),
                x.GetRequiredService<IMapperDbContextFactory>()
                ));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(ISetupService)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(TypesOptions),
                typeof(IProvider),
                typeof(IMapperDbContextFactory),
            };
        }

        #endregion Protected methods
    }
}
