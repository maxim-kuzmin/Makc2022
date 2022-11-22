// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer2.Sql;
using Makc2022.Layer3.Sql.Sample.Types.Role;
using Makc2022.Layer3.Sql.Sample.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Types.UserRole
{
    /// <summary>
    /// Параметры типа "UserRole".
    /// </summary>
    public class UserRoleTypeOptions : TypeOptions
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
        /// <param name="optionsOfRoleType">Параметры типа "Role".</param>
        /// <param name="optionsOfUserType">Параметры типа "User".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserRoleTypeOptions(
            RoleTypeOptions optionsOfRoleType,
            UserTypeOptions optionsOfUserType,
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            if (string.IsNullOrWhiteSpace(optionsOfRoleType.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<UserRoleTypeOptions>(
                    nameof(optionsOfRoleType),
                    nameof(optionsOfRoleType.DbColumnForId));
            }

            DbColumnForRoleEntityId = CreateDbColumnName(optionsOfRoleType.DbTable, optionsOfRoleType.DbColumnForId);

            if (string.IsNullOrWhiteSpace(optionsOfUserType.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<UserRoleTypeOptions>(
                    nameof(optionsOfUserType),
                    nameof(optionsOfUserType.DbColumnForId));
            }

            DbColumnForUserEntityId = CreateDbColumnName(optionsOfUserType.DbTable, optionsOfUserType.DbColumnForId);

            DbForeignKeyToRoleEntity = CreateDbForeignKeyName(DbTable, optionsOfRoleType.DbTable);

            DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, optionsOfUserType.DbTable);

            DbIndexForRoleEntityId = CreateDbIndexName(DbTable, DbColumnForRoleEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
