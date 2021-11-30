namespace Equatorial.PLR.Web.BootStrapper
{
    using System.Linq;
    using System.Security.Claims;
    using Equatorial.PLR.Infrastructure.Extensions;
    using Equatorial.PLR.Web.Bootstrapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// The API Controller Extensions
    /// </summary>
    public static class ApiControllerExtensions
    {
        /// <summary>
        /// Results the specified status.
        /// </summary>
        /// <typeparam name="T">Any entity model data</typeparam>
        /// <param name="controller">The controller.</param>
        /// <param name="status">The status.</param>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        /// <returns>The action result</returns>
        public static ActionResult Result<T>(this ControllerBase controller, int status, bool success, int total, T result = default, string message = null)
        {
            return new Response<T>()
            {
                Status = status,
                Message = message,
                Result = result,
                Success = success,
                Total = total
            };
        }

        /// <summary>
        /// Results the specified status.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="status">The status.</param>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        /// <returns>The action result</returns>
        public static ActionResult Result(this ControllerBase controller, int status, bool success, int total, object result = null, string message = null)
        {
            return new Response<object>()
            {
                Status = status,
                Message = message,
                Result = result,
                Success = success,
                Total = total
            };
        }

        /// <summary>
        /// Gets the logged in user identifier.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <returns>Returns the Logged In User Id</returns>
        public static string GetLoggedInUserId(this ControllerBase controller, IHttpContextAccessor httpContextAccessor)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirstValue("UserId");
            return userId;
        }

        public static string GetLoggedInUserRole(this ControllerBase controller, IHttpContextAccessor httpContextAccessor)
        {
            var userRole = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            return userRole;
        }

        /// <summary>
        /// Gets the model validation errors.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="keyValuePairs">The key value pairs.</param>
        /// <returns>return error list</returns>
        public static string GetModelValidationErrors(this ControllerBase controller, ModelStateDictionary keyValuePairs)
        {
            var errors = keyValuePairs.Values.Select(x => x.Errors.FirstOrDefault().ErrorMessage);
            errors = errors.Distinct().ToList();
            var error = string.Join(",", errors.ToArray());
            return error;
        }

        /// <summary>
        /// Gets the identity response errors.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="identityResult">The identity result.</param>
        /// <returns>the identity response errors</returns>
        public static string GetIdentityResponseErrors(this ControllerBase controller, IdentityResult identityResult)
        {
            var distinctErrors = identityResult.Errors.DistinctBy(x => x.Code)?.ToList();
            var errors = distinctErrors.Select(x => x.Description);
            var error = string.Join(",", errors.ToArray());
            return error;
        }
    }
}
