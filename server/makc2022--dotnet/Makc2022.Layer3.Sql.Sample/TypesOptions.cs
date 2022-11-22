// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyMain;
using Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Types.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Types.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Types.DummyTree;
using Makc2022.Layer3.Sql.Sample.Types.DummyTreeLink;
using Makc2022.Layer3.Sql.Sample.Types.Role;
using Makc2022.Layer3.Sql.Sample.Types.RoleClaim;
using Makc2022.Layer3.Sql.Sample.Types.User;
using Makc2022.Layer3.Sql.Sample.Types.UserClaim;
using Makc2022.Layer3.Sql.Sample.Types.UserLogin;
using Makc2022.Layer3.Sql.Sample.Types.UserRole;
using Makc2022.Layer3.Sql.Sample.Types.UserToken;

namespace Makc2022.Layer3.Sql.Sample
{
    /// <summary>
    /// Параметры типов.
    /// </summary>
    public abstract class TypesOptions
    {
        #region Properties

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DummyMainTypeOptions? DummyMain { get; protected set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DummyMainDummyManyToManyTypeOptions? DummyMainDummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DummyManyToManyTypeOptions? DummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DummyOneToManyTypeOptions? DummyOneToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DummyTreeTypeOptions? DummyTree { get; protected set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DummyTreeLinkTypeOptions? DummyTreeLink { get; protected set; }

        /// <summary>
        /// Сущность "Role".
        /// </summary>
        public RoleTypeOptions? Role { get; protected set; }

        /// <summary>
        /// Сущность "RoleClaim".
        /// </summary>
        public RoleClaimTypeOptions? RoleClaim { get; protected set; }

        /// <summary>
        /// Сущность "User".
        /// </summary>
        public UserTypeOptions? User { get; protected set; }

        /// <summary>
        /// Сущность "UserClaim".
        /// </summary>
        public UserClaimTypeOptions? UserClaim { get; protected set; }

        /// <summary>
        /// Сущность "UserLogin".
        /// </summary>
        public UserLoginTypeOptions? UserLogin { get; protected set; }

        /// <summary>
        /// Сущность "UserRole".
        /// </summary>
        public UserRoleTypeOptions? UserRole { get; protected set; }

        /// <summary>
        /// Сущность "UserToken".
        /// </summary>
        public UserTokenTypeOptions? UserToken { get; protected set; }

        #endregion Properties
    }
}
