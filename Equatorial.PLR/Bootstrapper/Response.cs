
namespace Equatorial.PLR.Web.Bootstrapper
{
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Equatorial.PLR.Domain.Enum;

    /// <summary>
    /// The response class
    /// </summary>
    /// <typeparam name="T">The entity</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ActionResult" />
    public class Response<T> : ActionResult
    {
        /// <summary>
        /// The content result
        /// </summary>
        private readonly ContentResult contentResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        public Response()
        {
            this.contentResult = new ContentResult();
        }

        public int Status { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// <list type="ResponseStatus">
        /// <item>OK</item>
        /// <item>Info</item>
        /// <item>Error</item>
        /// <item>Warning</item>
        /// <item>LimitExceeded</item>
        /// <item>Forbidden</item>
        /// <item>Unauthorized</item>
        /// </list>
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Result { get; set; }

        /// <summary>
        /// Executes the result operation of the action method asynchronously. This method is called by MVC to process
        /// the result of an action method.
        /// The default implementation of this method calls the <see cref="M:Microsoft.AspNetCore.Mvc.ActionResult.ExecuteResult(Microsoft.AspNetCore.Mvc.ActionContext)" /> method and
        /// returns a completed task.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes
        /// information about the action that was executed and request information.</param>
        /// <returns>The task</returns>
        public async override Task ExecuteResultAsync(ActionContext context)
        {
            this.contentResult.StatusCode = this.Status;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if (this.Status != ResponseStatus.Status204NoContent)
            {
                StringBuilder sb = new StringBuilder(JsonConvert.SerializeObject(this));
                //// sb.Replace("}", "");
                //// sb.Insert(sb.Length, ",");
                //// sb.Append($"\"data\":{JsonConvert.SerializeObject(this.Data)}}}");

                this.contentResult.Content = sb.ToString();

                this.contentResult.ContentType = "application/json";
            }

            await this.contentResult.ExecuteResultAsync(context);
        }
    }
}
