// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using DummyMainDomainItemGetOperationInput = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get.DomainItemGetOperationInput;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item.Operations.Get
{
    /// <summary>
    /// Входные данные операции получения страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageGetOperationInput
    {
        #region Properties

        /// <summary>
        /// Входные данные операции получения элемента в домене "DummyMain".
        /// </summary>
        public DummyMainDomainItemGetOperationInput InputOfDummyMainDomainItemGetOperation { get; } = new();

        #endregion Properties
    }
}
