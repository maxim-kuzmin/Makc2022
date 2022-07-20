// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Db;
using Makc2022.Layer3.Sql.Sample.Entities.DummyMain;
using Makc2022.Layer3.Sql.Sample.Entities.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Параметры сущности "DummyMainDummyManyToMany".
    /// </summary>
    public class DummyMainDummyManyToManyEntityOptions : EntityOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "DummyMain".
        /// </summary>
        public string DbColumnForDummyMainEntityId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string DbColumnForDummyManyToManyEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyMain".
        /// </summary>
        public string DbForeignKeyToDummyMainEntity { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyManyToMany".
        /// </summary>
        public string DbForeignKeyToDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string DbIndexForDummyManyToManyEntityId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="optionsOfDummyMainEntity">Параметры сущности "DummyMain".</param>
        /// <param name="optionsOfDummyManyToManyEntity">Параметры сущности "DummyManyToMany".</param>
        /// <param name="dbDefaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyMainDummyManyToManyEntityOptions(
            DummyMainEntityOptions optionsOfDummyMainEntity,
            DummyManyToManyEntityOptions optionsOfDummyManyToManyEntity,
            DbDefaults dbDefaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {

            if (!string.IsNullOrWhiteSpace(optionsOfDummyMainEntity.DbColumnForId))
            {
                DbColumnForDummyMainEntityId = CreateDbColumnName(
                    optionsOfDummyMainEntity.DbTable,
                    optionsOfDummyMainEntity.DbColumnForId
                    );
            }

            if (string.IsNullOrWhiteSpace(DbColumnForDummyMainEntityId))
            {
                throw new NullReferenceException(nameof(DbColumnForDummyMainEntityId));
            }

            if (!string.IsNullOrWhiteSpace(optionsOfDummyManyToManyEntity.DbColumnForId))
            {
                DbColumnForDummyManyToManyEntityId = CreateDbColumnName(
                    optionsOfDummyManyToManyEntity.DbTable,
                    optionsOfDummyManyToManyEntity.DbColumnForId
                    );
            }

            if (string.IsNullOrWhiteSpace(DbColumnForDummyManyToManyEntityId))
            {
                throw new NullReferenceException(nameof(DbColumnForDummyManyToManyEntityId));
            }

            DbForeignKeyToDummyMainEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyMainEntity.DbTable);

            if (string.IsNullOrWhiteSpace(DbForeignKeyToDummyMainEntity))
            {
                throw new NullReferenceException(nameof(DbForeignKeyToDummyMainEntity));
            }

            DbForeignKeyToDummyManyToManyEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyManyToManyEntity.DbTable);

            if (string.IsNullOrWhiteSpace(DbForeignKeyToDummyManyToManyEntity))
            {
                throw new NullReferenceException(nameof(DbForeignKeyToDummyManyToManyEntity));
            }

            DbIndexForDummyManyToManyEntityId = CreateDbIndexName(DbTable, DbColumnForDummyManyToManyEntityId);

            if (string.IsNullOrWhiteSpace(DbIndexForDummyManyToManyEntityId))
            {
                throw new NullReferenceException(nameof(DbIndexForDummyManyToManyEntityId));
            }

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

            if (string.IsNullOrWhiteSpace(DbPrimaryKey))
            {
                throw new NullReferenceException(nameof(DbPrimaryKey));
            }
        }

        #endregion Constructors
    }
}
