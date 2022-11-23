// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyTreeLink;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyTree;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyTreeLink
{
    /// <summary>
    /// Сущность типа "Связь фиктивного дерева" сопоставителя.
    /// </summary>
    public class MapperDummyTreeLinkTypeEntity : DummyTreeLinkTypeEntity
    {
        #region Navigation properties

        /// <summary>
        ///  Экземпляр сущности "Фиктивное дерево" по идентификатору.
        /// </summary>
        public MapperDummyTreeTypeEntity? DummyTreeById { get; set; }

        /// <summary>
        ///  Экземпляр сущности "Фиктивное дерево" по идентификатору родителя.
        /// </summary>
        public MapperDummyTreeTypeEntity? DummyTreeByParentId { get; set; }

        #endregion Navigation properties
    }
}
