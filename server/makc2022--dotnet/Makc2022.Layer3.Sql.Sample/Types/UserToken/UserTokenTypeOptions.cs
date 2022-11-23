// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql;
using Makc2022.Layer3.Sql.Sample.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Types.UserToken
{
    /// <summary>
    /// Параметры типа "Токен пользователя".
    /// </summary>
    public class UserTokenTypeOptions : TypeOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "LoginProvider".
        /// </summary>
        public string? DbColumnForLoginProvider { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Name".
        /// </summary>
        public string? DbColumnForName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "UserId".
        /// </summary>
        public string? DbColumnForUserId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Value".
        /// </summary>
        public string? DbColumnForValue { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к типу "Пользователь".
        /// </summary>
        public string? DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="userTypeOptions">Параметры типа "Пользователь".</param>
        /// <param name="dbDefaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserTokenTypeOptions(
            UserTypeOptions userTypeOptions,
            IDefaults dbDefaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForName = dbDefaults.DbColumnForName;

            DbForeignKeyToUser = CreateDbForeignKeyName(DbTable, userTypeOptions.DbTable);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
