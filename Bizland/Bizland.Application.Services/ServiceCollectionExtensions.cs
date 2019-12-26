using Bizland.Application.Services.AutoMapper;
using Bizland.Application.Services.Interfaces;
using Bizland.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Application.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddServiceByIntefaceInCurrentDomain(typeof(IRoomService));
            services.AddAutoMapperSetup();
            return services;
        }
    }
}
