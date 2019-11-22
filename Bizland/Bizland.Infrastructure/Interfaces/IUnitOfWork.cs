using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IRepositoryFactory, IDisposable
    {
        int Commit();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
