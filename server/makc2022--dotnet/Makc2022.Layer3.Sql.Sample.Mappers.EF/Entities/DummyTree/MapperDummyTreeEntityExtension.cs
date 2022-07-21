// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyTree;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree
{
    /// <summary>
    /// Расширение сущности "DummyTree" сопоставителя.
    /// </summary>
    public static class MapperDummyTreeEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperDummyTreeEntityObject FromEntityToMapperObject(
            this DummyTreeEntityObject entityObject
            )
        {
            MapperDummyTreeEntityObject result = new();

            new DummyTreeEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static DummyTreeEntityObject FromMapperToEntityObject(
            this MapperDummyTreeEntityObject mapperObject
            )
        {
            DummyTreeEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
