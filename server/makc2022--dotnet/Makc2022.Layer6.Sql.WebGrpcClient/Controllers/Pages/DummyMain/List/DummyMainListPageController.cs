// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer5.Sql.GrpcServer.Protos.Pages.DummyMain.List;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Makc2022.Layer6.Sql.WebGrpcClient.Controllers.Pages.DummyMain.List
{
    /// <summary>
    /// Контроллер страницы сущностей "DummyMain".
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/pages/dummy-main/list/{operationCode}")]
    public class DummyMainListPageController : ControllerBase
    {
        #region Properties        

        private DummyMainListPage.DummyMainListPageClient Client { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="сlient">Клиент.</param>
        public DummyMainListPageController(DummyMainListPage.DummyMainListPageClient сlient)
        {
            Client = сlient;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="operationCode">Код операции.</param>
        /// <param name="pageNumber">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="sortDirection">Направление сортировки.</param>
        /// <param name="sortField">Поле сортировки.</param>
        /// <param name="entityName">Имя сущности.</param>
        /// <returns>Задача на получение результата.</returns>
        [HttpGet]
        public async Task<IActionResult> Get(
            string operationCode,
            int pageNumber,
            int pageSize,
            string sortDirection,
            string sortField,
            string entityName
            )
        {
            DummyMainListPageGetRequest request = new()
            {
                OperationCode = operationCode,
                List = new()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    SortDirection = sortDirection,
                    SortField = sortField,
                    EntityName = entityName
                }
            };

            var reply = await Client.GetAsync(request).ResponseAsync;

            return Ok(reply);
        }

        #endregion Public methods
    }
}
