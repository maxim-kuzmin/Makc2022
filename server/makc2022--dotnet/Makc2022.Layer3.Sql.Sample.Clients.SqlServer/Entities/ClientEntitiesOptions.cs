// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Clients.SqlServer;
using Makc2022.Layer3.Sql.Sample.Entities;
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

namespace Makc2022.Layer3.Sql.Sample.Clients.SqlServer.Entities
{
    /// <summary>
    /// Параметры сущностей клиента.
    /// </summary>
    public class ClientEntitiesOptions : EntitiesOptions
    {
        #region Fields

        private static readonly Lazy<EntitiesOptions> _lazy = new(() => new ClientEntitiesOptions());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static EntitiesOptions Instance => _lazy.Value;

        #endregion Properties

        #region Constructors

        private ClientEntitiesOptions()
        {
            var defaults = new ClientDefaults();

            DummyOneToMany = new DummyOneToManyEntityOptions(defaults, "DummyOneToMany");

            DummyMain = new DummyMainEntityOptions(DummyOneToMany, defaults, "DummyMain");

            DummyManyToMany = new DummyManyToManyEntityOptions(defaults, "DummyManyToMany");

            DummyMainDummyManyToMany = new DummyMainDummyManyToManyEntityOptions(
                DummyMain,
                DummyManyToMany,
                defaults,
                "DummyMainDummyManyToMany"
                );

            DummyTree = new DummyTreeEntityOptions(defaults, "DummyTree");

            DummyTreeLink = new DummyTreeLinkEntityOptions(DummyTree, defaults, "DummyTreeLink");

            Role = new RoleEntityOptions(defaults, "Role");

            RoleClaim = new RoleClaimEntityOptions(Role, defaults, "RoleClaim");

            User = new UserEntityOptions(defaults, "User");

            UserClaim = new UserClaimEntityOptions(User, defaults, "UserClaim");

            UserLogin = new UserLoginEntityOptions(User, defaults, "UserLogin");

            UserRole = new UserRoleEntityOptions(Role, User, defaults, "UserRole");

            UserToken = new UserTokenEntityOptions(User, defaults, "UserToken");
        }

        #endregion Constructors     
    }
}
