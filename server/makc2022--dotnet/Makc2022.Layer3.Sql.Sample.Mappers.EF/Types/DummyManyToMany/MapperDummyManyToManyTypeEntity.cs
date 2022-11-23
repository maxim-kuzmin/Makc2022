// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyManyToMany
{
    /// <summary>
    /// Сущность типа "Фиктивное отношение многие ко многим" сопоставителя.
    /// </summary>
    public class MapperDummyManyToManyTypeEntity : DummyManyToManyTypeEntity
    {
        #region Navigation properties

        /// <summary>
        /// Список экземпляров сущности "Фиктивное отношение многие ко многим фиктивного главного".
        /// </summary>
        public List<MapperDummyMainDummyManyToManyTypeEntity> DummyMainDummyManyToManyList { get; } = new();

        #endregion Navigation properties
    }
}
