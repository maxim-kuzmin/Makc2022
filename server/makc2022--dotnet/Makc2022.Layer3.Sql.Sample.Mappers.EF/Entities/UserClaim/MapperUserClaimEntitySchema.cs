// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions;
using Makc2022.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim
{
    /// <summary>
    /// Схема сущности "UserClaim" сопоставителя.
    /// </summary>
    public class MapperUserClaimEntitySchema : MapperSchema<MapperUserClaimEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserClaimEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserClaimEntityObject> builder)
        {
            var options = EntitiesOptions.UserClaim;

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

            builder.Property(x => x.UserId)
                .HasColumnName(options.DbColumnForUserEntityId);

            builder.HasIndex(x => x.UserId).HasDatabaseName(options.DbIndexForUserEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserClaimEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(options.DbForeignKeyToUserEntity);
        }

        #endregion Public methods    
    }
}
