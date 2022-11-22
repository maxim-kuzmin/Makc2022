// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.RoleClaim
{
    /// <summary>
    /// Загрузчик типа "RoleClaim".
    /// </summary>
    public class RoleClaimTypeLoader : TypeLoader<RoleClaimTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleClaimTypeLoader(RoleClaimTypeEntity? entity = null)
            : base(entity ?? new RoleClaimTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            RoleClaimTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.ClaimType)))
            {
                Entity.ClaimType = entity.ClaimType;
            }

            if (result.Contains(nameof(Entity.ClaimValue)))
            {
                Entity.ClaimValue = entity.ClaimValue;
            }

            if (result.Contains(nameof(Entity.Id)))
            {
                Entity.Id = entity.Id;
            }

            if (result.Contains(nameof(Entity.RoleId)))
            {
                Entity.RoleId = entity.RoleId;
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
                nameof(Entity.ClaimType),
                nameof(Entity.ClaimValue),
                nameof(Entity.Id),
                nameof(Entity.RoleId)
            };
        }

        #endregion Protected methods
    }
}
