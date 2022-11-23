// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer2.Sql;
using Makc2022.Layer3.Sql.Sample.Types.Role;
using Makc2022.Layer3.Sql.Sample.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Types.UserRole
{
    /// <summary>
    /// Параметры типа "Роль пользователя".
    /// </summary>
    public class UserRoleTypeOptions : TypeOptions
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "RoleId".
        /// </summary>
        public string? DbColumnForRoleId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "UserId".
        /// </summary>
        public string? DbColumnForUserId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к типу "Роль".
        /// </summary>
        public string? DbForeignKeyToRole { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к типу "Пользователь".
        /// </summary>
        public string? DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля "RoleId".
        /// </summary>
        public string? DbIndexForRoleId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="roleTypeOptions">Параметры типа "Роль".</param>
        /// <param name="userTypeOptions">Параметры типа "Пользователь".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserRoleTypeOptions(
            RoleTypeOptions roleTypeOptions,
            UserTypeOptions userTypeOptions,
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            if (string.IsNullOrWhiteSpace(roleTypeOptions.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<UserRoleTypeOptions>(
                    nameof(roleTypeOptions),
                    nameof(roleTypeOptions.DbColumnForId));
            }

            DbColumnForRoleId = CreateDbColumnName(roleTypeOptions.DbTable, roleTypeOptions.DbColumnForId);

            if (string.IsNullOrWhiteSpace(userTypeOptions.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<UserRoleTypeOptions>(
                    nameof(userTypeOptions),
                    nameof(userTypeOptions.DbColumnForId));
            }

            DbColumnForUserId = CreateDbColumnName(userTypeOptions.DbTable, userTypeOptions.DbColumnForId);

            DbForeignKeyToRole = CreateDbForeignKeyName(DbTable, roleTypeOptions.DbTable);

            DbForeignKeyToUser = CreateDbForeignKeyName(DbTable, userTypeOptions.DbTable);

            DbIndexForRoleId = CreateDbIndexName(DbTable, DbColumnForRoleId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
