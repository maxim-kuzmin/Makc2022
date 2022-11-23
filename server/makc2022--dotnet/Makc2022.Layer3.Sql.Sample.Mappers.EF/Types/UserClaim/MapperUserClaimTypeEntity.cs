// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.UserClaim;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.User;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.UserClaim
{
    /// <summary>
    /// Сущность типа "Утверждение пользователя" сопоставителя.
    /// </summary>
    public class MapperUserClaimTypeEntity : UserClaimTypeEntity
    {
        #region Navigation properties

        /// <summary>
        /// Экземпляр сущности "Пользователь".
        /// </summary>
        public MapperUserTypeEntity? User { get; set; }

        #endregion Navigation properties
    }
}
