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
        #region Properties

        /// <summary>
        /// Объекты сущности "Фиктивное главное".
        /// </summary>
        public List<MapperDummyMainTypeEntity> ObjectsOfDummyMainEntity { get; } =
            new List<MapperDummyMainTypeEntity>();

        #endregion Properties
    }
}
