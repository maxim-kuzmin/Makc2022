// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Reflection;
using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer2.Sql.Mappers.EF.Db;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DbSetupOptions = Makc2022.Layer2.Sql.Setup.SetupOptions;

namespace Makc2022.Layer3.Sql.Sample.Clients.SqlServer.EF.Db
{
    /// <summary>
    /// Фабрика контекста базы данных клиента. Предназначена для выполнения команд dotnet ef, например:
    /// dotnet ef migrations add InitialCreate --configuration Debug -- "строка подключения к базе данных"
    /// dotnet ef database update --configuration Debug -- "строка подключения к базе данных"
    /// </summary>
    public class ClientDbContextFactory : IMapperDbContextFactory, IDesignTimeDbContextFactory<ClientDbContext>
    {
        #region Properties

        private IDbContextFactory<ClientDbContext>? DbContextFactory { get; }

        private IOptionsMonitor<DbSetupOptions>? DbSetupOptions { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор, необходимый для создания экземпляра, используемого в командах dotnet ef.
        /// </summary>
        public ClientDbContextFactory()
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dbContextFactory">Фабрика базы данных.</param>
        /// <param name="dbSetupOptions">Параметры настройки базы данных.</param>
        public ClientDbContextFactory(
            IDbContextFactory<ClientDbContext> dbContextFactory,
            IOptionsMonitor<DbSetupOptions> dbSetupOptions)
        {
            DbContextFactory = dbContextFactory;
            DbSetupOptions = dbSetupOptions;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        /// <param name="builder">Построитель.</param>        
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="settingOptions">Параметры настройки.</param>
        /// <param name="logger">Регистратор.</param>
        /// <param name="dbSetupOptions">Параметры настройки базы данных.</param>
        public static void Configure(
            DbContextOptionsBuilder builder,
            string? connectionString,
            ILogger<ClientDbContextFactory>? logger,
            IOptionsMonitor<DbSetupOptions>? dbSetupOptions)
        {
            if (builder.IsConfigured)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                if (connectionString is null)
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }
                else
                {
                    throw new NullOrWhiteSpaceStringVariableException<ClientDbContextFactory>(nameof(connectionString));
                }
            }

            if (logger != null)
            {
                var currentDbSetupOptions = dbSetupOptions?.CurrentValue;

                if (currentDbSetupOptions != null)
                {
                    builder.BuildLogging(logger, currentDbSetupOptions.LogLevel);
                }
            }

            builder.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
        }

        /// <inheritdoc/>
        public ClientDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ClientDbContext> builder = new();

            string? connectionString = args.Length > 0 ? args[0] : null;

            Configure(builder, connectionString, null, null);

            return new ClientDbContext(builder.Options);
        }

        /// <inheritdoc/>
        MapperDbContext IMapperDbContextFactory.CreateDbContext()
        {
            if (DbContextFactory is null)
            {
                throw new NullVariableException<ClientDbContextFactory>(nameof(DbContextFactory));
            }

            if (DbSetupOptions is null)
            {
                throw new NullVariableException<ClientDbContextFactory>(nameof(DbSetupOptions));
            }

            var result = DbContextFactory.CreateDbContext();

            var currentDbSetupOptions = DbSetupOptions.CurrentValue;

            int dbCommandTimeout = currentDbSetupOptions.DbCommandTimeout;

            result.Database.SetCommandTimeout(dbCommandTimeout > 0 ? dbCommandTimeout : 3600);

            return result;
        }

        #endregion Public methods
    }
}

