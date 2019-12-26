using Bizland.Infrastructure.DBContext;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

using System;
using System.Data;

namespace Bizland.Infrastructure.Dapper
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly DbOptions _dapperOptions;
        private IDbConnection _connection;

        public SqlConnectionFactory(DbOptions dapperOptions)
        {
            _dapperOptions = dapperOptions;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_dapperOptions.ConnString);
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