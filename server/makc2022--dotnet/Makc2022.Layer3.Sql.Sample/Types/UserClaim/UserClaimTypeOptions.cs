﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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
        /// Колонка в базе данных для поля идентификатора сущности "Пользователь".
        /// </summary>
        public string? DbColumnForUserEntityId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Пользователь".
        /// </summary>
        public string? DbForeignKeyToUserEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "Пользователь".
        /// </summary>
        public string? DbIndexForUserEntityId { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="optionsOfUserType">Параметры типа "Пользователь".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        /// <param name="dbColumnNameForUserId">Колонка в базе данных для поля "UserId".</param>
        public UserClaimTypeOptions(
            UserTypeOptions optionsOfUserType,
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null,
            string? dbColumnNameForUserId = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            DbColumnForUserEntityId = dbColumnNameForUserId ?? nameof(UserClaimTypeEntity.UserId);

            DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, optionsOfUserType.DbTable);

            DbIndexForUserEntityId = CreateDbIndexName(DbTable, DbColumnForUserEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}