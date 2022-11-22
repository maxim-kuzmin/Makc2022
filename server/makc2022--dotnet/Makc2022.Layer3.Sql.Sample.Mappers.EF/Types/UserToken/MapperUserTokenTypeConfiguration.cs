// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserToken
{
    /// <summary>
    /// Конфигурация типа "Токен пользователя" сопоставителя.
    /// </summary>
    public class MapperUserTokenTypeConfiguration : MapperTypeConfiguration<MapperUserTokenTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserTokenTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserTokenTypeEntity> builder)
        {
            var options = TypesOptions.UserToken;

            if (options is null)
            {
                throw new NullVariableException<MapperUserTokenTypeConfiguration>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name }).HasName(options.DbPrimaryKey);

            builder.Property(x => x.LoginProvider)
                .HasColumnName(options.DbColumnForLoginProvider);

            builder.Property(x => x.Name)
                .HasColumnName(options.DbColumnForName);

            builder.Property(x => x.Value)
                .HasColumnName(options.DbColumnForValue);

            builder.Property(x => x.UserId)
                .HasColumnName(options.DbColumnForUserEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserTokenEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(options.DbForeignKeyToUserEntity);
        }

        #endregion Public methods    
    }
}
