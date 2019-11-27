using Microsoft.Data.SqlClient;

using System;
using System.Data;

namespace Bizland.Infrastructure.Dapper
{
    public class DynamicSqlConnectionFactory : IDynamicSqlConnectionFactory, IDisposable
    {
        private IDbConnection _connection;

        public IDbConnection GetOpenConnection(string dbConnString)
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(dbConnString);
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }
    }
}