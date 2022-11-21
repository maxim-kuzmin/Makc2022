// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;
using Makc2022.Layer3.Sql.Sample.Entities.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Db;
using Makc2022.Layer1.Exceptions.VariableExceptions;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyMain
{
    /// <summary>
    /// Параметры сущности "DummyMain".
    /// </summary>
    public class DummyMainEntityOptions : EntityOptions
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
        /// Колонка в базе данных для поля идентификатора сущности "DummyOneToMany".
        /// </summary>
        public string? DbColumnForDummyOneToManyEntityId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropBoolean".
        /// </summary>
        public string? DbColumnForPropBoolean { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropBooleanNullable".
        /// </summary>
        public string? DbColumnForPropBooleanNullable { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropDate".
        /// </summary>
        public string? DbColumnForPropDate { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropDateNullable".
        /// </summary>
        public string? DbColumnForPropDateNullable { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropDateTimeOffset".
        /// </summary>
        public string? DbColumnForPropDateTimeOffset { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropDateTimeOffsetNullable".
        /// </summary>
        public string? DbColumnForPropDateTimeOffsetNullable { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropDecimal".
        /// </summary>
        public string? DbColumnForPropDecimal { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropDecimalNullable".
        /// </summary>
        public string? DbColumnForPropDecimalNullable { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropInt32".
        /// </summary>
        public string? DbColumnForPropInt32 { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropInt32Nullable".
        /// </summary>
        public string? DbColumnForPropInt32Nullable { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropInt64".
        /// </summary>
        public string? DbColumnForPropInt64 { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropInt64Nullable".
        /// </summary>
        public string? DbColumnForPropInt64Nullable { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropString".
        /// </summary>
        public string? DbColumnForPropString { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PropStringNullable".
        /// </summary>
        public string? DbColumnForPropStringNullable { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyOneToMany".
        /// </summary>
        public string? DbForeignKeyToDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "DummyOneToMany".
        /// </summary>
        public string? DbIndexForDummyOneToManyEntityId { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "Name".
        /// </summary>
        public int DbMaxLengthForName { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        /// <summary>
        /// Уникальный индекс в базе данных для поля "Name".
        /// </summary>
        public string? DbUniqueIndexForName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="optionsOfDummyOneToManyEntity">Параметры сущности "DummyOneToMany".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyMainEntityOptions(
            DummyOneToManyEntityOptions optionsOfDummyOneToManyEntity,
            DbDefaults defaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            if (string.IsNullOrWhiteSpace(defaults.DbColumnForName))
            {
                throw new NullOrWhiteSpaceStringVariableException<DummyMainEntityOptions>(
                    nameof(defaults),
                    nameof(defaults.DbColumnForName));
            }

            DbColumnForName = defaults.DbColumnForName;

            if (string.IsNullOrWhiteSpace(optionsOfDummyOneToManyEntity.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<DummyMainEntityOptions>(
                    nameof(optionsOfDummyOneToManyEntity),
                    nameof(optionsOfDummyOneToManyEntity.DbColumnForId));
            }

            DbColumnForDummyOneToManyEntityId = CreateDbColumnName(
                optionsOfDummyOneToManyEntity.DbTable,
                optionsOfDummyOneToManyEntity.DbColumnForId);

            DbForeignKeyToDummyOneToManyEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyOneToManyEntity.DbTable);

            DbIndexForDummyOneToManyEntityId = CreateDbIndexName(DbTable, DbColumnForDummyOneToManyEntityId);

            DbMaxLengthForName = 256;

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

            DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);
        }

        #endregion Constructors
    }
}
