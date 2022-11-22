// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.UserRole;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserRole
{
    /// <summary>
    /// Расширение сущности "Роль пользователя" сопоставителя.
    /// </summary>
    public static class MapperUserRoleTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperUserRoleTypeEntity ToMapperEntity(this UserRoleTypeEntity entity)
        {
            MapperUserRoleTypeEntity result = new();

            new UserRoleTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static UserRoleTypeEntity ToEntity(this MapperUserRoleTypeEntity mapperEntity)
        {
            UserRoleTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
