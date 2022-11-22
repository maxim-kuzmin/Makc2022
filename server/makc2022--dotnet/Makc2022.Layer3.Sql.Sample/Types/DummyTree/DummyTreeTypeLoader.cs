// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyTree
{
    /// <summary>
    /// Загрузчик типа "DummyTree".
    /// </summary>
    public class DummyTreeTypeLoader : TypeLoader<DummyTreeTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeTypeLoader(DummyTreeTypeEntity? entity = null)
            : base(entity ?? new DummyTreeTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyTreeTypeEntity entity,
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

            if (result.Contains(nameof(Entity.ParentId)))
            {
                Entity.ParentId = entity.ParentId;
            }

            if (result.Contains(nameof(Entity.TreeChildCount)))
            {
                Entity.TreeChildCount = entity.TreeChildCount;
            }

            if (result.Contains(nameof(Entity.TreeDescendantCount)))
            {
                Entity.TreeDescendantCount = entity.TreeDescendantCount;
            }

            if (result.Contains(nameof(Entity.TreeLevel)))
            {
                Entity.TreeLevel = entity.TreeLevel;
            }

            if (result.Contains(nameof(Entity.TreePath)))
            {
                Entity.TreePath = entity.TreePath;
            }

            if (result.Contains(nameof(Entity.TreePosition)))
            {
                Entity.TreePosition = entity.TreePosition;
            }

            if (result.Contains(nameof(Entity.TreeSort)))
            {
                Entity.TreeSort = entity.TreeSort;
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
                nameof(Entity.Name),
                nameof(Entity.ParentId),
                nameof(Entity.TreeChildCount),
                nameof(Entity.TreeDescendantCount),
                nameof(Entity.TreeLevel),
                nameof(Entity.TreePath),
                nameof(Entity.TreeSort)
            };
        }

        #endregion Protected methods
    }
}
