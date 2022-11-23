// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.UserRole;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.Role;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserRole
{
    /// <summary>
    /// Сущность типа "Роль пользователя" сопоставителя.
    /// </summary>
    public class MapperUserRoleTypeEntity : UserRoleTypeEntity
    {
        #region Navigation properties

        /// <summary>
        /// Экземпляр сущности "Роль".
        /// </summary>
        public MapperRoleTypeEntity? Role { get; set; }

        /// <summary>
        /// Экземпляр сущности "Пользователь".
        /// </summary>
        public MapperUserTypeEntity? User { get; set; }

        #endregion Navigation properties
    }
}
