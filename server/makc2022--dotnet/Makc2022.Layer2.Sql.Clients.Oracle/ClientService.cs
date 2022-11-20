// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Clients.Oracle.Setup;
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

        private IOptionsMonitor<ClientSetupOptions> СlientSetupOptions { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="clientSetupOptions">Параметры настройки клиента.</param>
        public ClientService(IOptionsMonitor<ClientSetupOptions> clientSetupOptions)
        {
            СlientSetupOptions = clientSetupOptions;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void Configure()
        {
            var currentClientSetupOptions = СlientSetupOptions.CurrentValue;

            OracleConfiguration.TnsAdmin = currentClientSetupOptions.TnsAdmin;
        }

        #endregion Public methods
    }
}
