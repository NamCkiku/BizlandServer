using Bizland.Application.Services.Room.EventHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Application.Service.Room.EventHandlers
{
    public class RoomEventHandler :
        INotificationHandler<RoomAddEvent>
    {
        public Task Handle(RoomAddEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }
    }
}
