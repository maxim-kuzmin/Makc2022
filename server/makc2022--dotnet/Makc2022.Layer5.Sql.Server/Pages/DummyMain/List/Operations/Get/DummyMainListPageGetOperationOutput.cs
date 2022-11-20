// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.List.Operations.Get
{
    /// <summary>
    /// Выходные данные операции получения страницы сущностей "DummyMain".
    /// </summary>
    public class DummyMainListPageGetOperationOutput
    {
        #region Properties

        /// <summary>
        /// Список.
        /// </summary>
        public DomainListGetOperationOutput? List { get; set; }

        #endregion Properties
    }
}
