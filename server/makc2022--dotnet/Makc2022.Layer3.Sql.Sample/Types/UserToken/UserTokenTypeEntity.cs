// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;

namespace Makc2022.Layer3.Sql.Sample.Types.UserToken
{
    /// <summary>
    /// Сущность типа "UserToken".
    /// </summary>
    public class UserTokenTypeEntity : IdentityUserToken<long>
    {
    }
}
