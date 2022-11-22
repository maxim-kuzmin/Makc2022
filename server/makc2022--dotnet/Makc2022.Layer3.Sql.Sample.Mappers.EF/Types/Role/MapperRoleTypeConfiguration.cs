// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.Role
{
    /// <summary>
    /// Конфигурация типа "Role" для сопоставителя.
    /// </summary>
    public class MapperRoleTypeConfiguration : MapperTypeConfiguration<MapperRoleTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperRoleTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperRoleTypeEntity> builder)
        {
            var options = TypesOptions.Role;

            if (options is null)
            {
                throw new NullVariableException<MapperRoleTypeConfiguration>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => x.Id).HasName(options.DbPrimaryKey);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(options.DbColumnForConcurrencyStamp);

            builder.Property(x => x.Id)
                .HasColumnName(options.DbColumnForId);

            builder.Property(x => x.Name)
                .HasColumnName(options.DbColumnForName);

            builder.Property(x => x.NormalizedName)
                .HasColumnName(options.DbColumnForNormalizedName);

            builder.HasIndex(x => x.NormalizedName).IsUnique().HasDatabaseName(options.DbUniqueIndexForNormalizedName);
        }

        #endregion Public methods    
    }
}
