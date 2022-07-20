// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Загрузчик сущности "DummyMainDummyManyToMany".
    /// </summary>
    public class DummyMainDummyManyToManyEntityLoader : EntityLoader<DummyMainDummyManyToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainDummyManyToManyEntityLoader(DummyMainDummyManyToManyEntityObject? entityObject = null)
            : base(entityObject ?? new DummyMainDummyManyToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(DummyMainDummyManyToManyEntityObject entityObject, HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entityObject, loadableProperties);

            if (result.Contains(nameof(EntityObject.IdOfDummyMainEntity)))
            {
                EntityObject.IdOfDummyMainEntity = entityObject.IdOfDummyMainEntity;
            }

            if (result.Contains(nameof(EntityObject.IdOfDummyManyToManyEntity)))
            {
                EntityObject.IdOfDummyManyToManyEntity = entityObject.IdOfDummyManyToManyEntity;
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
                nameof(EntityObject.IdOfDummyMainEntity),
                nameof(EntityObject.IdOfDummyManyToManyEntity)
            };
        }

        #endregion Protected methods
    }
}
