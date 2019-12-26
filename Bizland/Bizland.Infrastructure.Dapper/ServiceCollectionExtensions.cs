using Bizland.Infrastructure.DBContext;
using Bizland.Infrastructure.Extensions;
using Bizland.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.Dapper
{
    public static class ServiceCollectionExtensions
    {
        private const string SectionName = "Infrastructures:Dapper";
        public static IServiceCollection AddDapperCoreSqlServer(this IServiceCollection services)
        {
            services.AddServiceByIntefaceInCurrentDomain(typeof(IRepositoryAsync<>));
            services.AddServiceByIntefaceInCurrentDomain(typeof(IQueryRepository<>));

            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();

            var options = new DbOptions();
            config.Bind(SectionName, options);
            services.AddSingleton(options);

            if (options.Enabled)
            {
                services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
                services.AddScoped<IUnitOfWork, DapperUnitOfWork>();
            }
            return services;
        }
    }
}
