using Bizland.Domain.Core.Bus;
using Bizland.Domain.Core.Commands;
using Bizland.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : EventBus
        {
            return _mediator.Publish(@event);
        }
    }
}
