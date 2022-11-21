// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.App;
using Makc2022.Layer1.Operation;
using Makc2022.Layer1.Setup;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IMapperDbFactoryForSample = Makc2022.Layer3.Sql.Sample.Mappers.EF.Db.IMapperDbContextFactory;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Setup
{
    /// <summary>
    /// Модуль настройки приложения домена.
    /// </summary>
    public class DomainSetupAppModule : AppModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainResource>(x => new DomainResource(
                x.GetRequiredService<IStringLocalizer<DomainResource>>()));

            services.AddTransient<IDomainService>(x => new DomainService(
                x.GetRequiredService<IMapperDbFactoryForSample>()));

            services.AddTransient<IDomainItemGetOperationHandler>(x => new DomainItemGetOperationHandler(
                x.GetRequiredService<IDomainResource>(),
                x.GetRequiredService<IOperationResource>(),
                x.GetRequiredService<ILogger<DomainItemGetOperationHandler>>(),
                x.GetRequiredService<IOptionsMonitor<SetupOptions>>()));

            services.AddTransient<IDomainListGetOperationHandler>(x => new DomainListGetOperationHandler(
                x.GetRequiredService<IDomainResource>(),
                x.GetRequiredService<IOperationResource>(),
                x.GetRequiredService<ILogger<DomainListGetOperationHandler>>(),
                x.GetRequiredService<IOptionsMonitor<SetupOptions>>()));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IDomainResource),
                typeof(IDomainService),
                typeof(IDomainItemGetOperationHandler),
                typeof(IDomainListGetOperationHandler),
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
                typeof(SetupOptions),
            };
        }

        #endregion Protected methods
    }
}
