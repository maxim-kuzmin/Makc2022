// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyTree
{
    /// <summary>
    /// Объект сущности "DummyTree".
    /// </summary>
    public class DummyTreeEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Идентификатор родителя.
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Число детей в дереве.
        /// </summary>
        public long TreeChildCount { get; set; }

        /// <summary>
        /// Число потомков в дереве.
        /// </summary>
        public long TreeDescendantCount { get; set; }

        /// <summary>
        /// Уровень в дереве.
        /// </summary>
        public long TreeLevel { get; set; }

        /// <summary>
        /// Путь в дереве.
        /// </summary>
        public string? TreePath { get; set; }

        /// <summary>
        /// Позиция в дереве.
        /// </summary>
        public int TreePosition { get; set; }

        /// <summary>
        /// Сортировка в дереве.
        /// </summary>
        public string? TreeSort { get; set; }

        #endregion Properties
    }
}
