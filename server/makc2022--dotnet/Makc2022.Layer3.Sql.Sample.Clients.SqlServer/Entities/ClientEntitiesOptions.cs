// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Clients.SqlServer;
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

namespace Makc2022.Layer3.Sql.Sample.Clients.SqlServer.Entities
{
    /// <summary>
    /// Параметры сущностей клиента.
    /// </summary>
    public class ClientEntitiesOptions : TypesOptions
    {
        #region Fields

        private static readonly Lazy<TypesOptions> _lazy = new(() => new ClientEntitiesOptions());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static TypesOptions Instance => _lazy.Value;

        #endregion Properties

        #region Constructors

        private ClientEntitiesOptions()
        {
            var defaults = new ClientDefaults();

            DummyOneToMany = new DummyOneToManyTypeOptions(defaults, "Фиктивное отношение один ко многим");

            DummyMain = new DummyMainTypeOptions(DummyOneToMany, defaults, "Фиктивное главное");

            DummyManyToMany = new DummyManyToManyTypeOptions(defaults, "Фиктивное отношение многие ко многим");

            DummyMainDummyManyToMany = new DummyMainDummyManyToManyTypeOptions(
                DummyMain,
                DummyManyToMany,
                defaults,
                "Фиктивное отношение многие ко многим фиктивного главного"
                );

            DummyTree = new DummyTreeTypeOptions(defaults, "Фиктивное дерево");

            DummyTreeLink = new DummyTreeLinkTypeOptions(DummyTree, defaults, "Связь фиктивного дерева");

            Role = new RoleTypeOptions(defaults, "Роль");

            RoleClaim = new RoleClaimTypeOptions(Role, defaults, "Утверждение роли");

            User = new UserTypeOptions(defaults, "Пользователь");

            UserClaim = new UserClaimTypeOptions(User, defaults, "Утверждение пользователя");

            UserLogin = new UserLoginTypeOptions(User, defaults, "Вход пользователя");

            UserRole = new UserRoleTypeOptions(Role, User, defaults, "Роль пользователя");

            UserToken = new UserTokenTypeOptions(User, defaults, "Токен пользователя");
        }

        #endregion Constructors     
    }
}
