// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.Role
{
    /// <summary>
    /// Загрузчик сущности "Role".
    /// </summary>
    public class RoleEntityLoader : EntityLoader<RoleEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleEntityLoader(RoleEntityObject entityObject = null)
            : base(entityObject ?? new RoleEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(RoleEntityObject entityObject, HashSet<string> loadableProperties = null)
        {
            var result = base.Load(entityObject, loadableProperties);

            if (result.Contains(nameof(EntityObject.ConcurrencyStamp)))
            {
                EntityObject.ConcurrencyStamp = entityObject.ConcurrencyStamp;
            }

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = entityObject.Id;
            }

            if (result.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = entityObject.Name;
            }

            if (result.Contains(nameof(EntityObject.NormalizedName)))
            {
                EntityObject.NormalizedName = entityObject.NormalizedName;
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
                nameof(EntityObject.ConcurrencyStamp),
                nameof(EntityObject.Id),
                nameof(EntityObject.Name),
                nameof(EntityObject.NormalizedName)
            };
        }

        #endregion Protected methods
    }
}
