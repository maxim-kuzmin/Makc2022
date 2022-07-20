// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2022.Layer2.Sql.Mappers.EF
{
    /// <summary>
    /// Схема сопоставителя.
    /// </summary>
    /// <typeparam name="TEntitiesOptions">Тип параметров сущностей.</typeparam>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class MapperSchema<TEntitiesOptions, TEntityObject> : IEntityTypeConfiguration<TEntityObject>
        where TEntityObject : class
    {
        #region Properties

        /// <summary>
        /// Параметры сущностей.
        /// </summary>
        protected TEntitiesOptions EntitiesOptions { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="entitiesOptions">Параметры сущностей.</param>
        public MapperSchema(TEntitiesOptions entitiesOptions)
        {
            EntitiesOptions = entitiesOptions;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract void Configure(EntityTypeBuilder<TEntityObject> builder);

        #endregion Public methods
    }
}
