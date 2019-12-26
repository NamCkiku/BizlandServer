using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IRepositoryFactory, IDisposable
    {
    }
}