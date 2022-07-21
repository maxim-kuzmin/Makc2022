// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Query;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.List.Queries.Get;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.List
{
    /// <summary>
    /// Интерфейс сервиса страницы сущностей "DummyMain".
    /// </summary>
    public interface IDummyMainListPageService
    {
        #region Methods

        /// <summary>
        /// Получить.
        /// </summary>        
        /// <param name="input">Входные данные.</param>
        /// <param name="queryCode">Код запроса.</param>
        /// <returns>Задача на выполнение запроса с выходными данными.</returns>
        Task<QueryResultWithOutput<DummyMainListPageGetQueryOutput>> Get(
            DummyMainListPageGetQueryInput input,
            string? queryCode = null
            );

        #endregion Methods
    }
}
