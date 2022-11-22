// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.UserClaim
{
    /// <summary>
    /// Загрузчик типа "Утверждение пользователя".
    /// </summary>
    public class UserClaimTypeLoader : TypeLoader<UserClaimTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserClaimTypeLoader(UserClaimTypeEntity? entity = null)
            : base(entity ?? new UserClaimTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserClaimTypeEntity entity,
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

            if (result.Contains(nameof(Entity.UserId)))
            {
                Entity.UserId = entity.UserId;
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
                nameof(Entity.UserId)
            };
        }

        #endregion Protected methods
    }
}
