// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.User;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserLogin;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.UserToken;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.User
{
    /// <summary>
    /// Объект сущности "User" сопоставителя.
    /// </summary>
    public class MapperUserEntityObject : UserEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "UserClaim".
        /// </summary>
        public List<MapperUserClaimEntityObject> ObjectsOfUserClaimEntity { get; } =
            new List<MapperUserClaimEntityObject>();

        /// <summary>
        /// Объекты сущности "UserLogin".
        /// </summary>
        public List<MapperUserLoginEntityObject> ObjectsOfUserLoginEntity { get; } =
            new List<MapperUserLoginEntityObject>();

        /// <summary>
        /// Объекты сущности "UserRole".
        /// </summary>
        public List<MapperUserRoleEntityObject> ObjectsOfUserRoleEntity { get; } =
            new List<MapperUserRoleEntityObject>();

        /// <summary>
        /// Объекты сущности "UserToken".
        /// </summary>
        public List<MapperUserTokenEntityObject> ObjectsOfUserTokenEntity { get; } =
            new List<MapperUserTokenEntityObject>();

        #endregion Properties
    }
}
