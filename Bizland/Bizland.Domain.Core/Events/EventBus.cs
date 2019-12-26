using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Domain.Core.Events
{
    public abstract class EventBus : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected EventBus()
        {
            Timestamp = DateTime.Now;
        }
    }
}
