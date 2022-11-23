// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserClaim
{
    /// <summary>
    /// Конфигурация типа "Утверждение пользователя" сопоставителя.
    /// </summary>
    public class MapperUserClaimTypeConfiguration : MapperTypeConfiguration<MapperUserClaimTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserClaimTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserClaimTypeEntity> builder)
        {
            var options = TypesOptions.UserClaim;

            if (options is null)
            {
                throw new NullVariableException<MapperUserClaimTypeConfiguration>(nameof(options));
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
                .HasColumnName(options.DbColumnForUserId);

            builder.HasIndex(x => x.UserId).HasDatabaseName(options.DbIndexForUserId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserClaimList)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(options.DbForeignKeyToUser);
        }

        #endregion Public methods    
    }
}
