// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql;
using Makc2022.Layer2.Sql.Entity;
using Makc2022.Layer3.Sql.Sample.Entities.User;

namespace Makc2022.Layer3.Sql.Sample.Entities.UserClaim
{
    /// <summary>
    /// Параметры сущности "UserClaim".
    /// </summary>
    public class UserClaimEntityOptions : EntityOptions
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
        /// Колонка в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string? DbColumnForUserEntityId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string? DbForeignKeyToUserEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string? DbIndexForUserEntityId { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="optionsOfUserEntity">Параметры сущности "User".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        /// <param name="dbColumnNameForUserId">Колонка в базе данных для поля "UserId".</param>
        public UserClaimEntityOptions(
            UserEntityOptions optionsOfUserEntity,
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null,
            string? dbColumnNameForUserId = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            DbColumnForUserEntityId = dbColumnNameForUserId ?? nameof(UserClaimEntityObject.UserId);

            DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, optionsOfUserEntity.DbTable);

            DbIndexForUserEntityId = CreateDbIndexName(DbTable, DbColumnForUserEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
