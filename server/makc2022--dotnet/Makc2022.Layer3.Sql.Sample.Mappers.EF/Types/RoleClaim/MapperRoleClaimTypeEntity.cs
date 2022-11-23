// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.RoleClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.Role;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.RoleClaim
{
    /// <summary>
    /// Сущность типа "Утверждение роли" сопоставителя.
    /// </summary>
    public class MapperRoleClaimTypeEntity : RoleClaimTypeEntity
    {
        #region Navigation properties

        /// <summary>
        /// Экземпляр сущности "Роль".
        /// </summary>
        public MapperRoleTypeEntity? Role { get; set; }

        #endregion Navigation properties
    }
}
