//-----------------------------------------------------------------------
// <copyright file="CorsHelper.cs" client="ManagementSystem">
//     ManagementSystem copy right.
// </copyright>
//-----------------------------------------------------------------------

namespace Equatorial.PLR.Web.BootStrapper
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The cross origin Helper
    /// </summary>
    public static class CorsHelper
    {
        /// <summary>
        /// Configures the cross origin service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureCorsService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(o =>
                   o.AddPolicy(
                       "CorsPolicy",
                       builder =>
                               {
                                   builder.WithOrigins(configuration["WebApplication:AllowOrigions"].Split(';'))
                                       .AllowAnyMethod()
                                       .AllowAnyHeader()
                                       .AllowCredentials();
                               }));
        }
    }
}
