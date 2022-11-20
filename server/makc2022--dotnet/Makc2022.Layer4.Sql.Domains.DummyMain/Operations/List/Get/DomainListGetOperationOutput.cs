// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Operations.List.Get;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get
{
    /// <summary>
    /// Выходные данные операции получения списка в домене.
    /// </summary>
    public class DomainListGetOperationOutput : ListGetOperationOutput<DomainItemGetOperationOutput>
    {
    }
}
