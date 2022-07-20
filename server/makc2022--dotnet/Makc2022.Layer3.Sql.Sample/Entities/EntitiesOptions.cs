// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyMain;
using Makc2022.Layer3.Sql.Sample.Entities.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Entities.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Entities.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Entities.DummyTree;
using Makc2022.Layer3.Sql.Sample.Entities.DummyTreeLink;
using Makc2022.Layer3.Sql.Sample.Entities.Role;
using Makc2022.Layer3.Sql.Sample.Entities.RoleClaim;
using Makc2022.Layer3.Sql.Sample.Entities.User;
using Makc2022.Layer3.Sql.Sample.Entities.UserClaim;
using Makc2022.Layer3.Sql.Sample.Entities.UserLogin;
using Makc2022.Layer3.Sql.Sample.Entities.UserRole;
using Makc2022.Layer3.Sql.Sample.Entities.UserToken;

namespace Makc2022.Layer3.Sql.Sample.Entities
{
    /// <summary>
    /// Параметры сущностей.
    /// </summary>
    public abstract class EntitiesOptions
    {
        #region Properties

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DummyMainEntityOptions DummyMain { get; protected set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DummyMainDummyManyToManyEntityOptions DummyMainDummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DummyManyToManyEntityOptions DummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DummyOneToManyEntityOptions DummyOneToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DummyTreeEntityOptions DummyTree { get; protected set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DummyTreeLinkEntityOptions DummyTreeLink { get; protected set; }

        /// <summary>
        /// Сущность "Role".
        /// </summary>
        public RoleEntityOptions Role { get; protected set; }

        /// <summary>
        /// Сущность "RoleClaim".
        /// </summary>
        public RoleClaimEntityOptions RoleClaim { get; protected set; }

        /// <summary>
        /// Сущность "User".
        /// </summary>
        public UserEntityOptions User { get; protected set; }

        /// <summary>
        /// Сущность "UserClaim".
        /// </summary>
        public UserClaimEntityOptions UserClaim { get; protected set; }

        /// <summary>
        /// Сущность "UserLogin".
        /// </summary>
        public UserLoginEntityOptions UserLogin { get; protected set; }

        /// <summary>
        /// Сущность "UserRole".
        /// </summary>
        public UserRoleEntityOptions UserRole { get; protected set; }

        /// <summary>
        /// Сущность "UserToken".
        /// </summary>
        public UserTokenEntityOptions UserToken { get; protected set; }

        #endregion Properties
    }
}
