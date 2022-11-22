// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.UserToken;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserToken
{
    /// <summary>
    /// Расширение сущности "Токен пользователя" сопоставителя.
    /// </summary>
    public static class MapperUserTokenTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperUserTokenTypeEntity ToMapperEntity(this UserTokenTypeEntity entity)
        {
            MapperUserTokenTypeEntity result = new();

            new UserTokenTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static UserTokenTypeEntity ToEntity(this MapperUserTokenTypeEntity mapperEntity)
        {
            UserTokenTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
