// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyTree
{
    /// <summary>
    /// Конфигурация типа "DummyTree" сопоставителя.
    /// </summary>
    public class MapperDummyTreeTypeConfiguration : MapperTypeConfiguration<MapperDummyTreeTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperDummyTreeTypeConfiguration(TypesOptions typesOptions)
            : base(typesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyTreeTypeEntity> builder)
        {
            var options = TypesOptions.DummyTree;

            if (options is null)
            {
                throw new NullVariableException<MapperDummyTreeTypeConfiguration>(nameof(options));
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

            builder.Property(x => x.ParentId)
                .HasColumnName(options.DbColumnForDummyTreeEntityParentId);

            builder.Property(x => x.TreeChildCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(options.DbColumnForTreeChildCount);

            builder.Property(x => x.TreeDescendantCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(options.DbColumnForTreeDescendantCount);

            builder.Property(x => x.TreeLevel)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(options.DbColumnForTreeLevel);

            builder.Property(x => x.TreePath)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(options.DbMaxLengthForTreePath)
                .HasDefaultValue(string.Empty)
                .HasColumnName(options.DbColumnForTreePath);

            builder.Property(x => x.TreePosition)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(options.DbColumnForTreePosition);

            builder.Property(x => x.TreeSort)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(options.DbMaxLengthForTreeSort)
                .HasDefaultValue(string.Empty)
                .HasColumnName(options.DbColumnForTreeSort);

            builder.HasIndex(x => x.Name).HasDatabaseName(options.DbIndexForName);
            builder.HasIndex(x => x.ParentId).HasDatabaseName(options.DbIndexForDummyTreeEntityParentId);
            builder.HasIndex(x => x.TreeSort).HasDatabaseName(options.DbIndexForTreeSort);

            builder.HasIndex(x => new { x.ParentId, x.Name })
                .IsUnique()
                .HasDatabaseName(options.DbUniqueIndexForDummyTreeEntityParentIdAndName);

            builder.HasOne(x => x.ObjectOfDummyTreeEntityParent)
                .WithMany(x => x.ObjectsOfDummyTreeEntityChild)
                .HasForeignKey(x => x.ParentId)
                .HasConstraintName(options.DbForeignKeyToDummyTreeEntityParent);
        }

        #endregion Public methods
    }
}
