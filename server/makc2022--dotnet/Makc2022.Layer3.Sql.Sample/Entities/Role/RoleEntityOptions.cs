// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql;

namespace Makc2022.Layer3.Sql.Sample.Entities.Role
{
    /// <summary>
    /// Параметры сущности "Role".
    /// </summary>
    public class RoleEntityOptions : TypeOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "ConcurrencyStamp".
        /// </summary>
        public string? DbColumnForConcurrencyStamp { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string? DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Name".
        /// </summary>
        public string? DbColumnForName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "NormalizedName".
        /// </summary>
        public string? DbColumnForNormalizedName { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        /// <summary>
        /// Уникальный индекс в базе данных для поля "NormalizedName".
        /// </summary>
        public string? DbUniqueIndexForNormalizedName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public RoleEntityOptions(
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null,
            string? dbColumnNameForNormalizedName = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            DbColumnForName = defaults.DbColumnForName;
            
            DbColumnForNormalizedName = dbColumnNameForNormalizedName ?? nameof(RoleEntityObject.NormalizedName);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

            DbUniqueIndexForNormalizedName = CreateDbUniqueIndexName(DbTable, DbColumnForNormalizedName);
        }

        #endregion Constructors
    }
}
