// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.User;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserLogin;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserRole;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserToken;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.User
{
    /// <summary>
    /// Сущность типа "Пользователь" сопоставителя.
    /// </summary>
    public class MapperUserTypeEntity : UserTypeEntity
    {
        #region Navigation properties

        /// <summary>
        /// Список экземпляров сущности "Утверждение пользователя".
        /// </summary>
        public List<MapperUserClaimTypeEntity> UserClaimList { get; } = new();

        /// <summary>
        /// Список экземпляров сущности "Вход пользователя".
        /// </summary>
        public List<MapperUserLoginTypeEntity> UserLoginList { get; } = new();

        /// <summary>
        /// Список экземпляров сущности "Роль пользователя".
        /// </summary>
        public List<MapperUserRoleTypeEntity> UserRoleList { get; } = new();

        /// <summary>
        /// Список экземпляров сущности "Токен пользователя".
        /// </summary>
        public List<MapperUserTokenTypeEntity> UserTokenList { get; } = new();

        #endregion Navigation properties
    }
}
