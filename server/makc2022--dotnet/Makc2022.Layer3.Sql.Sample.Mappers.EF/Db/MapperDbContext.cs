// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Db
{
    /// <summary>
    /// Контекст базы данных сопоставителя.
    /// </summary>
    public abstract class MapperDbContext : IdentityDbContext
        <
            MapperUserTypeEntity,
            MapperRoleTypeEntity,
            long,
            MapperUserClaimTypeEntity,
            MapperUserRoleTypeEntity,
            MapperUserLoginTypeEntity,
            MapperRoleClaimTypeEntity,
            MapperUserTokenTypeEntity
        >
    {
        #region Properties        

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DbSet<MapperDummyMainTypeEntity>? DummyMain { get; set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DbSet<MapperDummyManyToManyTypeEntity>? DummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DbSet<MapperDummyMainDummyManyToManyTypeEntity>? DummyMainDummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DbSet<MapperDummyOneToManyTypeEntity>? DummyOneToMany { get; set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DbSet<MapperDummyTreeTypeEntity>? DummyTree { get; set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DbSet<MapperDummyTreeLinkTypeEntity>? DummyTreeLink { get; set; }

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