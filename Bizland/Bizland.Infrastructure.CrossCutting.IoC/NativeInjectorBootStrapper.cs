using Bizland.Application.Services;
using Bizland.Application.Services.Interfaces;
using Bizland.Application.Services.Services;
using Bizland.Domain.Entities;
using Bizland.Infrastructure.Configurations;
using Bizland.Infrastructure.CrossCutting.Bus;
using Bizland.Infrastructure.Dapper;
using Bizland.Infrastructure.DBContext;
using Bizland.Infrastructure.EF;
using Bizland.Infrastructure.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //var resolver = services.BuildServiceProvider();
            //using (var scope = resolver.CreateScope())
            //{
            //    services.AddEfCoreSqlServer<RoomDataContext>();
            //    services.AddScoped<ProductDataContext>();
            //}
            services.AddServices();
            services.AddDapperCoreSqlServer();
            services.AddServiceByIntefaceInAssembly<Room>(typeof(IValidator<>));
            services.AddLogingBehavior();
            services.AddDomainEventBus();

            return services;
        }

        public static IServiceCollection AddLogingBehavior(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LogingBehavior<,>));
            return services;
        }
    }
}
