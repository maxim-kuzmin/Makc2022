// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany
{
    /// <summary>
    /// Загрузчик типа "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public class DummyMainDummyManyToManyTypeLoader : Loader<DummyMainDummyManyToManyTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainDummyManyToManyTypeLoader(DummyMainDummyManyToManyTypeEntity? target = null)
            : base(target ?? new DummyMainDummyManyToManyTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyMainDummyManyToManyTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.DummyMainId)))
            {
                Target.DummyMainId = source.DummyMainId;
            }

            if (result.Contains(nameof(Target.DummyManyToManyId)))
            {
                Target.DummyManyToManyId = source.DummyManyToManyId;
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
                nameof(Target.DummyMainId),
                nameof(Target.DummyManyToManyId)
            };
        }

        #endregion Protected methods
    }
}
