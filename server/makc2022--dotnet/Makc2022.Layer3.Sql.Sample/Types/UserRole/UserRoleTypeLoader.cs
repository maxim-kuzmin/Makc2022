// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.UserRole
{
    /// <summary>
    /// Загрузчик типа "Роль пользователя".
    /// </summary>
    public class UserRoleTypeLoader : Loader<UserRoleTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserRoleTypeLoader(UserRoleTypeEntity? target = null)
            : base(target ?? new UserRoleTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserRoleTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.UserId)))
            {
                Target.UserId = source.UserId;
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
                nameof(Target.UserId),
                nameof(Target.RoleId)
            };
        }

        #endregion Protected methods
    }
}
