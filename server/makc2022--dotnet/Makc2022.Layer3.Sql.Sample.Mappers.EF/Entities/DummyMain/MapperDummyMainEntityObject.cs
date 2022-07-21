// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain
{
    /// <summary>
    /// Объект сущности "DummyMain" сопоставителя.
    /// </summary>
    public class MapperDummyMainEntityObject : DummyMainEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyOneToMany".
        /// </summary>
        public MapperDummyOneToManyEntityObject? ObjectOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<MapperDummyMainDummyManyToManyEntityObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<MapperDummyMainDummyManyToManyEntityObject>();

        #endregion Properties
    }
}
