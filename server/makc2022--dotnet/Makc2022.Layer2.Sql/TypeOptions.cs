﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer2.Sql
{
    /// <summary>
    /// Параметры типа.
    /// </summary>
    public class TypeOptions
    {
        #region Properties

        private IDefaults Defaults { get; init; }

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public string DbTable { get; init; }

        /// <summary>
        /// Схема в базе данных.
        /// </summary>
        public string DbSchema { get; init; }

        /// <summary>
        /// Таблица со схемой в базе данных.
        /// </summary>
        public string DbTableWithSchema { get; init; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public TypeOptions(IDefaults defaults, string dbTable, string? dbSchema = null)
        {
            Defaults = defaults;
            DbTable = dbTable;
            DbSchema = dbSchema ?? CreateDbSchemaName();
            DbTableWithSchema = string.IsNullOrWhiteSpace(DbSchema) ? DbTable : CreateFullName(DbSchema, DbTable);
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Создать полное имя.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Полное имя.</returns>
        protected string CreateFullName(params string[] parts)
        {
            return string.IsNullOrEmpty(Defaults.FullNamePartsSeparator)
                ? string.Concat(parts)
                : string.Join(Defaults.FullNamePartsSeparator, parts);
        }

        /// <summary>
        /// Создать имя колонки в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя колонки в базе данных.</returns>
        protected string CreateDbColumnName(params string[] parts)
        {
            return string.IsNullOrEmpty(Defaults.DbColumnPartsSeparator)
                ? string.Concat(parts)
                : string.Join(Defaults.DbColumnPartsSeparator, parts);
        }

        /// <summary>
        /// Создать имя внешнего ключа в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя внешнего ключа в базе данных.</returns>
        protected string CreateDbForeignKeyName(params string[] parts)
        {
            return CreateName(Defaults.DbForeignKeyPrefix, parts);
        }

        /// <summary>
        /// Создать имя индекса в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя индекса в базе данных.</returns>
        protected string CreateDbIndexName(params string[] parts)
        {
            return CreateName(Defaults.DbIndexPrefix, parts);
        }

        /// <summary>
        /// Создать имя первичного ключа в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя первичного ключа в базе данных.</returns>
        protected string CreateDbPrimaryKeyName(params string[] parts)
        {
            return CreateName(Defaults.DbPrimaryKeyPrefix, parts);
        }

        /// <summary>
        /// Создать имя схемы в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя схемы в базе данных.</returns>
        protected string CreateDbSchemaName(params string[] parts)
        {
            return parts.Length > 0 ? CreateName(null, parts) : Defaults.DbSchema;
        }

        /// <summary>
        /// Создать имя уникального индекса в базе данных.
        /// </summary>
        /// <param name="parts">Части имени.</param>
        /// <returns>Имя уникального индекса в базе данных.</returns>
        protected string CreateDbUniqueIndexName(params string[] parts)
        {
            return CreateName(Defaults.DbUniqueIndexPrefix, parts);
        }

        #endregion Protected methods

        #region Private methods

        private string CreateName(string? prefix, params string[] parts)
        {
            bool isNullOrEmptyNamePartsSeparator = string.IsNullOrEmpty(Defaults.NamePartsSeparator);

            string result = isNullOrEmptyNamePartsSeparator
                ? string.Concat(parts)
                : string.Join(Defaults.NamePartsSeparator, parts);

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                result = isNullOrEmptyNamePartsSeparator
                    ? string.Concat(prefix, result)
                    : string.Concat(prefix, Defaults.NamePartsSeparator, result);
            }

            return result;
        }

        #endregion Private methods
    }
}
