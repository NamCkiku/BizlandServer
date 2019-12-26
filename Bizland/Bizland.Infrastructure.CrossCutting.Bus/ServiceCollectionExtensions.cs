using Bizland.Domain.Core;
using Bizland.Domain.Core.Bus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.CrossCutting.Bus
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainEventBus(this IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.Replace(ServiceDescriptor.Scoped<IDomainEventDispatcher, DomainEventDispatcher>());
            return services;
        }
    }
}
