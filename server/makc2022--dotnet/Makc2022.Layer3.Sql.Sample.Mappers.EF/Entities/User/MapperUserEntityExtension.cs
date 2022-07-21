// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.User;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.User
{
    /// <summary>
    /// Расширение сущности "User" сопоставителя.
    /// </summary>
    public static class MapperUserEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperUserEntityObject FromEntityToMapperObject(
            this UserEntityObject entityObject
            )
        {
            MapperUserEntityObject result = new();

            new UserEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static UserEntityObject FromMapperToEntityObject(
            this MapperUserEntityObject mapperObject
            )
        {
            UserEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
