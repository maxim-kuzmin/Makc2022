// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;

namespace Makc2022.Layer3.Sql.Sample.Types.UserRole
{
    /// <summary>
    /// Сущность типа "Роль пользователя".
    /// </summary>
    public class UserRoleTypeEntity : IdentityUserRole<long>
    {
    }
}
