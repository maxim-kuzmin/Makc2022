// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.UserRole
{
    /// <summary>
    /// Загрузчик сущности "UserRole".
    /// </summary>
    public class UserRoleEntityLoader : EntityLoader<UserRoleEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserRoleEntityLoader(UserRoleEntityObject? entityObject = null)
            : base(entityObject ?? new UserRoleEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserRoleEntityObject entityObject,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entityObject, loadableProperties);

            if (result.Contains(nameof(EntityObject.UserId)))
            {
                EntityObject.UserId = entityObject.UserId;
            }

            if (result.Contains(nameof(EntityObject.RoleId)))
            {
                EntityObject.RoleId = entityObject.RoleId;
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
                nameof(EntityObject.UserId),
                nameof(EntityObject.RoleId)
            };
        }

        #endregion Protected methods
    }
}
