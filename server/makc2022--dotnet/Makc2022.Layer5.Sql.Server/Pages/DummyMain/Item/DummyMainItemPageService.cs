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
    /// Сервис страницы сущности "Фиктивное главное".
    /// </summary>
    public class DummyMainItemPageService : IDummyMainItemPageService
    {
        #region Properties

        private IDummyMainDomainItemGetOperationHandler DummyMainDomainItemGetOperationHandler { get; }

        private IDummyMainDomainService DummyMainDomainService { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dummyMainDomainItemGetOperationHandler">Обработчик операции получения элемента в домене "Фиктивное главное".</param>
        /// <param name="dummyMainDomainService">Сервис домена "Фиктивное главное".</param>
        public DummyMainItemPageService(
            IDummyMainDomainItemGetOperationHandler dummyMainDomainItemGetOperationHandler,
            IDummyMainDomainService dummyMainDomainService
            )
        {
            DummyMainDomainItemGetOperationHandler = dummyMainDomainItemGetOperationHandler;
            DummyMainDomainService = dummyMainDomainService;
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

            List<OperationResult> operationResults = new();

            var item = input.DummyMainDomainItemGetOperationInput;

            await operationResults.AddWithOutputAsync(
                () => GetItemGetOperationResult(
                    new DummyMainDomainItemGetOperationInput
                    {
                        Id = item.Id
                    },
                    operationCode
                    ),
                operationOutput => output.DummyMainDomainItemGetOperationOutput = operationOutput);

            result.Load(operationResults);

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
            var operationHandler = DummyMainDomainItemGetOperationHandler;

            try
            {
                operationHandler.OnStart(input, operationCode);

                var operationOutput = await DummyMainDomainService.GetItem(operationHandler.OperationInput!);

                operationHandler.OnSuccess(operationOutput);
            }
            catch (Exception ex)
            {
                operationHandler.OnError(ex);
            }

            return operationHandler.OperationResult!;
        }

        #endregion Private methods
    }
}
