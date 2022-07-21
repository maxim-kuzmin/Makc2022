// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Db;
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
            DbDefaults dbDefaults = new()
            {
                DbColumnForId = "Id",
                DbColumnForName = "Name",
                DbColumnForParentId = "ParentId",
                DbColumnForTreeChildCount = "TreeChildCount",
                DbColumnForTreeDescendantCount = "TreeDescendantCount",
                DbColumnForTreeLevel = "TreeLevel",
                DbColumnForTreePath = "TreePath",
                DbColumnForTreePosition = "TreePosition",
                DbColumnForTreeSort = "TreeSort",
                DbColumnPartsSeparator = "",
                DbForeignKeyPrefix = "FK",
                DbIndexPrefix = "IX",
                DbPrimaryKeyPrefix = "PK",
                DbSchema = "dbo",
                DbUniqueIndexPrefix = "UX",
                FullNamePartsSeparator = ".",
                NamePartsSeparator = "_"
            };

            DummyOneToMany = new DummyOneToManyEntityOptions(dbDefaults, "DummyOneToMany");

            DummyMain = new DummyMainEntityOptions(DummyOneToMany, dbDefaults, "DummyMain");

            DummyManyToMany = new DummyManyToManyEntityOptions(dbDefaults, "DummyManyToMany");

            DummyMainDummyManyToMany = new DummyMainDummyManyToManyEntityOptions(
                DummyMain,
                DummyManyToMany,
                dbDefaults,
                "DummyMainDummyManyToMany"
                );

            DummyTree = new DummyTreeEntityOptions(dbDefaults, "DummyTree");

            DummyTreeLink = new DummyTreeLinkEntityOptions(DummyTree, dbDefaults, "DummyTreeLink");

            Role = new RoleEntityOptions(dbDefaults, "Role");

            RoleClaim = new RoleClaimEntityOptions(Role, dbDefaults, "RoleClaim");

            User = new UserEntityOptions(dbDefaults, "User");

            UserClaim = new UserClaimEntityOptions(User, dbDefaults, "UserClaim");

            UserLogin = new UserLoginEntityOptions(User, dbDefaults, "UserLogin");

            UserRole = new UserRoleEntityOptions(Role, User, dbDefaults, "UserRole");

            UserToken = new UserTokenEntityOptions(User, dbDefaults, "UserToken");
        }

        #endregion Constructors     
    }
}
