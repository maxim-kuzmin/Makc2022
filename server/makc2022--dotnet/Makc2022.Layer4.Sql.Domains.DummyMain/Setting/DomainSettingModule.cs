// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Makc2022.Layer1.Query;
using Makc2022.Layer1.Setting;
using Makc2022.Layer4.Sql.Domains.DummyMain.Queries.Item.Get;
using Makc2022.Layer4.Sql.Domains.DummyMain.Queries.List.Get;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IMapperDbFactoryForSample = Makc2022.Layer3.Sql.Sample.Mappers.EF.Db.IMapperDbFactory;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Setting
{
    /// <summary>
    /// Модуль домена.
    /// </summary>
    public class DomainSettingModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainResource>(x => new DomainResource(
                x.GetRequiredService<IStringLocalizer<DomainResource>>()));

            services.AddTransient<IDomainService>(x => new DomainService(
                x.GetRequiredService<IMapperDbFactoryForSample>()));

            services.AddTransient<IDomainItemGetQueryHandler>(x => new DomainItemGetQueryHandler(
                x.GetRequiredService<IDomainResource>(),
                x.GetRequiredService<IQueryResource>(),
                x.GetRequiredService<ILogger<DomainItemGetQueryHandler>>(),
                x.GetRequiredService<IOptionsMonitor<SettingOptions>>()));

            services.AddTransient<IDomainListGetQueryHandler>(x => new DomainListGetQueryHandler(
                x.GetRequiredService<IDomainResource>(),
                x.GetRequiredService<IQueryResource>(),
                x.GetRequiredService<ILogger<DomainListGetQueryHandler>>(),
                x.GetRequiredService<IOptionsMonitor<SettingOptions>>()));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IDomainResource),
                typeof(IDomainService),
                typeof(IDomainItemGetQueryHandler),
                typeof(IDomainListGetQueryHandler),
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(ILogger),
                typeof(IMapperDbFactoryForSample),                
                typeof(IStringLocalizer),
                typeof(SettingOptions),
            };
        }

        #endregion Protected methods
    }
}
