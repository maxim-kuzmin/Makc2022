// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Query;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.List.Queries.Get;
using DummyMainDomainListGetQueryInput = Makc2022.Layer4.Sql.Domains.DummyMain.Queries.List.Get.DomainListGetQueryInput;
using DummyMainDomainListGetQueryOutput = Makc2022.Layer4.Sql.Domains.DummyMain.Queries.List.Get.DomainListGetQueryOutput;
using IDummyMainDomainListGetQueryHandler = Makc2022.Layer4.Sql.Domains.DummyMain.Queries.List.Get.IDomainListGetQueryHandler;
using IDummyMainDomainService = Makc2022.Layer4.Sql.Domains.DummyMain.IDomainService;

namespace Makc2022.Layer5.Sql.Server.Pages.DummyMain.List
{
    /// <summary>
    /// Сервис страницы сущностей "DummyMain".
    /// </summary>
    public class DummyMainListPageService : IDummyMainListPageService
    {
        private IDummyMainDomainListGetQueryHandler HandlerOfMainDomainDomainListGetQuery { get; }

        private IDummyMainDomainService ServiceOfDummyMainDomain { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="handlerOfMainDomainDomainListGetQuery">Обработчик запроса на получение списка в домене "DummyMain".</param>
        /// <param name="serviceOfDummyMainDomain">Сервис домена "DummyMain".</param>
        public DummyMainListPageService(
            IDummyMainDomainListGetQueryHandler handlerOfMainDomainDomainListGetQuery,
            IDummyMainDomainService serviceOfDummyMainDomain
            )
        {
            HandlerOfMainDomainDomainListGetQuery = handlerOfMainDomainDomainListGetQuery;
            ServiceOfDummyMainDomain = serviceOfDummyMainDomain;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<QueryResultWithOutput<DummyMainListPageGetQueryOutput>> Get(
            DummyMainListPageGetQueryInput input,
            string? queryCode = null
            )
        {
            QueryResultWithOutput<DummyMainListPageGetQueryOutput> result = new();

            if (string.IsNullOrWhiteSpace(queryCode))
            {
                queryCode = result.QueryCode;
            }
            else
            {
                result.QueryCode = queryCode;
            }

            DummyMainListPageGetQueryOutput output = new();

            List<QueryResult> queryResults = new();

            var list = input.List;

            await queryResults.AddWithOutputAsync(
                () => GetListGetQueryResult(
                    new DummyMainDomainListGetQueryInput
                    {
                        PageNumber = list.PageNumber,
                        PageSize = list.PageSize,
                        SortDirection = list.SortDirection,
                        SortField = list.SortField,
                        EntityName = list.EntityName
                    },
                    queryCode
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

        private async Task<QueryResultWithOutput<DummyMainDomainListGetQueryOutput>> GetListGetQueryResult(
            DummyMainDomainListGetQueryInput input,
            string queryCode
            )
        {
            var queryHandler = HandlerOfMainDomainDomainListGetQuery;

            try
            {
                queryHandler.OnStart(input, queryCode);

                var queryOutput = await ServiceOfDummyMainDomain.GetList(queryHandler.QueryInput!);

                queryHandler.OnSuccess(queryOutput);
            }
            catch (Exception ex)
            {
                queryHandler.OnError(ex);
            }

            return queryHandler.QueryResult!;
        }

        #endregion Private methods
    }
}
