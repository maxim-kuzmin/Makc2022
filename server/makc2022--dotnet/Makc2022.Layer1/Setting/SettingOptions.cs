// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Makc2022.Layer1.Setting
{
    /// <summary>
    /// Параметры настройки.
    /// </summary>
    public class SettingOptions
    {
        #region Properties

        /// <summary>
        /// Уровень логирования.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        #endregion Properties
    }
}