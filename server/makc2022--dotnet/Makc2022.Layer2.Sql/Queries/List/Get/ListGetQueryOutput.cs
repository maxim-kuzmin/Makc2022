// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer2.Sql.Queries.List.Get
{
    /// <summary>
    /// Выходные данные запроса на получение списка.
    /// </summary>
    /// <typeparam name="TItem">Тип элемента.</typeparam>
    public class ListGetQueryOutput<TItem>
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
