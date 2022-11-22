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
        #region Properties

        /// <summary>
        /// Сущность типа "Фиктивное дерево".
        /// </summary>
        public MapperDummyTreeTypeEntity? ObjectOfDummyTreeEntity { get; set; }

        #endregion Properties
    }
}
