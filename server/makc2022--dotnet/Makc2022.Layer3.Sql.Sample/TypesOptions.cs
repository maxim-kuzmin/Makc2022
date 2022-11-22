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
        /// Сущность "Фиктивное главное".
        /// </summary>
        public DummyMainTypeOptions DummyMain { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Фиктивное отношение многие ко многим фиктивного главного".
        /// </summary>
        public DummyMainDummyManyToManyTypeOptions DummyMainDummyManyToMany { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Фиктивное отношение многие ко многим".
        /// </summary>
        public DummyManyToManyTypeOptions DummyManyToMany { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Фиктивное отношение один ко многим".
        /// </summary>
        public DummyOneToManyTypeOptions DummyOneToMany { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Фиктивное дерево".
        /// </summary>
        public DummyTreeTypeOptions DummyTree { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Связь фиктивного дерева".
        /// </summary>
        public DummyTreeLinkTypeOptions DummyTreeLink { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Роль".
        /// </summary>
        public RoleTypeOptions Role { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Утверждение роли".
        /// </summary>
        public RoleClaimTypeOptions RoleClaim { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Пользователь".
        /// </summary>
        public UserTypeOptions User { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Утверждение пользователя".
        /// </summary>
        public UserClaimTypeOptions UserClaim { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Вход пользователя".
        /// </summary>
        public UserLoginTypeOptions UserLogin { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Роль пользователя".
        /// </summary>
        public UserRoleTypeOptions UserRole { get; protected set; } = null!;

        /// <summary>
        /// Сущность "Токен пользователя".
        /// </summary>
        public UserTokenTypeOptions UserToken { get; protected set; } = null!;

        #endregion Properties
    }
}
