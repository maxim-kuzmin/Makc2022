// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.UserLogin;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserLogin
{
    /// <summary>
    /// Сущность типа "Вход пользователя" сопоставителя.
    /// </summary>
    public class MapperUserLoginTypeEntity : UserLoginTypeEntity
    {
        #region Properties

        /// <summary>
        /// Сущность типа "Пользователь".
        /// </summary>
        public MapperUserTypeEntity? ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
