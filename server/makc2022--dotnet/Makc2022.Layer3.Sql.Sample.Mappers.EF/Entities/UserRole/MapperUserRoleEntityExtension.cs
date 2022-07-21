// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.UserRole;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole
{
    /// <summary>
    /// Расширение сущности "UserRole" сопоставителя.
    /// </summary>
    public static class MapperUserRoleEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperUserRoleEntityObject FromEntityToMapperObject(
            this UserRoleEntityObject entityObject
            )
        {
            MapperUserRoleEntityObject result = new();

            new UserRoleEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static UserRoleEntityObject FromMapperToEntityObject(
            this MapperUserRoleEntityObject mapperObject
            )
        {
            UserRoleEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
