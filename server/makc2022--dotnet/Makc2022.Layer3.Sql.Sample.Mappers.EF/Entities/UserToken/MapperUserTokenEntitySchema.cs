// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions;
using Makc2022.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserToken
{
    /// <summary>
    /// Схема сущности "UserToken" сопоставителя.
    /// </summary>
    public class MapperUserTokenEntitySchema : MapperSchema<MapperUserTokenEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserTokenEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserTokenEntityObject> builder)
        {
            var options = EntitiesOptions.UserToken;

            if (options is null)
            {
                throw new NullVariableException(nameof(options));
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
