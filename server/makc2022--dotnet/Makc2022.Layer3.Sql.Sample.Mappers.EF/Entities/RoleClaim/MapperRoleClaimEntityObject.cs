// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.RoleClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.Role;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Объект сущности "RoleClaim" для сопоставителя.
    /// </summary>
    public class MapperRoleClaimEntityObject : RoleClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "Role".
        /// </summary>
        public MapperRoleEntityObject? ObjectOfRoleEntity { get; set; }

        #endregion Properties
    }
}
