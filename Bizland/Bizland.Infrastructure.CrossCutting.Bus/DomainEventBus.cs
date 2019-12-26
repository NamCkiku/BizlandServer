using Bizland.Domain.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.CrossCutting.Bus
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch(IEvent @event)
        {
            await _mediator.Publish(new NotificationEnvelope(@event));
        }

        public void Dispose()
        {
        }

    }
}
