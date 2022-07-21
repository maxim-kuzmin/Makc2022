// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyOneToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Расширение сущности "DummyOneToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyOneToManyEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperDummyOneToManyEntityObject FromEntityToMapperObject(
            this DummyOneToManyEntityObject entityObject
            )
        {
            MapperDummyOneToManyEntityObject result = new();

            new DummyOneToManyEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static DummyOneToManyEntityObject FromMapperToEntityObject(
            this MapperDummyOneToManyEntityObject mapperObject
            )
        {
            DummyOneToManyEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
