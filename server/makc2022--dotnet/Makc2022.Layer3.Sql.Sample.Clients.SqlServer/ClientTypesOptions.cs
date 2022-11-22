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

namespace Makc2022.Layer3.Sql.Sample.Clients.SqlServer
{
    /// <summary>
    /// Параметры типов клиента.
    /// </summary>
    public class ClientTypesOptions : TypesOptions
    {
        #region Fields

        private static readonly Lazy<TypesOptions> _lazy = new(() => new ClientTypesOptions());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static TypesOptions Instance => _lazy.Value;

        #endregion Properties

        #region Constructors

        private ClientTypesOptions()
        {
            var defaults = new ClientDefaults();

            DummyOneToMany = new DummyOneToManyTypeOptions(defaults, "DummyOneToMany");

            DummyMain = new DummyMainTypeOptions(DummyOneToMany, defaults, "DummyMain");

            DummyManyToMany = new DummyManyToManyTypeOptions(defaults, "DummyManyToMany");

            DummyMainDummyManyToMany = new DummyMainDummyManyToManyTypeOptions(
                DummyMain,
                DummyManyToMany,
                defaults,
                "DummyMainDummyManyToMany"
                );

            DummyTree = new DummyTreeTypeOptions(defaults, "DummyTree");

            DummyTreeLink = new DummyTreeLinkTypeOptions(DummyTree, defaults, "DummyTreeLink");

            Role = new RoleTypeOptions(defaults, "Role");

            RoleClaim = new RoleClaimTypeOptions(Role, defaults, "RoleClaim");

            User = new UserTypeOptions(defaults, "User");

            UserClaim = new UserClaimTypeOptions(User, defaults, "UserClaim");

            UserLogin = new UserLoginTypeOptions(User, defaults, "UserLogin");

            UserRole = new UserRoleTypeOptions(Role, User, defaults, "UserRole");

            UserToken = new UserTokenTypeOptions(User, defaults, "UserToken");
        }

        #endregion Constructors     
    }
}
