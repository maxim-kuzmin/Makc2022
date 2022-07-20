// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer2.Sql.Clients.Oracle.Setting
{
    /// <summary>
    /// Параметры настройки клиента.
    /// </summary>
    public class ClientSettingOptions
    {
        #region Properties

        /// <summary>
        /// Путь к файлу tnsnames.ora.
        /// </summary>
        public string? TnsAdmin { get; set; }

        #endregion Properties
    }
}
