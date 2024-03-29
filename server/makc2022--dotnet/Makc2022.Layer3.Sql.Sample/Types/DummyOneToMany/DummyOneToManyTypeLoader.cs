﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.DummyOneToMany
{
    /// <summary>
    /// Загрузчик типа "Фиктивное отношение один ко многим".
    /// </summary>
    public class DummyOneToManyTypeLoader : Loader<DummyOneToManyTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyOneToManyTypeLoader(DummyOneToManyTypeEntity? target = null)
            : base(target ?? new DummyOneToManyTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyOneToManyTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.Id)))
            {
                Target.Id = source.Id;
            }

            if (result.Contains(nameof(Target.Name)))
            {
                Target.Name = source.Name;
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
                nameof(Target.Id),
                nameof(Target.Name)
            };
        }

        #endregion Protected methods
    }
}
