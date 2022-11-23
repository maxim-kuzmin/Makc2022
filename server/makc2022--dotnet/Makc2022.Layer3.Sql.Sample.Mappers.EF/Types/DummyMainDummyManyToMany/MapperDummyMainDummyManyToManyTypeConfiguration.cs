// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany
{
    /// <summary>
    /// Конфигурация типа "Фиктивное отношение многие ко многим фиктивного главного" сопоставителя.
    /// </summary>
    public class MapperDummyMainDummyManyToManyTypeConfiguration : MapperTypeConfiguration<MapperDummyMainDummyManyToManyTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperDummyMainDummyManyToManyTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyMainDummyManyToManyTypeEntity> builder)
        {
            var options = TypesOptions.DummyMainDummyManyToMany;

            if (options is null)
            {
                throw new NullVariableException<MapperDummyMainDummyManyToManyTypeConfiguration>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => new { x.DummyMainId, x.DummyManyToManyId }).HasName(options.DbPrimaryKey);

            builder.Property(x => x.DummyMainId)
                .IsRequired()
                .HasColumnName(options.DbColumnForDummyMainEntityId);

            builder.Property(x => x.DummyManyToManyId)
                .IsRequired()
                .HasColumnName(options.DbColumnForDummyManyToManyEntityId);

            builder.HasIndex(x => x.DummyManyToManyId).HasDatabaseName(options.DbIndexForDummyManyToManyEntityId);

            builder.HasOne(x => x.DummyMain)
                .WithMany(x => x.DummyMainDummyManyToManyList)
                .HasForeignKey(x => x.DummyMainId)
                .HasConstraintName(options.DbForeignKeyToDummyMainEntity);

            builder.HasOne(x => x.DummyManyToMany)
                .WithMany(x => x.DummyMainDummyManyToManyList)
                .HasForeignKey(x => x.DummyManyToManyId)
                .HasConstraintName(options.DbForeignKeyToDummyManyToManyEntity);
        }

        #endregion Public methods
    }
}
