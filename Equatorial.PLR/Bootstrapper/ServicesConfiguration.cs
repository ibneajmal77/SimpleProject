//-----------------------------------------------------------------------
// <copyright file="ServicesConfiguration.cs" client="ManagementSystem">
//     copy right ManagementSystem.
// </copyright>
//-----------------------------------------------------------------------

namespace Equatorial.PLR.Web.BootStrapper
{
    using System.Linq;
    using System.Reflection;
    using Equatorial.PLR.Core.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using NetCore.AutoRegisterDi;

    /// <summary>
    /// Services Configuration
    /// </summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services">The services</param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            var assembliesToScan = Assembly.GetAssembly(typeof(ICommonService));
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
              .Where(c => c.Name.EndsWith("Service"))
              .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
        }
    }
}
