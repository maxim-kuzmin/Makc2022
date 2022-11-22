// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyManyToMany;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность типа "Фиктивное отношение многие ко многим фиктивного главного" сопоставителя.
    /// </summary>
    public class MapperDummyMainDummyManyToManyTypeEntity : DummyMainDummyManyToManyTypeEntity
    {
        #region Properties

        /// <summary>
        /// Сущность типа "Фиктивное главное".
        /// </summary>
        public MapperDummyMainTypeEntity? ObjectOfDummyMainEntity { get; set; }

        /// <summary>
        /// Сущность типа "Фиктивное отношение многие ко многим".
        /// </summary>
        public MapperDummyManyToManyTypeEntity? ObjectOfDummyManyToManyEntity { get; set; }

        #endregion Properties
    }
}
