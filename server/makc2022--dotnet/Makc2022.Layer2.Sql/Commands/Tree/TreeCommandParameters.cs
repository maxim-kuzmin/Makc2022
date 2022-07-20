// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Data.Common;

namespace Makc2022.Layer2.Sql.Commands.Tree
{
    /// <summary>
    /// Параметры команды дерева.
    /// </summary>
    public class TreeCommandParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new();

        #endregion Properties
    }
}
