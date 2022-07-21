// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF
{
    /// <summary>
    /// Схема сопоставителя.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class MapperSchema<TEntityObject> : Layer2.Sql.Mappers.EF.MapperSchema<EntitiesOptions, TEntityObject>
        where TEntityObject : class
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperSchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors
    }
}
