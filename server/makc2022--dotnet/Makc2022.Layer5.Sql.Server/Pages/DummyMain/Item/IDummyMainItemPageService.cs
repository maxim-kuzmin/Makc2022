// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Operation;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item.Operations.Get;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item
{
    /// <summary>
    /// Интерфейс сервиса страницы сущности "Фиктивное главное".
    /// </summary>
    public interface IDummyMainItemPageService
    {
        #region Methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        /// <param name="operationCode">Код операции.</param>
        /// <returns>Задача на выполнение запроса с выходными данными.</returns>
        Task<OperationResultWithOutput<DummyMainItemPageGetOperationOutput>> Get(
            DummyMainItemPageGetOperationInput input,
            string? operationCode = null
            );

        #endregion Methods
    }
}
