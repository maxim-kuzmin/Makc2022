// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entities.DummyMain;
using Makc2022.Layer3.Sql.Sample.Entities.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Entities.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Entities.DummyOneToMany;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get
{
    /// <summary>
    /// Выходные данные операции получения элемента в домене.
    /// </summary>
    public class DomainItemGetOperationOutput
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyMain".
        /// </summary>
        public DummyMainEntityObject? ObjectOfDummyMainEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyManyToMany".
        /// </summary>
        public DummyManyToManyEntityObject[]? ObjectsOfDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public DummyMainDummyManyToManyEntityObject[]? ObjectsOfDummyMainDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Объект сущности "DummyOneToMany".
        /// </summary>
        public DummyOneToManyEntityObject? ObjectOfDummyOneToManyEntity { get; set; }

        #endregion Properties
    }
}
