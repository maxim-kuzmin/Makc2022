// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Makc2022.Layer2.Sql.Setup
{
    /// <summary>
    /// Параметры настройки.
    /// </summary>
    public class SetupOptions
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        public int DbCommandTimeout { get; set; }

        /// <summary>
        /// Уровень логирования.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        #endregion Properties
    }
}