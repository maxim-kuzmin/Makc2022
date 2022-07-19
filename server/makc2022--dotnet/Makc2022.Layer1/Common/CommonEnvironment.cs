// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Common
{
    /// <summary>
    /// Общее окружение.
    /// </summary>
    public class CommonEnvironment
    {
        #region Properties

        /// <summary>
        /// Базовый путь: абсолютный путь к папке, относительно которой указываются пути к файлам.
        /// </summary>
        public string BasePath { get; set; } = AppContext.BaseDirectory;

        /// <summary>
        /// Имя.
        /// </summary>
        public string? Name { get; set; } = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        #endregion Properties
    }
}
