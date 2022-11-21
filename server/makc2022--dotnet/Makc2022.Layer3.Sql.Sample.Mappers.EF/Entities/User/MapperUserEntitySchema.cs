// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.User
{
    /// <summary>
    /// Схема сущности "User" сопоставителя.
    /// </summary>
    public class MapperUserEntitySchema : MapperSchema<MapperUserEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserEntityObject> builder)
        {
            var options = EntitiesOptions.User;

            if (options is null)
            {
                throw new NullVariableException<MapperUserEntitySchema>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => x.Id).HasName(options.DbPrimaryKey);

            builder.Property(x => x.AccessFailedCount)
                .HasColumnName(options.DbColumnForAccessFailedCount);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(options.DbColumnForConcurrencyStamp);

            builder.Property(x => x.Email)
                .HasColumnName(options.DbColumnForEmail);

            builder.Property(x => x.EmailConfirmed)
                .HasColumnName(options.DbColumnForEmailConfirmed);

            builder.Property(x => x.FullName)
                .IsUnicode()
                .HasMaxLength(256)
                .HasColumnName(options.DbColumnForFullName);

            builder.Property(x => x.Id)
                .HasColumnName(options.DbColumnForId);

            builder.Property(x => x.LockoutEnabled)
                .HasColumnName(options.DbColumnForLockoutEnabled);

            builder.Property(x => x.LockoutEnd)
                .HasColumnName(options.DbColumnForLockoutEnd);

            builder.Property(x => x.NormalizedEmail)
                .HasColumnName(options.DbColumnForNormalizedEmail);

            builder.Property(x => x.NormalizedUserName)
                .HasColumnName(options.DbColumnForNormalizedUserName);

            builder.Property(x => x.PasswordHash)
                .HasColumnName(options.DbColumnForPasswordHash);

            builder.Property(x => x.PhoneNumber)
                .HasColumnName(options.DbColumnForPhoneNumber);

            builder.Property(x => x.PhoneNumberConfirmed)
                .HasColumnName(options.DbColumnForPhoneNumberConfirmed);

            builder.Property(x => x.SecurityStamp)
                .HasColumnName(options.DbColumnForSecurityStamp);

            builder.Property(x => x.TwoFactorEnabled)
                .HasColumnName(options.DbColumnForTwoFactorEnabled);

            builder.Property(x => x.UserName)
                .HasColumnName(options.DbColumnForUserName);

            builder.HasIndex(x => x.NormalizedUserName).IsUnique().HasDatabaseName(options.DbUniqueIndexForNormalizedUserName);
            builder.HasIndex(x => x.NormalizedEmail).HasDatabaseName(options.DbIndexForNormalizedEmail);
        }

        #endregion Public methods    
    }
}
