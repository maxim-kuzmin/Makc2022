// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.UserClaim;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserClaim
{
    /// <summary>
    /// Расширение сущности "UserClaim" сопоставителя.
    /// </summary>
    public static class MapperUserClaimTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperUserClaimTypeEntity ToMapperEntity(this UserClaimTypeEntity entity)
        {
            MapperUserClaimTypeEntity result = new();

            new UserClaimTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static UserClaimTypeEntity ToEntity(this MapperUserClaimTypeEntity mapperEntity)
        {
            UserClaimTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
