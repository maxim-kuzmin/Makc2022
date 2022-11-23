// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.RoleClaim
{
    /// <summary>
    /// Конфигурация типа "Утверждение роли" для сопоставителя.
    /// </summary>
    public class MapperRoleClaimTypeConfiguration : MapperTypeConfiguration<MapperRoleClaimTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperRoleClaimTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperRoleClaimTypeEntity> builder)
        {
            var options = TypesOptions.RoleClaim;

            if (options is null)
            {
                throw new NullVariableException<MapperRoleClaimTypeConfiguration>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => x.Id).HasName(options.DbPrimaryKey);

            builder.Property(x => x.ClaimType)
                .HasColumnName(options.DbColumnForClaimType);

            builder.Property(x => x.ClaimValue)
                .HasColumnName(options.DbColumnForClaimValue);

            builder.Property(x => x.Id)
                .HasColumnName(options.DbColumnForId);

            builder.Property(x => x.RoleId)
                .HasColumnName(options.DbColumnForRoleId);

            builder.HasIndex(x => x.RoleId).IsUnique().HasDatabaseName(options.DbUniqueIndexForRoleId);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.RoleClaimList)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(options.DbForeignKeyToRole);
        }

        #endregion Public methods    
    }
}
