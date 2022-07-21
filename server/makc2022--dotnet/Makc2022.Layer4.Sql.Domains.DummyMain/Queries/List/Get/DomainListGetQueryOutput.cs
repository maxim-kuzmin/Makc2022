// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Queries.List.Get;
using Makc2022.Layer4.Sql.Domains.DummyMain.Queries.Item.Get;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Выходные данные запроса на получение списка в домене.
    /// </summary>
    public class DomainListGetQueryOutput : ListGetQueryOutput<DomainItemGetQueryOutput>
    {
    }
}
