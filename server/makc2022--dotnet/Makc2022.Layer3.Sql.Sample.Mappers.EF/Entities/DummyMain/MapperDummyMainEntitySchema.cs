// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain
{
    /// <summary>
    /// Схема сущности "DummyMain" сопоставителя.
    /// </summary>
    public class MapperDummyMainEntitySchema : MapperSchema<MapperDummyMainEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperDummyMainEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyMainEntityObject> builder)
        {
            var options = EntitiesOptions.DummyMain;

            if (options is null)
            {
                throw new NullVariableException<MapperDummyMainEntitySchema>(nameof(options));
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

            builder.Property(x => x.IdOfDummyOneToManyEntity)
                .IsRequired()
                .HasColumnName(options.DbColumnForDummyOneToManyEntityId);

            builder.Property(x => x.PropBoolean)
                .IsRequired()
                .HasColumnName(options.DbColumnForPropBoolean);

            builder.Property(x => x.PropBooleanNullable)
                .HasColumnName(options.DbColumnForPropBooleanNullable);

            builder.Property(x => x.PropDate)
                .IsRequired()
                .HasColumnName(options.DbColumnForPropDate);

            builder.Property(x => x.PropDateNullable)
                .HasColumnName(options.DbColumnForPropDateNullable);

            builder.Property(x => x.PropDateTimeOffset)
                .IsRequired()
                .HasColumnName(options.DbColumnForPropDateTimeOffset);

            builder.Property(x => x.PropDateTimeOffsetNullable)
                .HasColumnName(options.DbColumnForPropDateTimeOffsetNullable);

            builder.Property(x => x.PropDecimal)
                .IsRequired()
                .HasColumnName(options.DbColumnForPropDecimal);

            builder.Property(x => x.PropDecimalNullable)
                .HasColumnName(options.DbColumnForPropDecimalNullable);

            builder.Property(x => x.PropInt32)
                .IsRequired()
                .HasColumnName(options.DbColumnForPropInt32);

            builder.Property(x => x.PropInt32Nullable)
                .HasColumnName(options.DbColumnForPropInt32Nullable);

            builder.Property(x => x.PropInt64)
                .IsRequired()
                .HasColumnName(options.DbColumnForPropInt64);

            builder.Property(x => x.PropInt64Nullable)
                .HasColumnName(options.DbColumnForPropInt64Nullable);

            builder.Property(x => x.PropString)
                .IsRequired()
                .IsUnicode()
                .HasColumnName(options.DbColumnForPropString);

            builder.Property(x => x.PropStringNullable)
                .IsUnicode()
                .HasColumnName(options.DbColumnForPropStringNullable);

            builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(options.DbUniqueIndexForName);
            builder.HasIndex(x => x.IdOfDummyOneToManyEntity).HasDatabaseName(options.DbIndexForDummyOneToManyEntityId);

            builder.HasOne(x => x.ObjectOfDummyOneToManyEntity)
                .WithMany(x => x.ObjectsOfDummyMainEntity)
                .HasForeignKey(x => x.IdOfDummyOneToManyEntity)
                .HasConstraintName(options.DbForeignKeyToDummyOneToManyEntity);
        }

        #endregion Public methods
    }
}
