// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Operation;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.List.Operations.Get;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.List
{
    /// <summary>
    /// Интерфейс сервиса страницы сущностей "Фиктивное главное".
    /// </summary>
    public interface IDummyMainListPageService
    {
        #region Methods

        /// <summary>
        /// Получить.
        /// </summary>        
        /// <param name="input">Входные данные.</param>
        /// <param name="operationCode">Код операции.</param>
        /// <returns>Задача на выполнение запроса с выходными данными.</returns>
        Task<OperationResultWithOutput<DummyMainListPageGetOperationOutput>> Get(
            DummyMainListPageGetOperationInput input,
            string? operationCode = null
            );

        #endregion Methods
    }
}
