// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.UserToken
{
    /// <summary>
    /// Загрузчик типа "Токен пользователя".
    /// </summary>
    public class UserTokenTypeLoader : TypeLoader<UserTokenTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserTokenTypeLoader(UserTokenTypeEntity? entity = null)
            : base(entity ?? new UserTokenTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserTokenTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.LoginProvider)))
            {
                Entity.LoginProvider = entity.LoginProvider;
            }

            if (result.Contains(nameof(Entity.Name)))
            {
                Entity.Name = entity.Name;
            }

            if (result.Contains(nameof(Entity.UserId)))
            {
                Entity.UserId = entity.UserId;
            }

            if (result.Contains(nameof(Entity.Value)))
            {
                Entity.Value = entity.Value;
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
                nameof(Entity.Name),
                nameof(Entity.UserId),
                nameof(Entity.Value)
            };
        }

        #endregion Protected methods
    }
}
