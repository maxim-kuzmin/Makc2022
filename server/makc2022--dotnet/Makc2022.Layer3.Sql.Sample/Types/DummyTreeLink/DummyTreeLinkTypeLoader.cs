// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyTreeLink
{
    /// <summary>
    /// Загрузчик типа "Связь фиктивного дерева".
    /// </summary>
    public class DummyTreeLinkTypeLoader : TypeLoader<DummyTreeLinkTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeLinkTypeLoader(DummyTreeLinkTypeEntity? entity = null)
            : base(entity ?? new DummyTreeLinkTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyTreeLinkTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.Id)))
            {
                Entity.Id = entity.Id;
            }

            if (result.Contains(nameof(Entity.ParentId)))
            {
                Entity.ParentId = entity.ParentId;
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
                nameof(Entity.ParentId)
            };
        }

        #endregion Protected methods
    }
}
