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
        private IDummyMainDomainListGetOperationHandler HandlerOfMainDomainDomainListGetOperation { get; }

        private IDummyMainDomainService ServiceOfDummyMainDomain { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="handlerOfMainDomainDomainListGetOperation">Обработчик операции получения списка в домене "Фиктивное главное".</param>
        /// <param name="serviceOfDummyMainDomain">Сервис домена "Фиктивное главное".</param>
        public DummyMainListPageService(
            IDummyMainDomainListGetOperationHandler handlerOfMainDomainDomainListGetOperation,
            IDummyMainDomainService serviceOfDummyMainDomain
            )
        {
            HandlerOfMainDomainDomainListGetOperation = handlerOfMainDomainDomainListGetOperation;
            ServiceOfDummyMainDomain = serviceOfDummyMainDomain;
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

            List<OperationResult> queryResults = new();

            var list = input.List;

            await queryResults.AddWithOutputAsync(
                () => GetListGetOperationResult(
                    new DummyMainDomainListGetOperationInput
                    {
                        PageNumber = list.PageNumber,
                        PageSize = list.PageSize,
                        SortDirection = list.SortDirection,
                        SortField = list.SortField,
                        EntityName = list.EntityName
                    },
                    operationCode
                    ),
                queryOutput => output.List = queryOutput
                );

            result.Load(queryResults);

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
            var queryHandler = HandlerOfMainDomainDomainListGetOperation;

            try
            {
                queryHandler.OnStart(input, operationCode);

                var queryOutput = await ServiceOfDummyMainDomain.GetList(queryHandler.OperationInput!);

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
