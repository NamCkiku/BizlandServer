using System.Data;

namespace Bizland.Infrastructure.Dapper
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
