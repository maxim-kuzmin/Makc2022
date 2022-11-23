// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Operation;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.List.Operations.Get;
using DummyMainDomainListGetOperationInput = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get.DomainListGetOperationInput;
using DummyMainDomainListGetOperationOutput = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get.DomainListGetOperationOutput;
using IDummyMainDomainListGetOperationHandler = Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get.IDomainListGetOperationHandler;
using IDummyMainDomainService = Makc2022.Layer4.Sql.Domains.DummyMain.IDomainService;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.List
{
    /// <summary>
    /// Сервис страницы сущностей "Фиктивное главное".
    /// </summary>
    public class DummyMainListPageService : IDummyMainListPageService
    {
        private IDummyMainDomainListGetOperationHandler DummyMainDomainListGetOperationHandler { get; }

        private IDummyMainDomainService DummyMainDomainService { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dummyMainDomainListGetOperationHandler">Обработчик операции получения списка в домене "Фиктивное главное".</param>
        /// <param name="dummyMainDomainService">Сервис домена "Фиктивное главное".</param>
        public DummyMainListPageService(
            IDummyMainDomainListGetOperationHandler dummyMainDomainListGetOperationHandler,
            IDummyMainDomainService dummyMainDomainService
            )
        {
            DummyMainDomainListGetOperationHandler = dummyMainDomainListGetOperationHandler;
            DummyMainDomainService = dummyMainDomainService;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<OperationResultWithOutput<DummyMainListPageGetOperationOutput>> Get(
            DummyMainListPageGetOperationInput input,
            string? operationCode = null
            )
        {
            OperationResultWithOutput<DummyMainListPageGetOperationOutput> result = new();

            if (string.IsNullOrWhiteSpace(operationCode))
            {
                operationCode = result.OperationCode;
            }
            else
            {
                result.OperationCode = operationCode;
            }

            DummyMainListPageGetOperationOutput output = new();

            List<OperationResult> operationResults = new();

            var list = input.List;

            await operationResults.AddWithOutputAsync(
                () => GetListGetOperationResult(
                    new DummyMainDomainListGetOperationInput
                    {
                        PageNumber = list.PageNumber,
                        PageSize = list.PageSize,
                        SortDirection = list.SortDirection,
                        SortField = list.SortField,
                        Name = list.Name
                    },
                    operationCode
                    ),
                operationOutput => output.List = operationOutput
                );

            result.Load(operationResults);

            if (result.IsOk)
            {
                result.Output = output;
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private async Task<OperationResultWithOutput<DummyMainDomainListGetOperationOutput>> GetListGetOperationResult(
            DummyMainDomainListGetOperationInput input,
            string operationCode
            )
        {
            var operationHandler = DummyMainDomainListGetOperationHandler;

            try
            {
                operationHandler.OnStart(input, operationCode);

                var operationOutput = await DummyMainDomainService.GetList(operationHandler.OperationInput!);

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
