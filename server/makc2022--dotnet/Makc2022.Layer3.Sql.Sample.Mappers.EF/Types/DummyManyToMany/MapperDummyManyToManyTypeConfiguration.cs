// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyManyToMany
{
    /// <summary>
    /// Конфигурация типа "DummyManyToMany" сопоставителя.
    /// </summary>
    public class MapperDummyManyToManyTypeConfiguration : MapperTypeConfiguration<MapperDummyManyToManyTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperDummyManyToManyTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyManyToManyTypeEntity> builder)
        {
            var options = TypesOptions.DummyManyToMany;

            if (options is null)
            {
                throw new NullVariableException<MapperDummyManyToManyTypeConfiguration>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => x.Id).HasName(options.DbPrimaryKey);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(options.DbColumnForId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(options.DbMaxLengthForName)
                .HasColumnName(options.DbColumnForName);

            builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(options.DbUniqueIndexForName);
        }

        #endregion Public methods
    }
}
