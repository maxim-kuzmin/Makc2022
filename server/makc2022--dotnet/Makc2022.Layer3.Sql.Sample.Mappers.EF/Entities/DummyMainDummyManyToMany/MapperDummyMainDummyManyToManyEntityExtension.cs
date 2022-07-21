// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyMainDummyManyToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Расширение сущности "DummyMainDummyManyToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyMainDummyManyToManyEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperDummyMainDummyManyToManyEntityObject FromEntityToMapperObject(
            this DummyMainDummyManyToManyEntityObject entityObject
            )
        {
            MapperDummyMainDummyManyToManyEntityObject result = new();

            new DummyMainDummyManyToManyEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static DummyMainDummyManyToManyEntityObject FromMapperToEntityObject(
            this MapperDummyMainDummyManyToManyEntityObject mapperObject
            )
        {
            DummyMainDummyManyToManyEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
