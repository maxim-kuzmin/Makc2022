// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer2.Sql.Clients.SqlServer.Filestream
{
    /// <summary>
    /// Доступ к файловому потоку клиента.
    /// </summary>
    public enum ClientFilestreamAccess : uint
    {
        /// <summary>
        /// Прочитать.
        /// </summary>
        Read,
        /// <summary>
        /// Записать.
        /// </summary>
        Write,
        /// <summary>
        /// Прочитать и записать.
        /// </summary>
        ReadWrite
    }
}
