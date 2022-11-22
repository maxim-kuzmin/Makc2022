// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.UserRole
{
    /// <summary>
    /// Загрузчик типа "UserRole".
    /// </summary>
    public class UserRoleTypeLoader : TypeLoader<UserRoleTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserRoleTypeLoader(UserRoleTypeEntity? entity = null)
            : base(entity ?? new UserRoleTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserRoleTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.UserId)))
            {
                Entity.UserId = entity.UserId;
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
                nameof(Entity.UserId),
                nameof(Entity.RoleId)
            };
        }

        #endregion Protected methods
    }
}
