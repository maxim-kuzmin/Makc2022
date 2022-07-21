// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.UserToken;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserToken
{
    /// <summary>
    /// Расширение сущности "UserToken" сопоставителя.
    /// </summary>
    public static class MapperUserTokenEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperUserTokenEntityObject FromEntityToMapperObject(
            this UserTokenEntityObject entityObject
            )
        {
            MapperUserTokenEntityObject result = new();

            new UserTokenEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static UserTokenEntityObject FromMapperToEntityObject(
            this MapperUserTokenEntityObject mapperObject
            )
        {
            UserTokenEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
