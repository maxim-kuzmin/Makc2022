// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyOneToMany
{
    /// <summary>
    /// Загрузчик типа "DummyOneToMany".
    /// </summary>
    public class DummyOneToManyTypeLoader : TypeLoader<DummyOneToManyTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyOneToManyTypeLoader(DummyOneToManyTypeEntity? entity = null)
            : base(entity ?? new DummyOneToManyTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyOneToManyTypeEntity entity,
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
