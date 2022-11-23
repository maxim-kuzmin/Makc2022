// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany
{
    /// <summary>
    /// Загрузчик типа "Фиктивное отношение многие ко многим фиктивного главного".
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

            if (result.Contains(nameof(Entity.DummyMainId)))
            {
                Entity.DummyMainId = entity.DummyMainId;
            }

            if (result.Contains(nameof(Entity.DummyManyToManyId)))
            {
                Entity.DummyManyToManyId = entity.DummyManyToManyId;
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
                nameof(Entity.DummyMainId),
                nameof(Entity.DummyManyToManyId)
            };
        }

        #endregion Protected methods
    }
}
