﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Grpc.Core;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item.Queries.Get;
using Makc2022.Layer5.Sql.GrpcServer.Protos.Pages.DummyMain.Item;

namespace Makc2022.Layer6.Sql.WebGrpcServer.Services.Pages.DummyMain.Item
{
    public class DummyMainItemPageService : DummyMainItemPage.DummyMainItemPageBase
    {
        #region Properties

        private IDummyMainItemPageService Service { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="service">Сервис.</param>
        public DummyMainItemPageService(IDummyMainItemPageService service)
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
        public async override Task<DummyMainItemPageGetReply> Get(
            DummyMainItemPageGetRequest request,
            ServerCallContext context
            )
        {
            DummyMainItemPageGetQueryInput input = new();

            input.InputOfDummyMainDomainItemGetQuery.EntityId = request.Item.EntityId;

            var queryResult = await Service.Get(input, request.QueryCode);

            var objectOfDummyMainEntity = queryResult.Output?.OutputOfDummyMainDomainItemGetQuery?.ObjectOfDummyMainEntity;

            return new DummyMainItemPageGetReply
            {
                IsOk = queryResult.IsOk,
                Output = new()
                {
                    Item = new()
                    {
                        ObjectOfDummyMainEntity = objectOfDummyMainEntity != null ? new()
                        {
                            Id = objectOfDummyMainEntity.Id,
                            Name = objectOfDummyMainEntity.Name
                        } : null
                    }
                },
                QueryCode = queryResult.QueryCode
            };
        }

        #endregion Public methods
    }
}