using Bizland.Domain.Core;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Infrastructure.CrossCutting.Bus
{
    public interface IDispatchedEventBus
    {
        Task PublishAsync<TMessage>(TMessage msg, params string[] channels) where TMessage : IEvent, IMessage<TMessage>;
        Task SubscribeAsync<TMessage>(params string[] channels) where TMessage : IEvent, IMessage<TMessage>, new();
    }
}
