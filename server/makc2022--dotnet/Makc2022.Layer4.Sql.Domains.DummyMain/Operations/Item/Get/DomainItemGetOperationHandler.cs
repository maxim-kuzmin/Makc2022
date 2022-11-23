// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions;
using Makc2022.Layer1.Operation;
using Makc2022.Layer1.Operation.Handlers;
using Makc2022.Layer1.Setup;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get
{
    /// <summary>
    /// Обработчик операции получения элемента в домене.
    /// </summary>
    public class DomainItemGetOperationHandler :
        OperationWithInputAndOutputHandler<DomainItemGetOperationInput, DomainItemGetOperationOutput>,
        IDomainItemGetOperationHandler
    {
        #region Constructors

        /// <inheritdoc/>
        public DomainItemGetOperationHandler(
            IDomainResource domainResource,
            IOperationResource operationResource,
            ILogger<DomainItemGetOperationHandler> logger,
            IOptionsMonitor<SetupOptions> setupOptions)
            : base(
                domainResource.GetItemGetOperationName(),
                operationResource,
                logger,
                setupOptions)
        {
            FunctionToTransformOperationInput = TransformOperationInput;
            FunctionToTransformOperationOutput = TransformOperationOutput;
        }

        #endregion Constructors

        #region Private methods

        private DomainItemGetOperationInput TransformOperationInput(DomainItemGetOperationInput input)
        {
            if (input == null)
            {
                input = new DomainItemGetOperationInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new LocalizedException(OperationResource.GetErrorMessageForInvalidInput(invalidProperties));
            }

            return input;
        }

        private DomainItemGetOperationOutput? TransformOperationOutput(DomainItemGetOperationOutput output)
        {
            return output.DummyMain != null ? output : null;
        }

        #endregion Private methods
    }
}
