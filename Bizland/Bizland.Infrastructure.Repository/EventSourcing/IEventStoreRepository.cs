using Bizland.Domain.Core;

using System;

namespace Bizland.Infrastructure.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);

        //IList<StoredEvent> All(Guid aggregateId);
    }
}