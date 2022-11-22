// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность типа "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public class DummyMainDummyManyToManyTypeEntity
    {
        #region Properties

        /// <summary>
        /// Идентификатор сущности "Фиктивное главное".
        /// </summary>
        public long IdOfDummyMainEntity { get; set; }

        /// <summary>
        /// Идентификатор сущности "Фиктивное отношение многие ко многим".
        /// </summary>
        public long IdOfDummyManyToManyEntity { get; set; }

        #endregion Properties
    }
}
