// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;
using Makc2022.Layer3.Sql.Sample.Entities.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Db;

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
        /// <param name="settingOfDummyOneToManyEntity">Настройка сущности "DummyOneToMany".</param>
        /// <param name="dbDefaults">Значения по умолчанию  в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyMainEntityOptions(
            DummyOneToManyEntityOptions settingOfDummyOneToManyEntity,
            DbDefaults dbDefaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForId = dbDefaults.DbColumnForId;

            if (string.IsNullOrWhiteSpace(DbColumnForId))
            {
                throw new NullReferenceException(nameof(DbColumnForId));
            }

            DbColumnForName = dbDefaults.DbColumnForName;

            if (string.IsNullOrWhiteSpace(DbColumnForName))
            {
                throw new NullReferenceException(nameof(DbColumnForName));
            }

            DbColumnForDummyOneToManyEntityId = CreateDbColumnName(
                settingOfDummyOneToManyEntity.DbTable,
                settingOfDummyOneToManyEntity.DbColumnForId
                );

            if (string.IsNullOrWhiteSpace(DbColumnForDummyOneToManyEntityId))
            {
                throw new NullReferenceException(nameof(DbColumnForDummyOneToManyEntityId));
            }

            DbForeignKeyToDummyOneToManyEntity = CreateDbForeignKeyName(DbTable, settingOfDummyOneToManyEntity.DbTable);

            if (string.IsNullOrWhiteSpace(DbForeignKeyToDummyOneToManyEntity))
            {
                throw new NullReferenceException(nameof(DbForeignKeyToDummyOneToManyEntity));
            }

            DbIndexForDummyOneToManyEntityId = CreateDbIndexName(DbTable, DbColumnForDummyOneToManyEntityId);

            if (string.IsNullOrWhiteSpace(DbIndexForDummyOneToManyEntityId))
            {
                throw new NullReferenceException(nameof(DbIndexForDummyOneToManyEntityId));
            }

            DbMaxLengthForName = 256;

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

            if (string.IsNullOrWhiteSpace(DbPrimaryKey))
            {
                throw new NullReferenceException(nameof(DbPrimaryKey));
            }

            DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);

            if (string.IsNullOrWhiteSpace(DbUniqueIndexForName))
            {
                throw new NullReferenceException(nameof(DbUniqueIndexForName));
            }
        }

        #endregion Constructors
    }
}
