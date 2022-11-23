// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using DummyMainDomainItemGetOperationOutput = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get.DomainItemGetOperationOutput;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item.Operations.Get
{
    /// <summary>
    /// Выходные данные операции получения страницы сущности "Фиктивное главное".
    /// </summary>
    public class DummyMainItemPageGetOperationOutput
    {
        #region Properties

        /// <summary>
        /// Выходные данные операции получения элемента в домене "Фиктивное главное".
        /// </summary>
        public DummyMainDomainItemGetOperationOutput? DummyMainDomainItemGetOperationOutput { get; set; }

        #endregion Properties
    }
}
