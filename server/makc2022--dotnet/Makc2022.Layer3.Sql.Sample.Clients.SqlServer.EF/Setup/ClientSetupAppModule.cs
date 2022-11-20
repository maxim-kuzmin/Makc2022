// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Makc2022.Layer3.Sql.Sample.Clients.SqlServer.EF.Db;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DbSetupOptions = Makc2022.Layer2.Sql.Setup.SetupOptions;
using DbSetupOptionsForSample = Makc2022.Layer3.Sql.Sample.Setup.SetupOptions;

namespace Makc2022.Layer3.Sql.Sample.Clients.SqlServer.EF.Setup
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
            services.AddDbContextFactory<ClientDbContext>((x, options) => ClientDbFactory.Configure(
                options,
                x.GetRequiredService<IConfiguration>().GetConnectionString(
                    x.GetRequiredService<IOptions<DbSetupOptionsForSample>>().Value.ConnectionStringName),
                x.GetRequiredService<ILogger<ClientDbFactory>>(),
                x.GetRequiredService<IOptionsMonitor<DbSetupOptions>>()));

            services.AddTransient<IMapperDbFactory>(x => new ClientDbFactory(
                x.GetRequiredService<IDbContextFactory<ClientDbContext>>(),
                x.GetRequiredService<IOptionsMonitor<DbSetupOptions>>()));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IDbContextFactory<ClientDbContext>),
                typeof(IMapperDbFactory),
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return new[]
            {                
                typeof(DbSetupOptions),
                typeof(DbSetupOptionsForSample),
                typeof(IConfiguration),
                typeof(ILogger),
            };
        }

        #endregion Protected methods
    }
}
