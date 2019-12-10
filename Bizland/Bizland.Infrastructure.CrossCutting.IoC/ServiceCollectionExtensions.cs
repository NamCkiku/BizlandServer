using Bizland.Infrastructure.Dapper;
using Bizland.Infrastructure.EF;
using Bizland.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Infrastructure.CrossCutting.IoC
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

        private const string SectionName = "Infrastructures:SqlServer";
        public static IServiceCollection AddEfCoreSqlServer<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            //services.AddServiceByIntefaceInCurrentDomain(typeof(IRepositoryAsync<>));
            //services.AddServiceByIntefaceInCurrentDomain(typeof(IQueryRepository<>));
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddScoped<IDapperUnitOfWork, DapperUnitOfWork>();
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();

            var options = new DapperDbOptions();
            config.Bind(SectionName, options);
            services.AddSingleton(options);

            if (options.Enabled)
            {
                services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
                services.AddDbContext<TDbContext>((sp, o) =>
                {
                    string connectionString = options.Database;
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
                //services.AddScoped<IUnitOfWork, typeof(EfUnitOfWork <>)> ();

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
