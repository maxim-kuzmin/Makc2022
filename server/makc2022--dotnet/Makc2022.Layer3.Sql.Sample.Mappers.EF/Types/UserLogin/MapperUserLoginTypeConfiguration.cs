// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserLogin
{
    /// <summary>
    /// Конфигурация типа "UserLogin" сопоставителя.
    /// </summary>
    public class MapperUserLoginTypeConfiguration : MapperTypeConfiguration<MapperUserLoginTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserLoginTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserLoginTypeEntity> builder)
        {
            var options = TypesOptions.UserLogin;

            if (options is null)
            {
                throw new NullVariableException<MapperUserLoginTypeConfiguration>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey })
                .HasName(options.DbPrimaryKey);

            builder.Property(x => x.LoginProvider)
                .HasColumnName(options.DbColumnForLoginProvider);

            builder.Property(x => x.ProviderDisplayName)
                .HasColumnName(options.DbColumnForProviderDisplayName);

            builder.Property(x => x.ProviderKey)
                .HasColumnName(options.DbColumnForProviderKey);

            builder.Property(x => x.UserId)
                .HasColumnName(options.DbColumnForUserEntityId);

            builder.HasIndex(x => x.UserId).HasDatabaseName(options.DbIndexForUserEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserLoginEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(options.DbForeignKeyToUserEntity);
        }

        #endregion Public methods    
    }
}
