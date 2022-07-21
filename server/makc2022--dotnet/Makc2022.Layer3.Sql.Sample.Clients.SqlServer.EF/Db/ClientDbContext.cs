// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Clients.SqlServer.Entities;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTreeLink;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.Role;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.User;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserLogin;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserToken;

using Microsoft.EntityFrameworkCore;

namespace Makc2022.Layer3.Sql.Sample.Clients.SqlServer.EF.Db
{
    /// <summary>
    /// Контекст базы данных клиента.
    /// </summary>
    public sealed class ClientDbContext : MapperDbContext
    {
        #region Constructors

        /// <inheritdoc/>
        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options)
        {
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entitiesOptions = ClientEntitiesOptions.Instance;

            modelBuilder.ApplyConfiguration(new MapperDummyMainEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyManyToManyEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyMainDummyManyToManyEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyOneToManyEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyTreeEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyTreeLinkEntitySchema(entitiesOptions));

            modelBuilder.ApplyConfiguration(new MapperRoleEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperRoleClaimEntitySchema(entitiesOptions));

            modelBuilder.ApplyConfiguration(new MapperUserEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserClaimEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserLoginEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserRoleEntitySchema(entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserTokenEntitySchema(entitiesOptions));
        }

        #endregion Protected methods
    }
}
