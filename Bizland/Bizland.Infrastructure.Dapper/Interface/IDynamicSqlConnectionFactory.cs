using System.Data;

namespace Bizland.Infrastructure.Dapper
{
    public interface IDynamicSqlConnectionFactory
    {
        IDbConnection GetOpenConnection(string dbConnString);
    }
}