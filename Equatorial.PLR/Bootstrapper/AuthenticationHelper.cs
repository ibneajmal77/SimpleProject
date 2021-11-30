//-----------------------------------------------------------------------
// <copyright file="AuthenticationHelper.cs" client="ManagementSystem">
//     copy right ManagementSystem.
// </copyright>
//-----------------------------------------------------------------------

namespace Equatorial.PLR.Web.BootStrapper
{
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Authentication Helper
    /// </summary>
    public static class AuthenticationHelper
    {
        /// <summary>
        /// Configures the JWT service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="key">The key.</param>
        public static void ConfigureJWTService(this IServiceCollection services, string key)
        {
            services.AddAuthentication(x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             })
             .AddJwtBearer(x =>
             {
                 var keys = Encoding.ASCII.GetBytes(key);
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(keys)
                 };
                 x.Events = new JwtBearerEvents
                 {
                     OnMessageReceived = context =>
                     {
                         var accessToken = context.Request.Query["access_token"];
                         var path = context.HttpContext.Request.Path;
                         if (string.IsNullOrEmpty(accessToken) == false &&
                         (path.StartsWithSegments("/Messaging") || path.StartsWithSegments("/Comments")))
                         {
                             context.Token = accessToken;
                         }

                         return Task.CompletedTask;
                     }
                 };
             });
        }
    }
}
