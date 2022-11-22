// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;

namespace Makc2022.Layer3.Sql.Sample.Types.User
{
    /// <summary>
    /// Сущность типа "Пользователь".
    /// </summary>
    public class UserTypeEntity : IdentityUser<long>
    {
        #region Properties

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string? FullName { get; set; }

        #endregion Properties
    }
}
