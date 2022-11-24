// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.UserLogin
{
    /// <summary>
    /// Загрузчик типа "Вход пользователя".
    /// </summary>
    public class UserLoginTypeLoader : Loader<UserLoginTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserLoginTypeLoader(UserLoginTypeEntity? target = null)
            : base(target ?? new UserLoginTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserLoginTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.LoginProvider)))
            {
                Target.LoginProvider = source.LoginProvider;
            }

            if (result.Contains(nameof(Target.ProviderDisplayName)))
            {
                Target.ProviderDisplayName = source.ProviderDisplayName;
            }

            if (result.Contains(nameof(Target.ProviderKey)))
            {
                Target.ProviderKey = source.ProviderKey;
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
                nameof(Target.LoginProvider),
                nameof(Target.ProviderDisplayName),
                nameof(Target.ProviderKey),
                nameof(Target.UserId)
            };
        }

        #endregion Protected methods
    }
}
