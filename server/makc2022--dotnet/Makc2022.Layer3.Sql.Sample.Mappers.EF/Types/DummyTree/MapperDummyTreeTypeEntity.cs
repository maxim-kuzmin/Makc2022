// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyTree;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyTreeLink;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyTree
{
    /// <summary>
    /// Сущность типа "DummyTree" сопоставителя.
    /// </summary>
    public class MapperDummyTreeTypeEntity : DummyTreeTypeEntity
    {
        #region Properties

        /// <summary>
        /// Объект родителя сущности "DummyTree".
        /// </summary>
        public MapperDummyTreeTypeEntity? ObjectOfDummyTreeEntityParent { get; set; }

        /// <summary>
        /// Объекты ребёнка сущности "DummyTree".
        /// </summary>
        public List<MapperDummyTreeTypeEntity> ObjectsOfDummyTreeEntityChild { get; } =
            new List<MapperDummyTreeTypeEntity>();

        /// <summary>
        /// Объекты сущности "DummyTreeLink".
        /// </summary>
        public List<MapperDummyTreeLinkTypeEntity> ObjectsOfDummyTreeLinkEntity { get; } =
            new List<MapperDummyTreeLinkTypeEntity>();

        #endregion Properties
    }
}
