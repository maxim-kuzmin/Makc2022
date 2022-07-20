// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Clients.Oracle.Setting;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;

namespace Makc2022.Layer2.Sql.Clients.Oracle
{
    /// <summary>
    /// Сервис клиента.
    /// </summary>
    public class ClientService : IClientService
    {
        #region Properties

        private IOptionsMonitor<ClientSettingOptions> СlientSettingOptions { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="clientSettingOptions">Параметры настройки клиента.</param>
        public ClientService(IOptionsMonitor<ClientSettingOptions> clientSettingOptions)
        {
            СlientSettingOptions = clientSettingOptions;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void Configure()
        {
            var currentClientSettingOptions = СlientSettingOptions.CurrentValue;

            OracleConfiguration.TnsAdmin = currentClientSettingOptions.TnsAdmin;
        }

        #endregion Public methods
    }
}
