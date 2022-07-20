// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer2.Sql.Common.Db
{
    /// <summary>
    /// Общие значения по умолчанию в базе данных.
    /// </summary>
    public class CommonDbDefaults
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string? DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Name".
        /// </summary>
        public string? DbColumnForName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ParentId".
        /// </summary>
        public string? DbColumnForParentId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeChildCount".
        /// </summary>
        public string? DbColumnForTreeChildCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeDescendantCount".
        /// </summary>
        public string? DbColumnForTreeDescendantCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeLevel".
        /// </summary>
        public string? DbColumnForTreeLevel { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreePath".
        /// </summary>
        public string? DbColumnForTreePath { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreePosition".
        /// </summary>
        public string? DbColumnForTreePosition { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeSort".
        /// </summary>
        public string? DbColumnForTreeSort { get; set; }

        /// <summary>
        /// Разделитель частей имени колонки в базе данных.
        /// </summary>
        public string? DbColumnPartsSeparator { get; set; }

        /// <summary>
        /// Префикс внешнего ключа в базе данных.
        /// </summary>
        public string? DbForeignKeyPrefix { get; set; }

        /// <summary>
        /// Префикс индекса в базе данных.
        /// </summary>
        public string? DbIndexPrefix { get; set; }

        /// <summary>
        /// Префикс первичного ключа в базе данных.
        /// </summary>
        public string? DbPrimaryKeyPrefix { get; set; }

        /// <summary>
        /// Схема в базе данных.
        /// </summary>
        public string? DbSchema { get; set; }

        /// <summary>
        /// Префикс уникального индекса в базе данных.
        /// </summary>
        public string? DbUniqueIndexPrefix { get; set; }

        /// <summary>
        /// Разделитель частей полного имени.
        /// </summary>
        public string? FullNamePartsSeparator { get; set; }

        /// <summary>
        /// Разделитель частей имени.
        /// </summary>
        public string? NamePartsSeparator { get; set; }

        #endregion Properties
    }
}
