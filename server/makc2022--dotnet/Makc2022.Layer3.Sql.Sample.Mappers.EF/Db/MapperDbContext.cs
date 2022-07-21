// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Db
{
    /// <summary>
    /// Контекст базы данных сопоставителя.
    /// </summary>
    public abstract class MapperDbContext : IdentityDbContext
        <
            MapperUserEntityObject,
            MapperRoleEntityObject,
            long,
            MapperUserClaimEntityObject,
            MapperUserRoleEntityObject,
            MapperUserLoginEntityObject,
            MapperRoleClaimEntityObject,
            MapperUserTokenEntityObject
        >
    {
        #region Properties        

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DbSet<MapperDummyMainEntityObject>? DummyMain { get; set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DbSet<MapperDummyManyToManyEntityObject>? DummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DbSet<MapperDummyMainDummyManyToManyEntityObject>? DummyMainDummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DbSet<MapperDummyOneToManyEntityObject>? DummyOneToMany { get; set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DbSet<MapperDummyTreeEntityObject>? DummyTree { get; set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DbSet<MapperDummyTreeLinkEntityObject>? DummyTreeLink { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public MapperDbContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion Constructors
    }
}