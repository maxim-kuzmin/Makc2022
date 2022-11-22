// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyManyToMany
{
    /// <summary>
    /// Загрузчик типа "Фиктивное отношение многие ко многим".
    /// </summary>
    public class DummyManyToManyTypeLoader : TypeLoader<DummyManyToManyTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyManyToManyTypeLoader(DummyManyToManyTypeEntity? entity = null)
            : base(entity ?? new DummyManyToManyTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyManyToManyTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.Id)))
            {
                Entity.Id = entity.Id;
            }

            if (result.Contains(nameof(Entity.Name)))
            {
                Entity.Name = entity.Name;
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
                nameof(Entity.Id),
                nameof(Entity.Name)
            };
        }

        #endregion Protected methods
    }
}
