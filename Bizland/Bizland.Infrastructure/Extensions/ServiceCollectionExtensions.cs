using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceByIntefaceInAssembly<TRegisteredAssemblyType>(this IServiceCollection services, Type interfaceType)
        {
            services.Scan(s =>
                s.FromAssemblyOf<TRegisteredAssemblyType>()
                    .AddClasses(c => c.AssignableTo(interfaceType))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddServiceByIntefaceInCurrentDomain(this IServiceCollection services, Type interfaceType)
        {
            services.Scan(s =>
                s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    .AddClasses(c => c.AssignableTo(interfaceType))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
    }
}
