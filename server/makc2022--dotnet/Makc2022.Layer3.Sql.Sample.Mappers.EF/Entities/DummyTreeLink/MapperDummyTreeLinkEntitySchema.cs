// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Схема сущности "DummyTreeLink" сопоставителя.
    /// </summary>
    public class MapperDummyTreeLinkEntitySchema : MapperSchema<MapperDummyTreeLinkEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperDummyTreeLinkEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyTreeLinkEntityObject> builder)
        {
            var options = EntitiesOptions.DummyTreeLink;

            if (options is null)
            {
                throw new NullVariableException<MapperDummyTreeLinkEntitySchema>(nameof(options));
            }

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => new { x.Id, x.ParentId }).HasName(options.DbPrimaryKey);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(options.DbColumnForId);

            builder.Property(x => x.ParentId)
                .IsRequired()
                .HasColumnName(options.DbColumnForDummyTreeEntityParentId);

            builder.HasOne(x => x.ObjectOfDummyTreeEntity)
                .WithMany(x => x.ObjectsOfDummyTreeLinkEntity)
                .HasForeignKey(x => x.Id)
                .HasConstraintName(options.DbForeignKeyToDummyTreeEntity);
        }

        #endregion Public methods
    }
}
