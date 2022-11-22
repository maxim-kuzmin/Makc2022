// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Makc2022.Layer2.Sql.Clients.SqlServer.Commands.Identity.Reseed;
using Makc2022.Layer2.Sql.Clients.SqlServer.Commands.Tree.Calculate;
using Makc2022.Layer2.Sql.Clients.SqlServer.Commands.Tree.Trigger;
using Makc2022.Layer2.Sql.Clients.SqlServer.Filestream;
using Makc2022.Layer2.Sql.Commands.Identity.Reseed;
using Makc2022.Layer2.Sql.Commands.Tree.Calculate;
using Makc2022.Layer2.Sql.Commands.Tree.Trigger;
using Microsoft.Win32.SafeHandles;

namespace Makc2022.Layer2.Sql.Clients.SqlServer
{
    /// <summary>
    /// Поставщик клиента.
    /// </summary>
    public class ClientProvider : IClientProvider
    {
        #region Public methods

        /// <inheritdoc/>
        public DbParameter CreateDbParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        /// <inheritdoc/>
        public DbCommand? CreateDbCommand(DbConnection connection, DbParameter[] parameters)
        {
            SqlCommand? result = null;

            if (connection is not SqlConnection cn) return result;

            result = cn.CreateCommand();

            if (parameters == null) return result;

            foreach (DbParameter parameter in parameters)
            {
                SqlParameter par = result.CreateParameter();

                string name = parameter.ParameterName;

                if (!string.IsNullOrEmpty(name))
                {
                    if (!name.StartsWith("@"))
                    {
                        name = "@" + name;
                    }

                    par.ParameterName = name;
                }

                par.Direction = parameter.Direction;

                if (parameter.Value is DataTable val)
                {
                    par.SqlDbType = SqlDbType.Structured;
                    par.TypeName = val.TableName;
                    par.SqlValue = val;

                }
                else
                {
                    par.Value = parameter.Value;
                    par.DbType = parameter.DbType;
                }

                result.Parameters.Add(par);
            }

            return result;
        }

        /// <inheritdoc/>   
        public DbConnection CreateDbConnection(string connectionString, Func<string, string>? transformConnectionString = null)
        {
            if (transformConnectionString != null)
            {
                connectionString = transformConnectionString(connectionString);
            }

            return new SqlConnection(connectionString);
        }

        /// <inheritdoc/>
        public IdentityReseedCommandBuilder CreateQueryIdentityReseedBuilder()
        {
            return new ClientIdentityReseedCommandBuilder();
        }

        /// <inheritdoc/>
        public TreeCalculateCommandBuilder CreateQueryTreeCalculateBuilder()
        {
            return new ClientTreeCalculateCommandBuilder();
        }

        /// <inheritdoc/>
        public TreeTriggerCommandBuilder CreateQueryTreeTriggerBuilder()
        {
            return new ClientTreeTriggerCommandBuilder();
        }

        /// <inheritdoc/>
        public SafeFileHandle GetSqlFilestreamHandle(
            string filePath,
            ClientFilestreamAccess access,
            byte[] txnToken
            )
        {
            return OpenSqlFilestream(
                filePath,
                (uint)access,
                0,
                txnToken,
                (uint)txnToken.Length,
                new Sql64(0)
                );
        }

        #endregion Public methods

        #region Private methods

        [DllImport("sqlncli10.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern SafeFileHandle OpenSqlFilestream(
            string path,
            uint access,
            uint options,
            byte[] txnToken,
            uint txnTokenLength,
            Sql64 allocationSize
            );

        [StructLayout(LayoutKind.Sequential)]
        private struct Sql64
        {
            public long QuadPart;

            public Sql64(long quadPart)
            {
                QuadPart = quadPart;
            }
        }

        #endregion Private methods
    }
}
