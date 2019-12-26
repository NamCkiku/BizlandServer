using Bizland.Infrastructure.CrossCutting.IoC;
using Bizland.Infrastructure.EF;
using Bizland.Room.Api.Data;
using GlobalExceptionHandler.WebApi;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Bizland.Room.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var resolver = services.BuildServiceProvider();
            using (var scope = resolver.CreateScope())
            {
                services.AddEfCoreSqlServer<RoomDataContext>();
                services.AddScoped<RoomDataContext>();
            }
            services.AddMediatR(typeof(Startup));
            services.RegisterServices();
            services.AddHealthChecks().AddSqlServer(connectionString: Configuration["ConnectionStrings:MainDb"]);
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseGlobalExceptionHandler(cfg => cfg.MapExceptions());
            app.UseGlobalExceptionHandler(x =>
            {
                x.ContentType = "application/json";
                x.ResponseBody(s => JsonConvert.SerializeObject(new
                {
                    Message = "An error occurred whilst processing your request"
                }));
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}