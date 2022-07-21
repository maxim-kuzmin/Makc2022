// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Common;
using Makc2022.Layer1.Query;
using Makc2022.Layer1.Query.Handlers;
using Makc2022.Layer1.Setting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Обработчик запроса на получение списка в домене.
    /// </summary>
    public class DomainListGetQueryHandler :
        QueryWithInputAndOutputHandler<DomainListGetQueryInput, DomainListGetQueryOutput>,
        IDomainListGetQueryHandler
    {
        #region Constructors

        /// <inheritdoc/>
        public DomainListGetQueryHandler(
            IDomainResource domainResource,
            IQueryResource queryResource,
            ILogger<DomainListGetQueryHandler> logger,
            IOptionsMonitor<SettingOptions> settingOptions)
            : base(
                domainResource.GetListGetQueryName(),
                queryResource,
                logger,
                settingOptions)
        {
            FunctionToTransformQueryInput = TransformQueryInput;
        }

        #endregion Constructors

        #region Private methods

        private DomainListGetQueryInput TransformQueryInput(DomainListGetQueryInput input)
        {
            if (input == null)
            {
                input = new DomainListGetQueryInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CommonException(QueryResource.GetErrorMessageForInvalidInput(invalidProperties));
            }

            return input;
        }

        #endregion Private methods
    }
}
