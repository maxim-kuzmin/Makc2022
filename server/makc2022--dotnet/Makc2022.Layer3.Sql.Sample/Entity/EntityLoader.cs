// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Entity
{
    /// <inheritdoc/>
    public abstract class EntityLoader<TEntityObject> : Layer1.Entity.EntityLoader<TEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public EntityLoader(TEntityObject entityObject)
            : base(entityObject)
        {
        }

        #endregion Constructors
    }
}
