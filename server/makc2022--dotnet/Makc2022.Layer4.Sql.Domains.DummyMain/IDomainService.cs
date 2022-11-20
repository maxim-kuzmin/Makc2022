// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get;

namespace Makc2022.Layer4.Sql.Domains.DummyMain
{
    /// <summary>
    /// Интерфейс сервиса домена.
    /// </summary>
    public interface IDomainService
    {
        #region Methods

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        /// <returns>Задача на выполнение операции с выходными данными.</returns>
        Task<DomainItemGetOperationOutput?> GetItem(DomainItemGetOperationInput input);

        /// <summary>
        /// Получить список.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        /// <returns>Задача на выполнение операции с выходными данными.</returns>
        Task<DomainListGetOperationOutput> GetList(DomainListGetOperationInput input);

        #endregion Methods
    }
}
