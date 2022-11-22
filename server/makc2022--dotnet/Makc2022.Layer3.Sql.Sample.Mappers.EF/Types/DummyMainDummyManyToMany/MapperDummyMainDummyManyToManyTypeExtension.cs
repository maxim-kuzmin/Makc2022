// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany
{
    /// <summary>
    /// Расширение типа "DummyMainDummyManyToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyMainDummyManyToManyTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperDummyMainDummyManyToManyTypeEntity ToMapperEntity(this DummyMainDummyManyToManyTypeEntity entity)
        {
            MapperDummyMainDummyManyToManyTypeEntity result = new();

            new DummyMainDummyManyToManyTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static DummyMainDummyManyToManyTypeEntity ToEntity(this MapperDummyMainDummyManyToManyTypeEntity mapperEntity)
        {
            DummyMainDummyManyToManyTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
