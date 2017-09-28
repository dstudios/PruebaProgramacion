using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace TestCoppel.Core.Data
{
    public static class DbConnectionFactory
    {
        public static DbConnection GetConnection(string connectionName)
        {
            ConnectionStringSettings connectionConfig = ConfigurationManager.ConnectionStrings[connectionName];
            if (connectionConfig == null || string.IsNullOrEmpty(connectionConfig.ConnectionString))
            {
                throw new ArgumentException(
                    string.Format("Connection \"{0}\" was not found or is empty.", connectionName));
            }
            DbConnection connection = new SqlConnection(connectionConfig.ConnectionString);
            return connection;
        }

        public static DbConnection GetWrappedDbConnection(string connectionName)
        {
            //get connection
            DbConnection connection = GetConnection(connectionName);

            return connection;
        }
    }
}
