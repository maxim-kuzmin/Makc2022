// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyOneToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain
{
    /// <summary>
    /// Сущность типа "DummyMain" сопоставителя.
    /// </summary>
    public class MapperDummyMainTypeEntity : DummyMainTypeEntity
    {
        #region Properties

        /// <summary>
        /// Сущность типа "DummyOneToMany".
        /// </summary>
        public MapperDummyOneToManyTypeEntity? ObjectOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<MapperDummyMainDummyManyToManyTypeEntity> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<MapperDummyMainDummyManyToManyTypeEntity>();

        #endregion Properties
    }
}
