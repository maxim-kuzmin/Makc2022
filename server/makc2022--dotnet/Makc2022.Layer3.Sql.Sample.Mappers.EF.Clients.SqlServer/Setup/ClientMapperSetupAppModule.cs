// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Clients.SqlServer.Db;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DbSetupOptions = Makc2022.Layer2.Sql.Setup.SetupOptions;
using DbSetupOptionsForSample = Makc2022.Layer3.Sql.Sample.Setup.SetupOptions;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Clients.SqlServer.Setup
{
    /// <summary>
    /// Модуль настройки приложения сопоставителя клиента.
    /// </summary>
    public class ClientMapperSetupAppModule : AppModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<ClientMapperDbContext>((x, options) => ClientMapperDbContextFactory.Configure(
                options,
                x.GetRequiredService<IConfiguration>().GetConnectionString(GetConnectionStringName(x)),
                x.GetRequiredService<ILogger<ClientMapperDbContextFactory>>(),
                x.GetRequiredService<IOptionsMonitor<DbSetupOptions>>()));

            services.AddTransient<IMapperDbContextFactory>(x => new ClientMapperDbContextFactory(
                x.GetRequiredService<IDbContextFactory<ClientMapperDbContext>>(),
                x.GetRequiredService<IOptionsMonitor<DbSetupOptions>>()));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IDbContextFactory<ClientMapperDbContext>),
                typeof(IMapperDbContextFactory),
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

        #region Private methods

        private string GetConnectionStringName(IServiceProvider serviceProvider)
        {
            string? result = serviceProvider.GetRequiredService<IOptions<DbSetupOptionsForSample>>()
                .Value
                .ConnectionStringName;

            if (string.IsNullOrWhiteSpace(result))
            {
                throw new NullOrWhiteSpaceStringVariableException<DbSetupOptionsForSample>
                    (nameof(DbSetupOptionsForSample.ConnectionStringName));
            }

            return result;
        }

        #endregion Private methods
    }
}
