// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer3.Sql.Sample.Db;
using Makc2022.Layer3.Sql.Sample.Entities.Role;
using Makc2022.Layer3.Sql.Sample.Entities.User;
using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.UserRole
{
    /// <summary>
    /// Параметры сущности "UserRole".
    /// </summary>
    public class UserRoleEntityOptions : EntityOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string? DbColumnForRoleEntityId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string? DbColumnForUserEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string? DbForeignKeyToRoleEntity { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string? DbForeignKeyToUserEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "RoleId".
        /// </summary>
        public string? DbIndexForRoleEntityId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="optionsOfRoleEntity">Параметры сущности "Role".</param>
        /// <param name="optionsOfUserEntity">Параметры сущности "User".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserRoleEntityOptions(
            RoleEntityOptions optionsOfRoleEntity,
            UserEntityOptions optionsOfUserEntity,
            DbDefaults defaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            if (string.IsNullOrWhiteSpace(optionsOfRoleEntity.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<UserRoleEntityOptions>(
                    nameof(optionsOfRoleEntity),
                    nameof(optionsOfRoleEntity.DbColumnForId));
            }

            DbColumnForRoleEntityId = CreateDbColumnName(optionsOfRoleEntity.DbTable, optionsOfRoleEntity.DbColumnForId);

            if (string.IsNullOrWhiteSpace(optionsOfUserEntity.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<UserRoleEntityOptions>(
                    nameof(optionsOfUserEntity),
                    nameof(optionsOfUserEntity.DbColumnForId));
            }

            DbColumnForUserEntityId = CreateDbColumnName(optionsOfUserEntity.DbTable, optionsOfUserEntity.DbColumnForId);

            DbForeignKeyToRoleEntity = CreateDbForeignKeyName(DbTable, optionsOfRoleEntity.DbTable);

            DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, optionsOfUserEntity.DbTable);

            DbIndexForRoleEntityId = CreateDbIndexName(DbTable, DbColumnForRoleEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
