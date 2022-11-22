// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.RoleClaim;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.RoleClaim
{
    /// <summary>
    /// Расширение сущности "Утверждение роли" сопоставителя.
    /// </summary>
    public static class MapperRoleClaimTypeExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать в сущность сопоставителя.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Сущность сопоставителя.</returns>
        public static MapperRoleClaimTypeEntity ToMapperEntity(this RoleClaimTypeEntity entity)
        {
            MapperRoleClaimTypeEntity result = new();

            new RoleClaimTypeLoader(result).Load(entity);

            return result;
        }

        /// <summary>
        /// Преобразовать в сущность.
        /// </summary>
        /// <param name="mapperEntity">Сущность сопоставителя.</param>
        /// <returns>Сущность.</returns>
        public static RoleClaimTypeEntity ToEntity(this MapperRoleClaimTypeEntity mapperEntity)
        {
            RoleClaimTypeLoader loader = new();

            loader.Load(mapperEntity);

            return loader.Entity;
        }

        #endregion Public methods
    }
}
