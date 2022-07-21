// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.RoleClaim
{
    /// <summary>
    /// Загрузчик сущности "RoleClaim".
    /// </summary>
    public class RoleClaimEntityLoader : EntityLoader<RoleClaimEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleClaimEntityLoader(RoleClaimEntityObject? entityObject = null)
            : base(entityObject ?? new RoleClaimEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            RoleClaimEntityObject entityObject,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entityObject, loadableProperties);

            if (result.Contains(nameof(EntityObject.ClaimType)))
            {
                EntityObject.ClaimType = entityObject.ClaimType;
            }

            if (result.Contains(nameof(EntityObject.ClaimValue)))
            {
                EntityObject.ClaimValue = entityObject.ClaimValue;
            }

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = entityObject.Id;
            }

            if (result.Contains(nameof(EntityObject.RoleId)))
            {
                EntityObject.RoleId = entityObject.RoleId;
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
                nameof(EntityObject.ClaimType),
                nameof(EntityObject.ClaimValue),
                nameof(EntityObject.Id),
                nameof(EntityObject.RoleId)
            };
        }

        #endregion Protected methods
    }
}
