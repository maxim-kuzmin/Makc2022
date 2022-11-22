// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.UserToken;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserToken
{
    /// <summary>
    /// Сущность типа "UserToken" сопоставителя.
    /// </summary>
    public class MapperUserTokenTypeEntity : UserTokenTypeEntity
    {
        #region Properties

        /// <summary>
        /// Сущность типа "User".
        /// </summary>
        public MapperUserTypeEntity? ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
