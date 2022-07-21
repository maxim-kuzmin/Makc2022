// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.User
{
    /// <summary>
    /// Загрузчик сущности "User".
    /// </summary>
    public class UserEntityLoader : EntityLoader<UserEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserEntityLoader(UserEntityObject? entityObject = null)
            : base(entityObject ?? new UserEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserEntityObject entityObject,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entityObject, loadableProperties);

            if (result.Contains(nameof(EntityObject.AccessFailedCount)))
            {
                EntityObject.AccessFailedCount = entityObject.AccessFailedCount;
            }

            if (result.Contains(nameof(EntityObject.ConcurrencyStamp)))
            {
                EntityObject.ConcurrencyStamp = entityObject.ConcurrencyStamp;
            }

            if (result.Contains(nameof(EntityObject.Email)))
            {
                EntityObject.Email = entityObject.Email;
            }

            if (result.Contains(nameof(EntityObject.EmailConfirmed)))
            {
                EntityObject.EmailConfirmed = entityObject.EmailConfirmed;
            }

            if (result.Contains(nameof(EntityObject.FullName)))
            {
                EntityObject.FullName = entityObject.FullName;
            }

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = entityObject.Id;
            }

            if (result.Contains(nameof(EntityObject.LockoutEnabled)))
            {
                EntityObject.LockoutEnabled = entityObject.LockoutEnabled;
            }

            if (result.Contains(nameof(EntityObject.LockoutEnd)))
            {
                EntityObject.LockoutEnd = entityObject.LockoutEnd;
            }

            if (result.Contains(nameof(EntityObject.NormalizedEmail)))
            {
                EntityObject.NormalizedEmail = entityObject.NormalizedEmail;
            }

            if (result.Contains(nameof(EntityObject.NormalizedUserName)))
            {
                EntityObject.NormalizedUserName = entityObject.NormalizedUserName;
            }

            if (result.Contains(nameof(EntityObject.PasswordHash)))
            {
                EntityObject.PasswordHash = entityObject.PasswordHash;
            }

            if (result.Contains(nameof(EntityObject.PhoneNumber)))
            {
                EntityObject.PhoneNumber = entityObject.PhoneNumber;
            }

            if (result.Contains(nameof(EntityObject.PhoneNumberConfirmed)))
            {
                EntityObject.PhoneNumberConfirmed = entityObject.PhoneNumberConfirmed;
            }

            if (result.Contains(nameof(EntityObject.SecurityStamp)))
            {
                EntityObject.SecurityStamp = entityObject.SecurityStamp;
            }

            if (result.Contains(nameof(EntityObject.TwoFactorEnabled)))
            {
                EntityObject.TwoFactorEnabled = entityObject.TwoFactorEnabled;
            }

            if (result.Contains(nameof(EntityObject.UserName)))
            {
                EntityObject.UserName = entityObject.UserName;
            }

            return result;
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать загружаемые свойства данных.
        /// </summary>
        /// <returns>Загружаемые свойства данных.</returns>
        protected override HashSet<string> CreateAllPropertiesToLoad()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.AccessFailedCount),
                nameof(EntityObject.ConcurrencyStamp),
                nameof(EntityObject.Email),
                nameof(EntityObject.EmailConfirmed),
                nameof(EntityObject.FullName),
                nameof(EntityObject.Id),
                nameof(EntityObject.LockoutEnabled),
                nameof(EntityObject.LockoutEnd),
                nameof(EntityObject.NormalizedEmail),
                nameof(EntityObject.NormalizedUserName),
                nameof(EntityObject.PasswordHash),
                nameof(EntityObject.PhoneNumber),
                nameof(EntityObject.PhoneNumberConfirmed),
                nameof(EntityObject.SecurityStamp),
                nameof(EntityObject.TwoFactorEnabled),
                nameof(EntityObject.UserName)
            };
        }

        #endregion Protected methods
    }
}
