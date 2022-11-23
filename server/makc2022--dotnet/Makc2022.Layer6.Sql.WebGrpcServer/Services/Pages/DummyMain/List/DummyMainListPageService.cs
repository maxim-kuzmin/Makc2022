// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Grpc.Core;
using Makc2022.Layer5.Sql.GrpcServer.Protos.Pages.DummyMain.List;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.List;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.List.Operations.Get;

namespace Makc2022.Layer6.Sql.WebGrpcServer.Services.Pages.DummyMain.List
{
    public class DummyMainListPageService : DummyMainListPage.DummyMainListPageBase
    {
        #region Properties

        private IDummyMainListPageService Service { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="service">Сервис.</param>
        public DummyMainListPageService(IDummyMainListPageService service)
        {
            Service = service;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="context">Контекст.</param>
        /// <returns>Задача на получение ответа.</returns>
        public async override Task<DummyMainListPageGetReply> Get(
            DummyMainListPageGetRequest request,
            ServerCallContext context
            )
        {
            DummyMainListPageGetOperationInput input = new();

            input.List.PageNumber = request.List.PageNumber;
            input.List.PageSize = request.List.PageSize;
            input.List.SortDirection = request.List.SortDirection;
            input.List.SortField = request.List.SortField;
            input.List.Name = request.List.Name;

            var operationResult = await Service.Get(input, request.OperationCode);

            var list = operationResult.Output?.List;

            var result = new DummyMainListPageGetReply
            {
                IsOk = operationResult.IsOk,
                Output = new()
                {
                    List = list != null ? new()
                    {
                        TotalCount = list.TotalCount
                    } : null
                },
                OperationCode = operationResult.OperationCode
            };

            result.ErrorMessages.AddRange(operationResult.ErrorMessages);            
            result.WarningMessages.AddRange(operationResult.WarningMessages);
            result.SuccessMessages.AddRange(operationResult.SuccessMessages);

            result.Output.List?.Items.AddRange(
                list?.Items?.Select(x =>
                    new DummyMainDomainItemGetOperationOutput
                    {
                        DummyMain = x.DummyMain != null ? new()
                        {
                            Id = x.DummyMain.Id,
                            Name = x.DummyMain.Name
                        } : null
                    })
                );

            return result;
        }

        #endregion Public methods
    }
}
