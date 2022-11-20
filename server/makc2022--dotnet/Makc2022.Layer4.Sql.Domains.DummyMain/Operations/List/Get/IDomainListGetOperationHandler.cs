// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Operation.Handlers;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get
{
    /// <summary>
    /// Интерфейс обработчика операции получения списка в домене.
    /// </summary>
    public interface IDomainListGetOperationHandler :
        IOperationWithInputAndOutputHandler<DomainListGetOperationInput, DomainListGetOperationOutput>
    {
    }
}
