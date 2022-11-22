// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Types.DummyMain;
using Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Types.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Types.DummyOneToMany;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get
{
    /// <summary>
    /// Выходные данные операции получения элемента в домене.
    /// </summary>
    public class DomainItemGetOperationOutput
    {
        #region Properties

        /// <summary>
        /// Сущность типа "Фиктивное главное".
        /// </summary>
        public DummyMainTypeEntity? ObjectOfDummyMainEntity { get; set; }

        /// <summary>
        /// Объекты сущности "Фиктивное отношение многие ко многим".
        /// </summary>
        public DummyManyToManyTypeEntity[]? ObjectsOfDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Объекты сущности "Фиктивное отношение многие ко многим фиктивного главного".
        /// </summary>
        public DummyMainDummyManyToManyTypeEntity[]? ObjectsOfDummyMainDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Сущность типа "Фиктивное отношение один ко многим".
        /// </summary>
        public DummyOneToManyTypeEntity? ObjectOfDummyOneToManyEntity { get; set; }

        #endregion Properties
    }
}
