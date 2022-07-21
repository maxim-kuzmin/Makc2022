// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.UserRole;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.Role;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.User;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole
{
    /// <summary>
    /// Объект сущности "UserRole" сопоставителя.
    /// </summary>
    public class MapperUserRoleEntityObject : UserRoleEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "Role".
        /// </summary>
        public MapperRoleEntityObject? ObjectOfRoleEntity { get; set; }

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public MapperUserEntityObject? ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
