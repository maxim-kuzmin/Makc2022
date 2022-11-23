// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using DummyMainDomainItemGetOperationInput = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get.DomainItemGetOperationInput;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item.Operations.Get
{
    /// <summary>
    /// Входные данные операции получения страницы сущности "Фиктивное главное".
    /// </summary>
    public class DummyMainItemPageGetOperationInput
    {
        #region Properties

        /// <summary>
        /// Входные данные операции получения элемента в домене "Фиктивное главное".
        /// </summary>
        public DummyMainDomainItemGetOperationInput DummyMainDomainItemGetOperationInput { get; } = new();

        #endregion Properties
    }
}
