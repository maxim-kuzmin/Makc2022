﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Db;
using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyManyToMany
{
    /// <summary>
    /// Параметры сущности "DummyManyToMany".
    /// </summary>
    public class DummyManyToManyEntityOptions : EntityOptions
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
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyManyToManyEntityOptions(
            DbDefaults defaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            if (string.IsNullOrWhiteSpace(DbColumnForId))
            {
                throw new NullReferenceException(nameof(DbColumnForId));
            }

            DbColumnForName = defaults.DbColumnForName;

            if (string.IsNullOrWhiteSpace(DbColumnForName))
            {
                throw new NullReferenceException(nameof(DbColumnForName));
            }

            DbMaxLengthForName = 256;

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

            if (string.IsNullOrWhiteSpace(DbPrimaryKey))
            {
                throw new NullReferenceException(nameof(DbPrimaryKey));
            }

            DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);
        }

        #endregion Constructors
    }
}
