// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions;
using Makc2022.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole
{
    /// <summary>
    /// Схема сущности "UserRole" сопоставителя.
    /// </summary>
    public class MapperUserRoleEntitySchema : MapperSchema<MapperUserRoleEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserRoleEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserRoleEntityObject> builder)
        {
            var options = EntitiesOptions.UserRole;

            if (options is null)
            {
                throw new NullVariableException(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => new { x.UserId, x.RoleId }).HasName(options.DbPrimaryKey);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(options.DbColumnForUserEntityId);

            builder.Property(x => x.RoleId)
                .IsRequired()
                .HasColumnName(options.DbColumnForRoleEntityId);

            builder.HasIndex(x => x.RoleId).HasDatabaseName(options.DbIndexForRoleEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserRoleEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(options.DbForeignKeyToUserEntity);

            builder.HasOne(x => x.ObjectOfRoleEntity)
                .WithMany(x => x.ObjectsOfUserRoleEntity)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(options.DbForeignKeyToRoleEntity);
        }

        #endregion Public methods    
    }
}
