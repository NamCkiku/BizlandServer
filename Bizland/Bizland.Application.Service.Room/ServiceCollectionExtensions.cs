using Bizland.Application.Service.Room.AutoMapper;
using Bizland.Application.Service.Room.Interfaces;
using Bizland.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Application.Service.Room
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesRoom(this IServiceCollection services)
        {
            services.AddServiceByIntefaceInCurrentDomain(typeof(IRoomService));
            services.AddAutoMapperSetup();
            return services;
        }
    }
}
