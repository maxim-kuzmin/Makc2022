﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.UserClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.User;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim
{
    /// <summary>
    /// Объект сущности "UserClaim" сопоставителя.
    /// </summary>
    public class MapperUserClaimEntityObject : UserClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public MapperUserEntityObject? ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}