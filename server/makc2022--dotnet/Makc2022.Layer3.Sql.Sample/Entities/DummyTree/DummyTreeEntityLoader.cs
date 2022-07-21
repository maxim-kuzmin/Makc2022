// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyTree
{
    /// <summary>
    /// Загрузчик сущности "DummyTree".
    /// </summary>
    public class DummyTreeEntityLoader : EntityLoader<DummyTreeEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeEntityLoader(DummyTreeEntityObject? entityObject = null)
            : base(entityObject ?? new DummyTreeEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyTreeEntityObject entityObject,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entityObject, loadableProperties);

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = entityObject.Id;
            }

            if (result.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = entityObject.Name;
            }

            if (result.Contains(nameof(EntityObject.ParentId)))
            {
                EntityObject.ParentId = entityObject.ParentId;
            }

            if (result.Contains(nameof(EntityObject.TreeChildCount)))
            {
                EntityObject.TreeChildCount = entityObject.TreeChildCount;
            }

            if (result.Contains(nameof(EntityObject.TreeDescendantCount)))
            {
                EntityObject.TreeDescendantCount = entityObject.TreeDescendantCount;
            }

            if (result.Contains(nameof(EntityObject.TreeLevel)))
            {
                EntityObject.TreeLevel = entityObject.TreeLevel;
            }

            if (result.Contains(nameof(EntityObject.TreePath)))
            {
                EntityObject.TreePath = entityObject.TreePath;
            }

            if (result.Contains(nameof(EntityObject.TreePosition)))
            {
                EntityObject.TreePosition = entityObject.TreePosition;
            }

            if (result.Contains(nameof(EntityObject.TreeSort)))
            {
                EntityObject.TreeSort = entityObject.TreeSort;
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
                nameof(EntityObject.Id),
                nameof(EntityObject.Name),
                nameof(EntityObject.ParentId),
                nameof(EntityObject.TreeChildCount),
                nameof(EntityObject.TreeDescendantCount),
                nameof(EntityObject.TreeLevel),
                nameof(EntityObject.TreePath),
                nameof(EntityObject.TreeSort)
            };
        }

        #endregion Protected methods
    }
}
