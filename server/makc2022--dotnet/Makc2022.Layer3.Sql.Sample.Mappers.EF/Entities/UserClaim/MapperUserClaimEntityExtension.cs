// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.UserClaim;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim
{
    /// <summary>
    /// Расширение сущности "UserClaim" сопоставителя.
    /// </summary>
    public static class MapperUserClaimEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperUserClaimEntityObject FromEntityToMapperObject(
            this UserClaimEntityObject entityObject
            )
        {
            MapperUserClaimEntityObject result = new();

            new UserClaimEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static UserClaimEntityObject FromMapperToEntityObject(
            this MapperUserClaimEntityObject mapperObject
            )
        {
            UserClaimEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
