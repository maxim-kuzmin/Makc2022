// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions;
using Makc2022.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Схема сущности "DummyMainDummyManyToMany" сопоставителя.
    /// </summary>
    public class MapperDummyMainDummyManyToManyEntitySchema : MapperSchema<MapperDummyMainDummyManyToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperDummyMainDummyManyToManyEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyMainDummyManyToManyEntityObject> builder)
        {
            var options = EntitiesOptions.DummyMainDummyManyToMany;

            if (options is null)
            {
                throw new NullVariableException(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => new { x.IdOfDummyMainEntity, x.IdOfDummyManyToManyEntity }).HasName(options.DbPrimaryKey);

            builder.Property(x => x.IdOfDummyMainEntity)
                .IsRequired()
                .HasColumnName(options.DbColumnForDummyMainEntityId);

            builder.Property(x => x.IdOfDummyManyToManyEntity)
                .IsRequired()
                .HasColumnName(options.DbColumnForDummyManyToManyEntityId);

            builder.HasIndex(x => x.IdOfDummyManyToManyEntity).HasDatabaseName(options.DbIndexForDummyManyToManyEntityId);

            builder.HasOne(x => x.ObjectOfDummyMainEntity)
                .WithMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .HasForeignKey(x => x.IdOfDummyMainEntity)
                .HasConstraintName(options.DbForeignKeyToDummyMainEntity);

            builder.HasOne(x => x.ObjectOfDummyManyToManyEntity)
                .WithMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .HasForeignKey(x => x.IdOfDummyManyToManyEntity)
                .HasConstraintName(options.DbForeignKeyToDummyManyToManyEntity);
        }

        #endregion Public methods
    }
}
