// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Объект сущности "DummyMainDummyManyToMany".
    /// </summary>
    public class DummyMainDummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор сущности "DummyMain".
        /// </summary>
        public long IdOfDummyMainEntity { get; set; }

        /// <summary>
        /// Идентификатор сущности "DummyManyToMany".
        /// </summary>
        public long IdOfDummyManyToManyEntity { get; set; }

        #endregion Properties
    }
}
