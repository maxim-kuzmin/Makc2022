// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions;
using Makc2022.Layer1.Operation;
using Makc2022.Layer1.Operation.Handlers;
using Makc2022.Layer1.Setup;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get
{
    /// <summary>
    /// Обработчик операции получения списка в домене.
    /// </summary>
    public class DomainListGetOperationHandler :
        OperationWithInputAndOutputHandler<DomainListGetOperationInput, DomainListGetOperationOutput>,
        IDomainListGetOperationHandler
    {
        #region Constructors

        /// <inheritdoc/>
        public DomainListGetOperationHandler(
            IDomainResource domainResource,
            IOperationResource operationResource,
            ILogger<DomainListGetOperationHandler> logger,
            IOptionsMonitor<SetupOptions> setupOptions)
            : base(
                domainResource.GetListGetOperationName(),
                operationResource,
                logger,
                setupOptions)
        {
            FunctionToTransformOperationInput = TransformOperationInput;
        }

        #endregion Constructors

        #region Private methods

        private DomainListGetOperationInput TransformOperationInput(DomainListGetOperationInput input)
        {
            if (input == null)
            {
                input = new DomainListGetOperationInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new LocalizedException(OperationResource.GetErrorMessageForInvalidInput(invalidProperties));
            }

            return input;
        }

        #endregion Private methods
    }
}
