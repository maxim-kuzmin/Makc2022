// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyTreeLink
{
    /// <summary>
    /// Сущность типа "DummyTreeLink".
    /// </summary>
    public class DummyTreeLinkTypeEntity
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор родителя.
        /// </summary>
        public long ParentId { get; set; }

        #endregion Properties
    }
}
