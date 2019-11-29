using Bizland.Application.Services.Interfaces;
using Bizland.Application.Services.Services;
using Bizland.Infrastructure.Dapper;
using Bizland.Infrastructure.DBContext;
using Bizland.Infrastructure.EF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IEfUnitOfWork<AppDbContext>, EfUnitOfWork<AppDbContext>>();
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddScoped<IDapperUnitOfWork, DapperUnitOfWork>();

            //services.AddMediatR(Assembly.GetEntryAssembly(), typeof(Startup).Assembly);


            services.AddScoped<IRoomService, RoomService>();
        }
    }
}
