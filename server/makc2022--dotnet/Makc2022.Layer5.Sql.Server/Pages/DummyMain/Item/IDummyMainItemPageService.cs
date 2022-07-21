// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Query;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item.Queries.Get;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item
{
    /// <summary>
    /// Интерфейс сервиса страницы сущности "DummyMain".
    /// </summary>
    public interface IDummyMainItemPageService
    {
        #region Methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        /// <param name="queryCode">Код запроса.</param>
        /// <returns>Задача на выполнение запроса с выходными данными.</returns>
        Task<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> Get(
            DummyMainItemPageGetQueryInput input,
            string? queryCode = null
            );

        #endregion Methods
    }
}
