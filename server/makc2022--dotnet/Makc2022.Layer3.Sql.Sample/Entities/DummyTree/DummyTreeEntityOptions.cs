// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Db;
using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyTree
{
    /// <summary>
    /// Параметры сущности "DummyTree".
    /// </summary>
    public class DummyTreeEntityOptions : EntityOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Name".
        /// </summary>
        public string DbColumnForName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора родителя сущности "DummyTree".
        /// </summary>
        public string DbColumnForDummyTreeEntityParentId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeChildCount".
        /// </summary>
        public string DbColumnForTreeChildCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeDescendantCount".
        /// </summary>
        public string DbColumnForTreeDescendantCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeLevel".
        /// </summary>
        public string DbColumnForTreeLevel { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreePath".
        /// </summary>
        public string DbColumnForTreePath { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreePosition".
        /// </summary>
        public string DbColumnForTreePosition { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeSort".
        /// </summary>
        public string DbColumnForTreeSort { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к родителю сущности "DummyTree".
        /// </summary>
        public string DbForeignKeyToDummyTreeEntityParent { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля "Name".
        /// </summary>
        public string DbIndexForName { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора родителя сущности "DummyTree".
        /// </summary>
        public string DbIndexForDummyTreeEntityParentId { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля "TreeSort".
        /// </summary>
        public string DbIndexForTreeSort { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "Name".
        /// </summary>
        public int DbMaxLengthForName { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "TreePath".
        /// </summary>
        public int DbMaxLengthForTreePath { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "TreeSort".
        /// </summary>
        public int DbMaxLengthForTreeSort { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Индекс в базе данных для полей идентификатора родителя сущности "DummyTree" и "Name".
        /// </summary>
        public string DbUniqueIndexForDummyTreeEntityParentIdAndName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dbDefaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyTreeEntityOptions(
            DbDefaults dbDefaults,
            string dbTable,
            string dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForId = dbDefaults.DbColumnForId;
            DbColumnForName = dbDefaults.DbColumnForName;
            DbColumnForDummyTreeEntityParentId = dbDefaults.DbColumnForParentId;
            DbColumnForTreeChildCount = dbDefaults.DbColumnForTreeChildCount;
            DbColumnForTreeDescendantCount = dbDefaults.DbColumnForTreeDescendantCount;
            DbColumnForTreeLevel = dbDefaults.DbColumnForTreeLevel;
            DbColumnForTreePath = dbDefaults.DbColumnForTreePath;
            DbColumnForTreePosition = dbDefaults.DbColumnForTreePosition;
            DbColumnForTreeSort = dbDefaults.DbColumnForTreeSort;

            DbForeignKeyToDummyTreeEntityParent = CreateDbForeignKeyName(DbTable, DbTable, DbColumnForDummyTreeEntityParentId);

            DbIndexForName = CreateDbIndexName(DbTable, DbColumnForName);
            DbIndexForDummyTreeEntityParentId = CreateDbIndexName(DbTable, DbColumnForDummyTreeEntityParentId);
            DbIndexForTreeSort = CreateDbIndexName(DbTable, DbColumnForTreeSort);

            DbMaxLengthForName = 256;
            DbMaxLengthForTreePath = 900;
            DbMaxLengthForTreeSort = 900;

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

            DbUniqueIndexForDummyTreeEntityParentIdAndName = CreateDbUniqueIndexName(
                DbTable,
                DbColumnForDummyTreeEntityParentId,
                DbColumnForName
                );
        }

        #endregion Constructors
    }
}
