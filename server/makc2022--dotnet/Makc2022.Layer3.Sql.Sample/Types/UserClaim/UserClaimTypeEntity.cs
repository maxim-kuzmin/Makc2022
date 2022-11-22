// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;

namespace Makc2022.Layer3.Sql.Sample.Types.UserClaim
{
    /// <summary>
    /// Сущность типа "Утверждение пользователя".
    /// </summary>
    public class UserClaimTypeEntity : IdentityUserClaim<long>
    {
    }
}
