// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.UserLogin;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserLogin
{
    /// <summary>
    /// Расширение сущности "Вход пользователя" сопоставителя.
    /// </summary>
    public static class MapperUserLoginTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperUserLoginTypeEntity ToMapperEntity(this UserLoginTypeEntity entity)
        {
            MapperUserLoginTypeEntity result = new();

            new UserLoginTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static UserLoginTypeEntity ToEntity(this MapperUserLoginTypeEntity mapperEntity)
        {
            UserLoginTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Target;
        }

        #endregion Public methods
    }
}
