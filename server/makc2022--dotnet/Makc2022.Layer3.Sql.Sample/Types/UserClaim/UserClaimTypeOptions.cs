// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql;
using Makc2022.Layer3.Sql.Sample.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Types.UserClaim
{
    /// <summary>
    /// Параметры типа "Утверждение пользователя".
    /// </summary>
    public class UserClaimTypeOptions : TypeOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "ClaimType".
        /// </summary>
        public string? DbColumnForClaimType { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ClaimValue".
        /// </summary>
        public string? DbColumnForClaimValue { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string? DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "UserId".
        /// </summary>
        public string? DbColumnForUserId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к типу "Пользователь".
        /// </summary>
        public string? DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля "UserId".
        /// </summary>
        public string? DbIndexForUserId { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="userTypeOptions">Параметры типа "Пользователь".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        /// <param name="dbColumnNameForUserId">Колонка в базе данных для поля "UserId".</param>
        public UserClaimTypeOptions(
            UserTypeOptions userTypeOptions,
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null,
            string? dbColumnNameForUserId = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            DbColumnForUserId = dbColumnNameForUserId ?? nameof(UserClaimTypeEntity.UserId);

            DbForeignKeyToUser = CreateDbForeignKeyName(DbTable, userTypeOptions.DbTable);

            DbIndexForUserId = CreateDbIndexName(DbTable, DbColumnForUserId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
