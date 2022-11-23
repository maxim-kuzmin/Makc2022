// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.Role;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.RoleClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserRole;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.Role
{
    /// <summary>
    /// Сущность типа "Роль" сопоставителя.
    /// </summary>
    public class MapperRoleTypeEntity : RoleTypeEntity
    {
        #region Navigation properties

        /// <summary>
        /// Список экземпляров сущности "Утверждение роли".
        /// </summary>
        public List<MapperRoleClaimTypeEntity> RoleClaimList { get; } = new();

        /// <summary>
        /// Список экземпляров сущности "Роль пользователя".
        /// </summary>
        public List<MapperUserRoleTypeEntity> UserRoleList { get; } = new();

        #endregion Navigation properties
    }
}
