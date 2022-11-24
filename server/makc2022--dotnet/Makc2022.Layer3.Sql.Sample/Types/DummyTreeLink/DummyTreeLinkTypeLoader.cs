// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.DummyTreeLink
{
    /// <summary>
    /// Загрузчик типа "Связь фиктивного дерева".
    /// </summary>
    public class DummyTreeLinkTypeLoader : Loader<DummyTreeLinkTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeLinkTypeLoader(DummyTreeLinkTypeEntity? target = null)
            : base(target ?? new DummyTreeLinkTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyTreeLinkTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.Id)))
            {
                Target.Id = source.Id;
            }

            if (result.Contains(nameof(Target.ParentId)))
            {
                Target.ParentId = source.ParentId;
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
                nameof(Target.ParentId)
            };
        }

        #endregion Protected methods
    }
}
