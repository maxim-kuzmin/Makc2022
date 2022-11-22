// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.User;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserLogin;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserRole;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserToken;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.User
{
    /// <summary>
    /// Сущность типа "User" сопоставителя.
    /// </summary>
    public class MapperUserTypeEntity : UserTypeEntity
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "UserClaim".
        /// </summary>
        public List<MapperUserClaimTypeEntity> ObjectsOfUserClaimEntity { get; } =
            new List<MapperUserClaimTypeEntity>();

        /// <summary>
        /// Объекты сущности "UserLogin".
        /// </summary>
        public List<MapperUserLoginTypeEntity> ObjectsOfUserLoginEntity { get; } =
            new List<MapperUserLoginTypeEntity>();

        /// <summary>
        /// Объекты сущности "UserRole".
        /// </summary>
        public List<MapperUserRoleTypeEntity> ObjectsOfUserRoleEntity { get; } =
            new List<MapperUserRoleTypeEntity>();

        /// <summary>
        /// Объекты сущности "UserToken".
        /// </summary>
        public List<MapperUserTokenTypeEntity> ObjectsOfUserTokenEntity { get; } =
            new List<MapperUserTokenTypeEntity>();

        #endregion Properties
    }
}
