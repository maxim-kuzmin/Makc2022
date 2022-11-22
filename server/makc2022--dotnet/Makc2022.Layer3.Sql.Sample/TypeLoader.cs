// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample
{
    /// <inheritdoc/>
    public abstract class TypeLoader<TEntityObject> : Layer1.TypeLoader<TEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public TypeLoader(TEntityObject entity) : base(entity)
        {
        }

        #endregion Constructors
    }
}
