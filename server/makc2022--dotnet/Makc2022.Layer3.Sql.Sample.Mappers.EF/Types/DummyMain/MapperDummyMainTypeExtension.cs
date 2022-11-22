// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyMain;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain
{
    /// <summary>
    /// Расширение типа "Фиктивное главное" сопоставителя.
    /// </summary>
    public static class MapperDummyMainTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperDummyMainTypeEntity ToMapperEntity(this DummyMainTypeEntity entity)
        {
            MapperDummyMainTypeEntity result = new();

            new DummyMainTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static DummyMainTypeEntity ToEntity(this MapperDummyMainTypeEntity mapperEntity)
        {
            DummyMainTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
