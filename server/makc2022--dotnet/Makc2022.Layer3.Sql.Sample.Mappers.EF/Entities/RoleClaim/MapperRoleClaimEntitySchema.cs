// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions;
using Makc2022.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Схема сущности "RoleClaim" для сопоставителя.
    /// </summary>
    public class MapperRoleClaimEntitySchema : MapperSchema<MapperRoleClaimEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperRoleClaimEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperRoleClaimEntityObject> builder)
        {
            var options = EntitiesOptions.RoleClaim;

            if (options is null)
            {
                throw new NullVariableException(nameof(options));
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
                .HasColumnName(options.DbColumnForRoleEntityId);

            builder.HasIndex(x => x.RoleId).IsUnique().HasDatabaseName(options.DbUniqueIndexForRoleEntityId);

            builder.HasOne(x => x.ObjectOfRoleEntity)
                .WithMany(x => x.ObjectsOfRoleClaimEntity)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(options.DbForeignKeyToRoleEntity);
        }

        #endregion Public methods    
    }
}
