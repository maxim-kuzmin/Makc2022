// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql;
using Makc2022.Layer3.Sql.Sample.Entities.DummyTree;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Параметры сущности "DummyTreeLink".
    /// </summary>
    public class DummyTreeLinkEntityOptions : TypeOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string? DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора родителя сущности "DummyTreeEntity".
        /// </summary>
        public string? DbColumnForDummyTreeEntityParentId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyTree".
        /// </summary>
        public string? DbForeignKeyToDummyTreeEntity { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="optionsOfDummyTreeEntity">Параметры сущности "DummyTree".</param>
        /// <param name="defaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyTreeLinkEntityOptions(
            DummyTreeEntityOptions optionsOfDummyTreeEntity,
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            DbColumnForDummyTreeEntityParentId = defaults.DbColumnForParentId;

            DbForeignKeyToDummyTreeEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyTreeEntity.DbTable);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
