using Bizland.Utilities.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Domain.Core.Models
{
    public class OutboxMessage : AggregateRootBase
    {

        /// <summary>
        /// Occurred on.
        /// </summary>
        public DateTime OccurredOn { get; private set; }

        /// <summary>
        /// Full name of message type.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Message data - serialzed to JSON.
        /// </summary>
        public string Data { get; private set; }

        public DateTime? ProcessedDate { get; private set; }

        private OutboxMessage()
        {

        }

        public OutboxMessage(string type, DateTime occurredOn, string data)
        {
            OccurredOn = occurredOn;
            Type = type;
            Data = data;
        }

        public OutboxMessage(IEvent @event)
        {
            OccurredOn = @event.OccurredOn;
            Type = @event.GetType().FullName;
            Data = JsonConvert.SerializeObject(@event);
        }

        public OutboxMessage UpdateProcessedDate()
        {
            ProcessedDate = DateTimeHelper.GenerateDateTime();
            return this;
        }
    }
}
