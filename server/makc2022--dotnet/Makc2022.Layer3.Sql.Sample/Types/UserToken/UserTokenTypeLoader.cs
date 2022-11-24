// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.UserToken
{
    /// <summary>
    /// Загрузчик типа "Токен пользователя".
    /// </summary>
    public class UserTokenTypeLoader : Loader<UserTokenTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserTokenTypeLoader(UserTokenTypeEntity? target = null)
            : base(target ?? new UserTokenTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserTokenTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.LoginProvider)))
            {
                Target.LoginProvider = source.LoginProvider;
            }

            if (result.Contains(nameof(Target.Name)))
            {
                Target.Name = source.Name;
            }

            if (result.Contains(nameof(Target.UserId)))
            {
                Target.UserId = source.UserId;
            }

            if (result.Contains(nameof(Target.Value)))
            {
                Target.Value = source.Value;
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
                nameof(Target.Name),
                nameof(Target.UserId),
                nameof(Target.Value)
            };
        }

        #endregion Protected methods
    }
}
