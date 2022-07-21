// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyTreeLink;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Расширение сущности "DummyTreeLink" сопоставителя.
    /// </summary>
    public static class MapperDummyTreeLinkEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperDummyTreeLinkEntityObject FromEntityToMapperObject(
            this DummyTreeLinkEntityObject entityObject
            )
        {
            MapperDummyTreeLinkEntityObject result = new();

            new DummyTreeLinkEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static DummyTreeLinkEntityObject FromMapperToEntityObject(
            this MapperDummyTreeLinkEntityObject mapperObject
            )
        {
            DummyTreeLinkEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
