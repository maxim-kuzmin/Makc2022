// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
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
        public string? DbColumnForDummyMainEntityId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string? DbColumnForDummyManyToManyEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyMain".
        /// </summary>
        public string? DbForeignKeyToDummyMainEntity { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyManyToMany".
        /// </summary>
        public string? DbForeignKeyToDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string? DbIndexForDummyManyToManyEntityId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="optionsOfDummyMainEntity">Параметры сущности "DummyMain".</param>
        /// <param name="optionsOfDummyManyToManyEntity">Параметры сущности "DummyManyToMany".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyMainDummyManyToManyEntityOptions(
            DummyMainEntityOptions optionsOfDummyMainEntity,
            DummyManyToManyEntityOptions optionsOfDummyManyToManyEntity,
            DbDefaults defaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            if (string.IsNullOrWhiteSpace(optionsOfDummyMainEntity.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<DummyMainDummyManyToManyEntityOptions>(
                    nameof(optionsOfDummyMainEntity),
                    nameof(optionsOfDummyMainEntity.DbColumnForId));
            }

            DbColumnForDummyMainEntityId = CreateDbColumnName(
                optionsOfDummyMainEntity.DbTable,
                optionsOfDummyMainEntity.DbColumnForId);

            if (string.IsNullOrWhiteSpace(optionsOfDummyManyToManyEntity.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<DummyMainDummyManyToManyEntityOptions>(
                    nameof(optionsOfDummyManyToManyEntity),
                    nameof(optionsOfDummyManyToManyEntity.DbColumnForId));
            }

            DbColumnForDummyManyToManyEntityId = CreateDbColumnName(
                optionsOfDummyManyToManyEntity.DbTable,
                optionsOfDummyManyToManyEntity.DbColumnForId);


            DbForeignKeyToDummyMainEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyMainEntity.DbTable);

            DbForeignKeyToDummyManyToManyEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyManyToManyEntity.DbTable);

            DbIndexForDummyManyToManyEntityId = CreateDbIndexName(DbTable, DbColumnForDummyManyToManyEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
