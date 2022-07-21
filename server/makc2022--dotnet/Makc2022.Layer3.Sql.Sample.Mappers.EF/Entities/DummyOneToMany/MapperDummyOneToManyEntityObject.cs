// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Объект сущности "DummyOneToMany" сопоставителя.
    /// </summary>
    public class MapperDummyOneToManyEntityObject : DummyOneToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMain".
        /// </summary>
        public List<MapperDummyMainEntityObject> ObjectsOfDummyMainEntity { get; } =
            new List<MapperDummyMainEntityObject>();

        #endregion Properties
    }
}
