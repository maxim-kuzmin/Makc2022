// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyManyToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Расширение сущности "DummyManyToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyManyToManyEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperDummyManyToManyEntityObject FromEntityToMapperObject(
            this DummyManyToManyEntityObject entityObject
            )
        {
            MapperDummyManyToManyEntityObject result = new();

            new DummyManyToManyEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static DummyManyToManyEntityObject FromMapperToEntityObject(
            this MapperDummyManyToManyEntityObject mapperObject
            )
        {
            DummyManyToManyEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
