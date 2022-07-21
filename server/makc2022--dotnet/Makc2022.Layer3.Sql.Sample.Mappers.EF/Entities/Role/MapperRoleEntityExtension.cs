// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.Role;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.Role
{
    /// <summary>
    /// Расширение сущности "Role" сопоставителя.
    /// </summary>
    public static class MapperRoleEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperRoleEntityObject FromEntityToMapperObject(
            this RoleEntityObject entityObject
            )
        {
            MapperRoleEntityObject result = new();

            new RoleEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static RoleEntityObject FromMapperToEntityObject(
            this MapperRoleEntityObject mapperObject
            )
        {
            RoleEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
