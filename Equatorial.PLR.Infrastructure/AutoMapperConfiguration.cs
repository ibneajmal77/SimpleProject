//-----------------------------------------------------------------------
// <copyright file="AutoMapperConfiguration.cs" client="ManagementSystem">
//     copy right ManagementSystem.
// </copyright>
//-----------------------------------------------------------------------

namespace Equatorial.PLR.Infrastructure
{
    using AutoMapper;
    using Equatorial.PLR.Domain.Entities;
    using Equatorial.PLR.Domain.Model.Request;
    using Equatorial.PLR.Domain.Model.Request.Create;
    using Equatorial.PLR.Domain.Model.Request.Update;
    using Equatorial.PLR.Domain.Model.Response;
    using System.Linq;

    /// <summary>
    /// Auto Mapper Configuration
    /// </summary>
    public class AutoMapperConfiguration : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperConfiguration"/> class.
        /// </summary>
        public AutoMapperConfiguration()
        {
            var entityAssemplyEntity = typeof(Parameter).Assembly;
            var entityAssemplyRequest = typeof(ParameterRequest).Assembly.ExportedTypes.ToList();
            var entityAssemplyCreateRequest = typeof(ParameterCreateRequest).Assembly.ExportedTypes.ToList();
            var entityAssemplyUpdateRequest = typeof(ParameterUpdateRequest).Assembly.ExportedTypes.ToList();
            var entityAssemplyResponse = typeof(ParameterResponse).Assembly.ExportedTypes.ToList();

            entityAssemplyEntity.ExportedTypes.ToList().ForEach(s =>
            {
                var formattedRequestModelName = string.Format("{0}Request", s.Name);
                var requestModelName = entityAssemplyRequest.FirstOrDefault(s => s.Name == formattedRequestModelName);
                if (requestModelName != null)
                {
                    this.CreateMap(s, requestModelName).ReverseMap();
                }

                var formattedCreateRequestModelName = string.Format("{0}CreateRequest", s.Name);
                var createRequestModelName = entityAssemplyCreateRequest.FirstOrDefault(s => s.Name == formattedCreateRequestModelName);
                if (createRequestModelName != null)
                {
                    this.CreateMap(s, createRequestModelName).ReverseMap();
                }

                var formattedUpdateRequestName = string.Format("{0}UpdateRequest", s.Name);
                var updateRequestModelName = entityAssemplyUpdateRequest.FirstOrDefault(s => s.Name == formattedUpdateRequestName);
                if (updateRequestModelName != null)
                {
                    this.CreateMap(s, updateRequestModelName).ReverseMap();
                }

                var formattedResponseName = string.Format("{0}Response", s.Name);
                var responseModelName = entityAssemplyUpdateRequest.FirstOrDefault(s => s.Name == formattedResponseName);
                if (responseModelName != null)
                {
                    this.CreateMap(s, responseModelName).ReverseMap();
                }
            });
        }
    }
}
