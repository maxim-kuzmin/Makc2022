// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Clients.SqlServer;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyTree;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyTreeLink;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.Role;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.RoleClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.User;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserLogin;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserRole;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserToken;

using Microsoft.EntityFrameworkCore;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Clients.SqlServer.Db
{
    /// <summary>
    /// Контекст базы данных сопоставителя клиента.
    /// </summary>
    public sealed class ClientMapperDbContext : MapperDbContext
    {
        #region Constructors

        /// <inheritdoc/>
        public ClientMapperDbContext(DbContextOptions<ClientMapperDbContext> options)
            : base(options)
        {
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var typesOptions = ClientTypesOptions.Instance;

            modelBuilder.ApplyConfiguration(new MapperDummyMainTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyManyToManyTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyMainDummyManyToManyTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyOneToManyTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyTreeTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyTreeLinkTypeConfiguration(typesOptions));

            modelBuilder.ApplyConfiguration(new MapperRoleTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperRoleClaimTypeConfiguration(typesOptions));

            modelBuilder.ApplyConfiguration(new MapperUserTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserClaimTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserLoginTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserRoleTypeConfiguration(typesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserTokenTypeConfiguration(typesOptions));
        }

        #endregion Protected methods
    }
}
