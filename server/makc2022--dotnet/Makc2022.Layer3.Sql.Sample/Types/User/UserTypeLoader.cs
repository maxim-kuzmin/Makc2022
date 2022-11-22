// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.User
{
    /// <summary>
    /// Загрузчик типа "Пользователь".
    /// </summary>
    public class UserTypeLoader : TypeLoader<UserTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserTypeLoader(UserTypeEntity? entity = null)
            : base(entity ?? new UserTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.AccessFailedCount)))
            {
                Entity.AccessFailedCount = entity.AccessFailedCount;
            }

            if (result.Contains(nameof(Entity.ConcurrencyStamp)))
            {
                Entity.ConcurrencyStamp = entity.ConcurrencyStamp;
            }

            if (result.Contains(nameof(Entity.Email)))
            {
                Entity.Email = entity.Email;
            }

            if (result.Contains(nameof(Entity.EmailConfirmed)))
            {
                Entity.EmailConfirmed = entity.EmailConfirmed;
            }

            if (result.Contains(nameof(Entity.FullName)))
            {
                Entity.FullName = entity.FullName;
            }

            if (result.Contains(nameof(Entity.Id)))
            {
                Entity.Id = entity.Id;
            }

            if (result.Contains(nameof(Entity.LockoutEnabled)))
            {
                Entity.LockoutEnabled = entity.LockoutEnabled;
            }

            if (result.Contains(nameof(Entity.LockoutEnd)))
            {
                Entity.LockoutEnd = entity.LockoutEnd;
            }

            if (result.Contains(nameof(Entity.NormalizedEmail)))
            {
                Entity.NormalizedEmail = entity.NormalizedEmail;
            }

            if (result.Contains(nameof(Entity.NormalizedUserName)))
            {
                Entity.NormalizedUserName = entity.NormalizedUserName;
            }

            if (result.Contains(nameof(Entity.PasswordHash)))
            {
                Entity.PasswordHash = entity.PasswordHash;
            }

            if (result.Contains(nameof(Entity.PhoneNumber)))
            {
                Entity.PhoneNumber = entity.PhoneNumber;
            }

            if (result.Contains(nameof(Entity.PhoneNumberConfirmed)))
            {
                Entity.PhoneNumberConfirmed = entity.PhoneNumberConfirmed;
            }

            if (result.Contains(nameof(Entity.SecurityStamp)))
            {
                Entity.SecurityStamp = entity.SecurityStamp;
            }

            if (result.Contains(nameof(Entity.TwoFactorEnabled)))
            {
                Entity.TwoFactorEnabled = entity.TwoFactorEnabled;
            }

            if (result.Contains(nameof(Entity.UserName)))
            {
                Entity.UserName = entity.UserName;
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
                nameof(Entity.AccessFailedCount),
                nameof(Entity.ConcurrencyStamp),
                nameof(Entity.Email),
                nameof(Entity.EmailConfirmed),
                nameof(Entity.FullName),
                nameof(Entity.Id),
                nameof(Entity.LockoutEnabled),
                nameof(Entity.LockoutEnd),
                nameof(Entity.NormalizedEmail),
                nameof(Entity.NormalizedUserName),
                nameof(Entity.PasswordHash),
                nameof(Entity.PhoneNumber),
                nameof(Entity.PhoneNumberConfirmed),
                nameof(Entity.SecurityStamp),
                nameof(Entity.TwoFactorEnabled),
                nameof(Entity.UserName)
            };
        }

        #endregion Protected methods
    }
}
