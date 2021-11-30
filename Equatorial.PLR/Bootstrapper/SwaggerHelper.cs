//-----------------------------------------------------------------------
// <copyright file="SwaggerHelper.cs" client="ManagementSystem">
//     copy right ManagementSystem.
// </copyright>
//-----------------------------------------------------------------------

namespace Equatorial.PLR.Web.BootStrapper
{
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Swagger Helper
    /// </summary>
    public static class SwaggerHelper
    {
        /// <summary>
        /// Configure of Swagger Service
        /// </summary>
        /// <param name="service">API services</param>
        public static void ConfigureSwaggerService(this IServiceCollection service, string apiName)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio
            // Register the Swagger generator, defining 1 or more Swagger documents
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = apiName, Version = "v1", Description = "Management System" });
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme. 
                                        Enter 'Bearer' [space] and then your token in the text input below.
                                        Example: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                  {
                    new OpenApiSecurityScheme
                    {
                      Reference = new OpenApiReference
                        {
                          Type = ReferenceType.SecurityScheme,
                          Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                      },
                      new List<string>()
                    }
                  });
            });
        }
    }
}
