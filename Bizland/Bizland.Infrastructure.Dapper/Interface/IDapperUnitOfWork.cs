using Bizland.Infrastructure.Interfaces;

namespace Bizland.Infrastructure.Dapper
{
    public interface IDapperUnitOfWork : IUnitOfWork
    {
        ISqlConnectionFactory SqlConnectionFactory { get; }
    }
}
