// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Operation;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item.Operations.Get;
using DummyMainDomainItemGetOperationInput = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get.DomainItemGetOperationInput;
using DummyMainDomainItemGetOperationOutput = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get.DomainItemGetOperationOutput;
using IDummyMainDomainItemGetOperationHandler = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get.IDomainItemGetOperationHandler;
using IDummyMainDomainService = Makc2022.Layer4.Sql.Domains.DummyMain.IDomainService;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item
{
    /// <summary>
    /// Сервис страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageService : IDummyMainItemPageService
    {
        #region Properties

        private IDummyMainDomainItemGetOperationHandler HandlerOfDummyMainDomainItemGetOperation { get; }

        private IDummyMainDomainService ServiceOfDummyMainDomain { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="handlerOfDummyMainDomainItemGetOperation">Обработчик операции получения элемента в домене "DummyMain".</param>
        /// <param name="serviceOfDummyMainDomain">Сервис домена "DummyMain".</param>
        public DummyMainItemPageService(
            IDummyMainDomainItemGetOperationHandler handlerOfDummyMainDomainItemGetOperation,
            IDummyMainDomainService serviceOfDummyMainDomain
            )
        {
            HandlerOfDummyMainDomainItemGetOperation = handlerOfDummyMainDomainItemGetOperation;
            ServiceOfDummyMainDomain = serviceOfDummyMainDomain;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<OperationResultWithOutput<DummyMainItemPageGetOperationOutput>> Get(
            DummyMainItemPageGetOperationInput input,
            string? operationCode = null
            )
        {
            OperationResultWithOutput<DummyMainItemPageGetOperationOutput> result = new();

            if (string.IsNullOrWhiteSpace(operationCode))
            {
                operationCode = result.OperationCode;
            }
            else
            {
                result.OperationCode = operationCode;
            }

            DummyMainItemPageGetOperationOutput output = new();

            List<OperationResult> queryResults = new();

            var item = input.InputOfDummyMainDomainItemGetOperation;

            await queryResults.AddWithOutputAsync(
                () => GetItemGetOperationResult(
                    new DummyMainDomainItemGetOperationInput
                    {
                        EntityId = item.EntityId
                    },
                    operationCode
                    ),
                queryOutput => output.OutputOfDummyMainDomainItemGetOperation = queryOutput);

            result.Load(queryResults);

            if (result.IsOk)
            {
                result.Output = output;
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private async Task<OperationResultWithOutput<DummyMainDomainItemGetOperationOutput>> GetItemGetOperationResult(
            DummyMainDomainItemGetOperationInput input,
            string operationCode
            )
        {
            var queryHandler = HandlerOfDummyMainDomainItemGetOperation;

            try
            {
                queryHandler.OnStart(input, operationCode);

                var queryOutput = await ServiceOfDummyMainDomain.GetItem(queryHandler.OperationInput!);

                queryHandler.OnSuccess(queryOutput);
            }
            catch (Exception ex)
            {
                queryHandler.OnError(ex);
            }

            return queryHandler.OperationResult!;
        }

        #endregion Private methods
    }
}
