// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.Role;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.Role
{
    /// <summary>
    /// Расширение сущности "Role" сопоставителя.
    /// </summary>
    public static class MapperRoleTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperRoleTypeEntity ToMapperEntity(this RoleTypeEntity entity)
        {
            MapperRoleTypeEntity result = new();

            new RoleTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static RoleTypeEntity ToEntity(this MapperRoleTypeEntity mapperEntity)
        {
            RoleTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
