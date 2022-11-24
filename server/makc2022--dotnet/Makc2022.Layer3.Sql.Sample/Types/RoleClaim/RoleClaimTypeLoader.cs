// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.RoleClaim
{
    /// <summary>
    /// Загрузчик типа "Утверждение роли".
    /// </summary>
    public class RoleClaimTypeLoader : Loader<RoleClaimTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleClaimTypeLoader(RoleClaimTypeEntity? target = null)
            : base(target ?? new RoleClaimTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            RoleClaimTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.ClaimType)))
            {
                Target.ClaimType = source.ClaimType;
            }

            if (result.Contains(nameof(Target.ClaimValue)))
            {
                Target.ClaimValue = source.ClaimValue;
            }

            if (result.Contains(nameof(Target.Id)))
            {
                Target.Id = source.Id;
            }

            if (result.Contains(nameof(Target.RoleId)))
            {
                Target.RoleId = source.RoleId;
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
                nameof(Target.ClaimType),
                nameof(Target.ClaimValue),
                nameof(Target.Id),
                nameof(Target.RoleId)
            };
        }

        #endregion Protected methods
    }
}
