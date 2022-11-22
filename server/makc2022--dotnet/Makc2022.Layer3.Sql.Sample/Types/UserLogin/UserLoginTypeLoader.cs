// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.UserLogin
{
    /// <summary>
    /// Загрузчик типа "Вход пользователя".
    /// </summary>
    public class UserLoginTypeLoader : TypeLoader<UserLoginTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserLoginTypeLoader(UserLoginTypeEntity? entity = null)
            : base(entity ?? new UserLoginTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserLoginTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.LoginProvider)))
            {
                Entity.LoginProvider = entity.LoginProvider;
            }

            if (result.Contains(nameof(Entity.ProviderDisplayName)))
            {
                Entity.ProviderDisplayName = entity.ProviderDisplayName;
            }

            if (result.Contains(nameof(Entity.ProviderKey)))
            {
                Entity.ProviderKey = entity.ProviderKey;
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
                nameof(Entity.LoginProvider),
                nameof(Entity.ProviderDisplayName),
                nameof(Entity.ProviderKey),
                nameof(Entity.UserId)
            };
        }

        #endregion Protected methods
    }
}
