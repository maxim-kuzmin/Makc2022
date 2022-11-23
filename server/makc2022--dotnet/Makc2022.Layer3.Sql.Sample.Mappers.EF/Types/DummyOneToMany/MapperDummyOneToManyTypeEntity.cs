// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyOneToMany
{
    /// <summary>
    /// Сущность типа "Фиктивное отношение один ко многим" сопоставителя.
    /// </summary>
    public class MapperDummyOneToManyTypeEntity : DummyOneToManyTypeEntity
    {
        #region Navigation properties

        /// <summary>
        /// Список экземпляров сущности "Фиктивное главное".
        /// </summary>
        public List<MapperDummyMainTypeEntity> DummyMainList { get; } = new();

        #endregion Navigation properties
    }
}
