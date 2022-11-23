// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyOneToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain
{
    /// <summary>
    /// Сущность типа "Фиктивное главное" сопоставителя.
    /// </summary>
    public class MapperDummyMainTypeEntity : DummyMainTypeEntity
    {
        #region Navigation properties

        /// <summary>
        /// Список экземпляров сущности "Фиктивное отношение многие ко многим фиктивного главного".
        /// </summary>
        public List<MapperDummyMainDummyManyToManyTypeEntity> DummyMainDummyManyToManyList { get; } = new();

        /// <summary>
        /// Экземпляр сущности "Фиктивное отношение один ко многим".
        /// </summary>
        public MapperDummyOneToManyTypeEntity? DummyOneToMany { get; set; }

        #endregion Navigation properties
    }
}
