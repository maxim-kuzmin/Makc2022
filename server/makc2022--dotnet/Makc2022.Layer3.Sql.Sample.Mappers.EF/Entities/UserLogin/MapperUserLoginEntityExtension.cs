// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.UserLogin;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserLogin
{
    /// <summary>
    /// Расширение сущности "UserLogin" сопоставителя.
    /// </summary>
    public static class MapperUserLoginEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperUserLoginEntityObject FromEntityToMapperObject(
            this UserLoginEntityObject entityObject
            )
        {
            MapperUserLoginEntityObject result = new();

            new UserLoginEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static UserLoginEntityObject FromMapperToEntityObject(
            this MapperUserLoginEntityObject mapperObject
            )
        {
            UserLoginEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
