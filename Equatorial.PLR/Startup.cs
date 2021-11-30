using Equatorial.PLR.Domain.Entities;
using Equatorial.PLR.Infrastructure;
using Equatorial.PLR.Infrastructure.Repository.UnitOfWork;
using Equatorial.PLR.Web.BootStrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equatorial.PLR
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
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.ConfigureSwaggerService("Equatorial.PLR");
            services.ConfigureCorsService(this.Configuration);

            // Replace with your connection string.
            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql");
            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<mydbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(Configuration.GetConnectionString("DefaultConnection"), serverVersion)
                    // The following three options help with debugging, but should
                    // be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(c => c.AddProfile<AutoMapperConfiguration>(), typeof(Startup));
            services.ConfigureServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Equatorial.PLR");
                //c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
