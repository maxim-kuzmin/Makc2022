// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql;
using Makc2022.Layer3.Sql.Sample.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Types.UserLogin
{
    /// <summary>
    /// Параметры типа "Вход пользователя".
    /// </summary>
    public class UserLoginTypeOptions : TypeOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "LoginProvider".
        /// </summary>
        public string? DbColumnForLoginProvider { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ProviderKey".
        /// </summary>
        public string? DbColumnForProviderKey { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ProviderDisplayName".
        /// </summary>
        public string? DbColumnForProviderDisplayName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "Пользователь".
        /// </summary>
        public string? DbColumnForUserEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Пользователь".
        /// </summary>
        public string? DbForeignKeyToUserEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "Пользователь".
        /// </summary>
        public string? DbIndexForUserEntityId { get; set; }

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
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserLoginTypeOptions(
            UserTypeOptions userTypeOptions,
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null,
            string? dbColumnNameForUserId = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForUserEntityId = dbColumnNameForUserId ?? nameof(UserLoginTypeEntity.UserId);

            DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, userTypeOptions.DbTable);

            DbIndexForUserEntityId = CreateDbIndexName(DbTable, DbColumnForUserEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
