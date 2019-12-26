using Bizland.Infrastructure.DBContext;
using Bizland.Infrastructure.Extensions;
using Bizland.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.EF
{
    public static class ServiceCollectionExtensions
    {
        private const string SectionName = "Infrastructures:SqlServer";
        public static IServiceCollection AddEfCoreSqlServer<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            services.AddServiceByIntefaceInCurrentDomain(typeof(IRepositoryAsync<>));
            services.AddServiceByIntefaceInCurrentDomain(typeof(IQueryRepository<>));

            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();

            var options = new DbOptions();
            config.Bind(SectionName, options);
            services.AddSingleton(options);
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            if (options.Enabled)
            {

                services.AddDbContext<TDbContext>((sp, o) =>
                {
                    string connectionString = options.ConnString;
                    o.UseSqlServer(connectionString,
                            sqlOptions =>
                            {
                                sqlOptions.EnableRetryOnFailure(
                                    15,
                                    TimeSpan.FromSeconds(30),
                                    null);
                            })
                        .EnableSensitiveDataLogging();
                });
            }
            else
            {
                services.AddDbContext<TDbContext>((sp, o) =>
                {
                    o.UseInMemoryDatabase("DefaultMainDb");
                });
            }

            services.AddScoped<DbContext>(resolver => resolver.GetService<TDbContext>());

            return services;
        }
    }
}
