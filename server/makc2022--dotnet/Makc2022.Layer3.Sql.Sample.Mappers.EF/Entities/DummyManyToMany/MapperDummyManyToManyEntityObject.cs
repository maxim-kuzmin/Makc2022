// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Объект сущности "DummyManyToMany" сопоставителя.
    /// </summary>
    public class MapperDummyManyToManyEntityObject : DummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<MapperDummyMainDummyManyToManyEntityObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<MapperDummyMainDummyManyToManyEntityObject>();

        #endregion Properties
    }
}
