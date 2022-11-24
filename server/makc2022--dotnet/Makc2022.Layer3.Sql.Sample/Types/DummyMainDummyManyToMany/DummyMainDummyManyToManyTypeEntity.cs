// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность типа "Фиктивное отношение многие ко многим фиктивного главного".
    /// 
    /// Служит для соединения экземпляров сущностей "Фиктивное главное" и
    /// "Фиктивное отношение многие ко многим".
    /// </summary>
    public class DummyMainDummyManyToManyTypeEntity
    {
        #region Properties

        /// <summary>
        /// Идентификатор экземпляра сущности "Фиктивное главное".
        /// </summary>
        public long DummyMainId { get; set; }

        /// <summary>
        /// Идентификатор экземпляра сущности "Фиктивное отношение многие ко многим".
        /// </summary>
        public long DummyManyToManyId { get; set; }

        #endregion Properties
    }
}
