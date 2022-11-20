// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.List.Operations.Get
{
    /// <summary>
    /// Входные данные операции получения страницы сущностей "DummyMain".
    /// </summary>
    public class DummyMainListPageGetOperationInput
    {
        #region Properties

        /// <summary>
        /// Список.
        /// </summary>
        public DomainListGetOperationInput List { get; } = new();

        #endregion Properties
    }
}
