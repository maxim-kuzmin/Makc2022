// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Text;
using Makc2022.Layer2.Sql.Commands.Identity.Reseed;

namespace Makc2022.Layer2.Sql.Clients.PostgreSql.Commands.Identity.Reseed
{
    /// <summary>
    /// Построитель команды на повторное заполнение идентичности клиента.
    /// </summary>
    public class ClientIdentityReseedCommandBuilder : IdentityReseedCommandBuilder
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
            StringBuilder result = new();

            foreach (IdentityReseedCommandInput input in Inputs)
            {
                foreach (string column in input.Columns)
                {
                    result.Append($@"
SELECT setval(pg_get_serial_sequence('""{input.Schema}"".""{input.Table}""', '{column}'), 1);
");
                }
            }

            return result.ToString();
        }

        #endregion Public methods
    }
}
