// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Operation.Handlers;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get
{
    /// <summary>
    /// Интерфейс обработчика операции получения элемента в домене.
    /// </summary>
    public interface IDomainItemGetOperationHandler :
        IOperationWithInputAndOutputHandler<DomainItemGetOperationInput, DomainItemGetOperationOutput>
    {
    }
}
