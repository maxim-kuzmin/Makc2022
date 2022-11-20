// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer2.Sql.Operations.List.Get
{
    /// <summary>
    /// Выходные данные операции получения списка.
    /// </summary>
    /// <typeparam name="TItem">Тип элемента.</typeparam>
    public class ListGetOperationOutput<TItem>
    {
        #region Properties

        /// <summary>
        /// Элементы.
        /// </summary>
        public TItem[]? Items { get; set; }

        /// <summary>
        /// Общее число элементов.
        /// </summary>
        public long TotalCount { get; set; }

        #endregion Properties
    }
}
