// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.RoleClaim;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Расширение сущности "RoleClaim" сопоставителя.
    /// </summary>
    public static class MapperRoleClaimEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperRoleClaimEntityObject FromEntityToMapperObject(
            this RoleClaimEntityObject entityObject
            )
        {
            MapperRoleClaimEntityObject result = new();

            new RoleClaimEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static RoleClaimEntityObject FromMapperToEntityObject(
            this MapperRoleClaimEntityObject mapperObject
            )
        {
            RoleClaimEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
