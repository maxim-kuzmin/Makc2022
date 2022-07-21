// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer4.Sql.Domains.DummyMain.Queries.List.Get;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.List.Queries.Get
{
    /// <summary>
    /// Входные данные запроса на получение страницы сущностей "DummyMain".
    /// </summary>
    public class DummyMainListPageGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Список.
        /// </summary>
        public DomainListGetQueryInput List { get; } = new();

        #endregion Properties
    }
}
