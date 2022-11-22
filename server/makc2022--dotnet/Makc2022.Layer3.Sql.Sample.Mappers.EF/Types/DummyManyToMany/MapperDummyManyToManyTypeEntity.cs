// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyManyToMany
{
    /// <summary>
    /// Сущность типа "DummyManyToMany" сопоставителя.
    /// </summary>
    public class MapperDummyManyToManyTypeEntity : DummyManyToManyTypeEntity
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<MapperDummyMainDummyManyToManyTypeEntity> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<MapperDummyMainDummyManyToManyTypeEntity>();

        #endregion Properties
    }
}
