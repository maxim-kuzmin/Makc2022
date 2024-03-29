﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyManyToMany
{
    /// <summary>
    /// Сущность типа "Фиктивное отношение многие ко многим".
    /// 
    /// Служит для демонстрации связи многих экземпляров одной сущности
    /// со многими экземплярами другой сущности.
    /// 
    /// Многие экземпляры сущности "Фиктивное отношение многие ко многим"
    /// связаны со многими экземплярами сущности "Фиктивное главное".
    /// </summary>
    public class DummyManyToManyTypeEntity
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string? Name { get; set; }

        #endregion Properties       
    }
}
