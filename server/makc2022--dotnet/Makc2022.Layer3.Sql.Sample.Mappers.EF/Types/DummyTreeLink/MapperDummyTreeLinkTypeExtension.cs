// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyTreeLink;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyTreeLink
{
    /// <summary>
    /// Расширение сущности "DummyTreeLink" сопоставителя.
    /// </summary>
    public static class MapperDummyTreeLinkTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperDummyTreeLinkTypeEntity ToMapperEntity(this DummyTreeLinkTypeEntity entity)
        {
            MapperDummyTreeLinkTypeEntity result = new();

            new DummyTreeLinkTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static DummyTreeLinkTypeEntity ToEntity(this MapperDummyTreeLinkTypeEntity mapperEntity)
        {
            DummyTreeLinkTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
