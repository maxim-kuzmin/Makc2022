// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer2.Sql;
using Makc2022.Layer2.Sql.Entity;
using Makc2022.Layer3.Sql.Sample.Entities.Role;

namespace Makc2022.Layer3.Sql.Sample.Entities.RoleClaim
{
    /// <summary>
    /// Параметры сущности "RoleClaim".
    /// </summary>
    public class RoleClaimEntityOptions : EntityOptions
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
        /// Колонка в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string? DbColumnForRoleEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string? DbForeignKeyToRoleEntity { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string? DbPrimaryKey { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string? DbUniqueIndexForRoleEntityId { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="optionsOfRoleEntity">Параметры сущности "Role".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public RoleClaimEntityOptions(
            RoleEntityOptions optionsOfRoleEntity,
            IDefaults defaults,
            string dbTable,
            string? dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            if (string.IsNullOrWhiteSpace(optionsOfRoleEntity.DbColumnForId))
            {
                throw new NullOrWhiteSpaceStringVariableException<RoleClaimEntityOptions>(
                    nameof(optionsOfRoleEntity),
                    nameof(optionsOfRoleEntity.DbColumnForId));
            }

            DbColumnForRoleEntityId = CreateDbColumnName(
                optionsOfRoleEntity.DbTable,
                optionsOfRoleEntity.DbColumnForId
                );

            DbForeignKeyToRoleEntity = CreateDbForeignKeyName(DbTable, optionsOfRoleEntity.DbTable);

            DbUniqueIndexForRoleEntityId = CreateDbUniqueIndexName(DbTable, DbColumnForRoleEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
