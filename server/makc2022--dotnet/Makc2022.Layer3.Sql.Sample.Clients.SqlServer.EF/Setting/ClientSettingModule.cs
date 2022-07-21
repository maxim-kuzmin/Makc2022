// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Makc2022.Layer3.Sql.Sample.Clients.SqlServer.EF.Db;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DbSettingOptions = Makc2022.Layer2.Sql.Setting.SettingOptions;

namespace Makc2022.Layer3.Sql.Sample.Clients.SqlServer.EF.Setting
{
    /// <summary>
    /// Модуль клиента.
    /// </summary>
    public class ClientSettingModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<ClientDbContext>((x, options) => ClientDbFactory.Configure(
                options,
                x.GetRequiredService<IConfiguration>().GetConnectionString("Sample"),
                x.GetRequiredService<ILogger<ClientDbFactory>>(),
                x.GetRequiredService<IOptionsMonitor<DbSettingOptions>>()));

            services.AddTransient<IMapperDbFactory>(x => new ClientDbFactory(
                x.GetRequiredService<IDbContextFactory<ClientDbContext>>(),
                x.GetRequiredService<IOptionsMonitor<DbSettingOptions>>()));
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
                typeof(IConfiguration),
                typeof(ILogger),
                typeof(IOptionsMonitor<DbSettingOptions>),
            };
        }

        #endregion Protected methods
    }
}
