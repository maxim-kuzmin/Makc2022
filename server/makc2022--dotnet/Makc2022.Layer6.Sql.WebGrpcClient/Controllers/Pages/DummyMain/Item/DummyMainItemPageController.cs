// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer5.Sql.GrpcServer.Protos.Pages.DummyMain.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Makc2022.Layer6.Sql.WebGrpcClient.Controllers.Pages.DummyMain.Item
{
    /// <summary>
    /// Контроллер страницы сущности "Фиктивное главное".
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/pages/dummy-main/item/{operationCode}")]
    public class DummyMainItemPageController : ControllerBase
    {
        #region Properties

        private DummyMainItemPage.DummyMainItemPageClient Client { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="сlient">Клиент.</param>
        public DummyMainItemPageController(DummyMainItemPage.DummyMainItemPageClient сlient)
        {
            Client = сlient;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="operationCode">Код операции.</param>
        /// <param name="entityId">Идентификатор сущности.</param>
        /// <returns>Задача на получение результата.</returns>
        [HttpGet, Route("{entityId}")]
        public async Task<IActionResult> Get(string operationCode, int entityId)
        {
            DummyMainItemPageGetRequest request = new()
            {
                OperationCode = operationCode,
                Item = new()
                {
                    EntityId = entityId
                }
            };

            var reply = await Client.GetAsync(request).ResponseAsync;

            return Ok(reply);
        }

        #endregion Public methods
    }
}
