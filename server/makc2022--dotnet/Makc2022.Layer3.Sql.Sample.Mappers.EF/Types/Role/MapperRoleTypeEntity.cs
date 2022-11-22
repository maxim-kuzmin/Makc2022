// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.Role;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.RoleClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserRole;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.Role
{
    /// <summary>
    /// Сущность типа "Role" для сопоставителя.
    /// </summary>
    public class MapperRoleTypeEntity : RoleTypeEntity
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "RoleClaim".
        /// </summary>
        public List<MapperRoleClaimTypeEntity> ObjectsOfRoleClaimEntity { get; } =
            new List<MapperRoleClaimTypeEntity>();

        /// <summary>
        /// Объекты сущности "UserRole".
        /// </summary>
        public List<MapperUserRoleTypeEntity> ObjectsOfUserRoleEntity { get; } =
            new List<MapperUserRoleTypeEntity>();

        #endregion Properties
    }
}
