// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserRole
{
    /// <summary>
    /// Конфигурация типа "Роль пользователя" сопоставителя.
    /// </summary>
    public class MapperUserRoleTypeConfiguration : MapperTypeConfiguration<MapperUserRoleTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserRoleTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserRoleTypeEntity> builder)
        {
            var options = TypesOptions.UserRole;

            if (options is null)
            {
                throw new NullVariableException<MapperUserRoleTypeConfiguration>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => new { x.UserId, x.RoleId }).HasName(options.DbPrimaryKey);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(options.DbColumnForUserId);

            builder.Property(x => x.RoleId)
                .IsRequired()
                .HasColumnName(options.DbColumnForRoleId);

            builder.HasIndex(x => x.RoleId).HasDatabaseName(options.DbIndexForRoleId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserRoleList)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(options.DbForeignKeyToUser);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserRoleList)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(options.DbForeignKeyToRole);
        }

        #endregion Public methods    
    }
}
