// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyMain;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain
{
    /// <summary>
    /// Расширение сущности "DummyMain" сопоставителя.
    /// </summary>
    public static class MapperDummyMainEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из объекта сущности в объект сопоставителя.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <returns>Объект сопоставителя.</returns>
        public static MapperDummyMainEntityObject FromEntityToMapperObject(
            this DummyMainEntityObject entityObject
            )
        {
            MapperDummyMainEntityObject result = new();

            new DummyMainEntityLoader(result).Load(entityObject);

            return result;
        }

        /// <summary>
        /// Преобразовать из объекта сопоставителя в объект сущности.
        /// </summary>
        /// <param name="mapperObject">Объект сопоставителя.</param>
        /// <returns>Объект сущности.</returns>
        public static DummyMainEntityObject FromMapperToEntityObject(
            this MapperDummyMainEntityObject mapperObject
            )
        {
            DummyMainEntityLoader loader = new();

            loader.Load(mapperObject);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
