// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.User
{
    /// <summary>
    /// Загрузчик типа "Пользователь".
    /// </summary>
    public class UserTypeLoader : Loader<UserTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserTypeLoader(UserTypeEntity? target = null)
            : base(target ?? new UserTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            UserTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.AccessFailedCount)))
            {
                Target.AccessFailedCount = source.AccessFailedCount;
            }

            if (result.Contains(nameof(Target.ConcurrencyStamp)))
            {
                Target.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (result.Contains(nameof(Target.Email)))
            {
                Target.Email = source.Email;
            }

            if (result.Contains(nameof(Target.EmailConfirmed)))
            {
                Target.EmailConfirmed = source.EmailConfirmed;
            }

            if (result.Contains(nameof(Target.FullName)))
            {
                Target.FullName = source.FullName;
            }

            if (result.Contains(nameof(Target.Id)))
            {
                Target.Id = source.Id;
            }

            if (result.Contains(nameof(Target.LockoutEnabled)))
            {
                Target.LockoutEnabled = source.LockoutEnabled;
            }

            if (result.Contains(nameof(Target.LockoutEnd)))
            {
                Target.LockoutEnd = source.LockoutEnd;
            }

            if (result.Contains(nameof(Target.NormalizedEmail)))
            {
                Target.NormalizedEmail = source.NormalizedEmail;
            }

            if (result.Contains(nameof(Target.NormalizedUserName)))
            {
                Target.NormalizedUserName = source.NormalizedUserName;
            }

            if (result.Contains(nameof(Target.PasswordHash)))
            {
                Target.PasswordHash = source.PasswordHash;
            }

            if (result.Contains(nameof(Target.PhoneNumber)))
            {
                Target.PhoneNumber = source.PhoneNumber;
            }

            if (result.Contains(nameof(Target.PhoneNumberConfirmed)))
            {
                Target.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            }

            if (result.Contains(nameof(Target.SecurityStamp)))
            {
                Target.SecurityStamp = source.SecurityStamp;
            }

            if (result.Contains(nameof(Target.TwoFactorEnabled)))
            {
                Target.TwoFactorEnabled = source.TwoFactorEnabled;
            }

            if (result.Contains(nameof(Target.UserName)))
            {
                Target.UserName = source.UserName;
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
                nameof(Target.AccessFailedCount),
                nameof(Target.ConcurrencyStamp),
                nameof(Target.Email),
                nameof(Target.EmailConfirmed),
                nameof(Target.FullName),
                nameof(Target.Id),
                nameof(Target.LockoutEnabled),
                nameof(Target.LockoutEnd),
                nameof(Target.NormalizedEmail),
                nameof(Target.NormalizedUserName),
                nameof(Target.PasswordHash),
                nameof(Target.PhoneNumber),
                nameof(Target.PhoneNumberConfirmed),
                nameof(Target.SecurityStamp),
                nameof(Target.TwoFactorEnabled),
                nameof(Target.UserName)
            };
        }

        #endregion Protected methods
    }
}
