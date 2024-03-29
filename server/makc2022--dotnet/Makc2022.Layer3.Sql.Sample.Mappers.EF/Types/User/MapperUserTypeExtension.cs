﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.User
{
    /// <summary>
    /// Расширение сущности "Пользователь" сопоставителя.
    /// </summary>
    public static class MapperUserTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperUserTypeEntity ToMapperEntity(this UserTypeEntity entity)
        {
            MapperUserTypeEntity result = new();

            new UserTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static UserTypeEntity ToEntity(this MapperUserTypeEntity mapperEntity)
        {
            UserTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Target;
        }

        #endregion Public methods
    }
}
