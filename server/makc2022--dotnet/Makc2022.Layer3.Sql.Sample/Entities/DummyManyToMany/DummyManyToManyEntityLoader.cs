// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyManyToMany
{
    /// <summary>
    /// Загрузчик сущности "DummyManyToMany".
    /// </summary>
    public class DummyManyToManyEntityLoader : EntityLoader<DummyManyToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyManyToManyEntityLoader(DummyManyToManyEntityObject? entityObject = null)
            : base(entityObject ?? new DummyManyToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyManyToManyEntityObject entityObject,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entityObject, loadableProperties);

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = entityObject.Id;
            }

            if (result.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = entityObject.Name;
            }

            return result;
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateAllPropertiesToLoad()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.Id),
                nameof(EntityObject.Name)
            };
        }

        #endregion Protected methods
    }
}
