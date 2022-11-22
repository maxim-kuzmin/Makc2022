// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyManyToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyManyToMany
{
    /// <summary>
    /// Расширение типа "DummyManyToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyManyToManyTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperDummyManyToManyTypeEntity ToMapperEntity(this DummyManyToManyTypeEntity entity)
        {
            MapperDummyManyToManyTypeEntity result = new();

            new DummyManyToManyTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static DummyManyToManyTypeEntity ToEntity(this MapperDummyManyToManyTypeEntity mapperEntity)
        {
            DummyManyToManyTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
