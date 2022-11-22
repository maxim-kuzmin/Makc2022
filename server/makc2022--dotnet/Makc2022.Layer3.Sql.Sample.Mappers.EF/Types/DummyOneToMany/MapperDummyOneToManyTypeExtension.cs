// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyOneToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyOneToMany
{
    /// <summary>
    /// Расширение сущности "DummyOneToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyOneToManyTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperDummyOneToManyTypeEntity ToMapperEntity(this DummyOneToManyTypeEntity entity)
        {
            MapperDummyOneToManyTypeEntity result = new();

            new DummyOneToManyTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static DummyOneToManyTypeEntity ToEntity(this MapperDummyOneToManyTypeEntity mapperEntity)
        {
            DummyOneToManyTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
