// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.UserClaim
{
    /// <summary>
    /// Загрузчик типа "Утверждение пользователя".
    /// </summary>
    public class UserClaimTypeLoader : Loader<UserClaimTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserClaimTypeLoader(UserClaimTypeEntity? target = null)
            : base(target ?? new UserClaimTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserClaimTypeEntity source,
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

            if (result.Contains(nameof(Target.UserId)))
            {
                Target.UserId = source.UserId;
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
                nameof(Target.UserId)
            };
        }

        #endregion Protected methods
    }
}
