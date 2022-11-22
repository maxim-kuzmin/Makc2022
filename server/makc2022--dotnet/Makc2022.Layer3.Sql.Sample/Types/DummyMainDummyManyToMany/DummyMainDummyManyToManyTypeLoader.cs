// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany
{
    /// <summary>
    /// Загрузчик типа "DummyMainDummyManyToMany".
    /// </summary>
    public class DummyMainDummyManyToManyTypeLoader : TypeLoader<DummyMainDummyManyToManyTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainDummyManyToManyTypeLoader(DummyMainDummyManyToManyTypeEntity? entity = null)
            : base(entity ?? new DummyMainDummyManyToManyTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyMainDummyManyToManyTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.IdOfDummyMainEntity)))
            {
                Entity.IdOfDummyMainEntity = entity.IdOfDummyMainEntity;
            }

            if (result.Contains(nameof(Entity.IdOfDummyManyToManyEntity)))
            {
                Entity.IdOfDummyManyToManyEntity = entity.IdOfDummyManyToManyEntity;
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
                nameof(Entity.IdOfDummyMainEntity),
                nameof(Entity.IdOfDummyManyToManyEntity)
            };
        }

        #endregion Protected methods
    }
}
