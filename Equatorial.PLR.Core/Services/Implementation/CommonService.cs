using AutoMapper;
using Equatorial.PLR.Core.Services.Interfaces;
using Equatorial.PLR.Domain.Entities;
using Equatorial.PLR.Domain.Model.Request;
using Equatorial.PLR.Domain.Model.Response;
using Equatorial.PLR.Infrastructure.Extensions;
using Equatorial.PLR.Infrastructure.Repository.UnitOfWork;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatorial.PLR.Core.Services.Implementation
{
    public class CommonService : ICommonService
    {
        /// <summary>
        /// Mapper Declaration
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Unit of work Declaration
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Config declare
        /// </summary>
        private readonly IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="config">The configuration.</param>
        public CommonService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.config = config;
        }

        public async Task<List<TypeHierarchyResponse>> GetAllHierarchyTypesAsync(string id)
        {
            var typeHierarchies = new List<TypeHierarchy>();
            var typeHierarchyResponse = new List<TypeHierarchyResponse>();
            if (!string.IsNullOrEmpty(id))
            {
                typeHierarchies = await this.unitOfWork.Repository<TypeHierarchy>().FindAllAsync(x => x.Id == id);
                if (typeHierarchies.IsAny())
                {
                    typeHierarchyResponse = this.mapper.Map<List<TypeHierarchyResponse>>(typeHierarchies)?.OrderBy(x => x.Sequence)?.ToList();
                }
            }
            else
            {
                typeHierarchies = await this.unitOfWork.Repository<TypeHierarchy>().GetAllAsync();
                if (typeHierarchies.IsAny())
                {
                    typeHierarchyResponse = this.mapper.Map<List<TypeHierarchyResponse>>(typeHierarchies);
                }
            }

            return typeHierarchyResponse;
        }

        public async Task<List<ClassificationOfficeResponse>> GetAllClassificationOfficesAsync(string id)
        {
            var classificationOffices = new List<ClassificationOffice>();
            var classificationOfficeResponses = new List<ClassificationOfficeResponse>();
            if (!string.IsNullOrEmpty(id))
            {
                classificationOffices = await this.unitOfWork.Repository<ClassificationOffice>().FindAllAsync(x => x.Id == id);
                if (classificationOffices.IsAny())
                {
                    classificationOfficeResponses = this.mapper.Map<List<ClassificationOfficeResponse>>(classificationOffices)?.OrderBy(x => x.Sequence)?.ToList();
                }
            }
            else
            {
                classificationOffices = await this.unitOfWork.Repository<ClassificationOffice>().GetAllAsync();
                if (classificationOffices.IsAny())
                {
                    classificationOfficeResponses = this.mapper.Map<List<ClassificationOfficeResponse>>(classificationOffices);
                }
            }

            return classificationOfficeResponses;
        }

        public async Task<List<TypeRankingResponse>> GetAllRankingTypesAsync(int? id)
        {
            var typeRankings = new List<TypeRanking>();
            var typeRankingResponses = new List<TypeRankingResponse>();
            if (id != null)
            {
                typeRankings = await this.unitOfWork.Repository<TypeRanking>().FindAllAsync(x => x.Id == id);
                if (typeRankings.IsAny())
                {
                    typeRankingResponses = this.mapper.Map<List<TypeRankingResponse>>(typeRankings)?.OrderBy(x => x.Sequence)?.ToList();
                }
            }
            else
            {
                typeRankings = await this.unitOfWork.Repository<TypeRanking>().GetAllAsync();
                if (typeRankings.IsAny())
                {
                    typeRankingResponses = this.mapper.Map<List<TypeRankingResponse>>(typeRankings);
                }
            }

            return typeRankingResponses;
        }

        public async Task<List<ProfileAccessResponse>> GetAllProfileAccessesAsync(int? id)
        {
            var profileAccess = new List<ProfileAccess>();
            var profileAccessResponses = new List<ProfileAccessResponse>();
            if (id != null)
            {
                profileAccess = await this.unitOfWork.Repository<ProfileAccess>().FindAllAsync(x => x.Id == id);
                if (profileAccess.IsAny())
                {
                    profileAccessResponses = this.mapper.Map<List<ProfileAccessResponse>>(profileAccess)?.OrderBy(x => x.Title)?.ToList();
                }
            }
            else
            {
                profileAccess = await this.unitOfWork.Repository<ProfileAccess>().GetAllAsync();
                if (profileAccess.IsAny())
                {
                    profileAccessResponses = this.mapper.Map<List<ProfileAccessResponse>>(profileAccess);
                }
            }

            return profileAccessResponses;
        }

        public async Task<List<CompanyResponse>> GetAllCompaniesAsync(int? id)
        {
            var company = new List<Company>();
            var companyResponse = new List<CompanyResponse>();
            if (id != null)
            {
                company = await this.unitOfWork.Repository<Company>().FindAllAsync(x => x.Id == id);
                if (company.IsAny())
                {
                    companyResponse = this.mapper.Map<List<CompanyResponse>>(company)?.OrderBy(x => x.Code)?.ToList();
                }
            }
            else
            {
                company = await this.unitOfWork.Repository<Company>().GetAllAsync();
                if (company.IsAny())
                {
                    companyResponse = this.mapper.Map<List<CompanyResponse>>(company);
                }
            }

            return companyResponse;
        }

        public async Task<List<QuizResponse>> GetAllQuizesAsync(int? id)
        {
            var quiz = new List<Quiz>();
            var quizResponse = new List<QuizResponse>();
            if (id != null)
            {
                quiz = await this.unitOfWork.Repository<Quiz>().FindAllAsync(x => x.Id == id);
                if (quiz.IsAny())
                {
                    quizResponse = this.mapper.Map<List<QuizResponse>>(quiz)?.OrderBy(x => x.Sequence)?.ToList();
                }
            }
            else
            {
                quiz = await this.unitOfWork.Repository<Quiz>().GetAllAsync();
                if (quiz.IsAny())
                {
                    quizResponse = this.mapper.Map<List<QuizResponse>>(quiz);
                }
            }

            return quizResponse;
        }

        public async Task<List<MenuResponse>> GetAllMenuesAsync(string area, string role)
        {
            var menu = new List<Menu>();
            var menuResponse = new List<MenuResponse>();
            if (!string.IsNullOrEmpty(area) && !string.IsNullOrEmpty(role))
            {
                menu = await this.unitOfWork.Repository<Menu>().FindAllAsync(x => x.Area == area && x.Permission.Contains(role));
                if (menu.IsAny())
                {
                    menuResponse = this.mapper.Map<List<MenuResponse>>(menu)?.OrderBy(x => x.Sequence)?.ToList();
                }
            }

            return menuResponse;
        }

        //public async Task<List<ParameterResponse>> GetAllParametersAsync(ParameterRequest parameterRequest)
        //{
        //    var quiz = new List<Parameter>();
        //    var quizResponse = await this.unitOfWork.Repository<Parameter>().FindAllAsync(x => 
        //    (!string.IsNullOrEmpty(parameterRequest.Description) && x.Description.Contains(parameterRequest.Description)) ||
        //    (!string.IsNullOrEmpty(parameterRequest.Id) && x.Description.Contains(parameterRequest.Description)) ||
        //    (!string.IsNullOrEmpty(parameterRequest.Key) && x.Description.Contains(parameterRequest.Description)) ||
        //    (!string.IsNullOrEmpty(parameterRequest.TypeField) && x.Description.Contains(parameterRequest.Description)) ||
        //    (!string.IsNullOrEmpty(parameterRequest.Value) && x.Description.Contains(parameterRequest.Description)) ||
        //    (!string.IsNullOrEmpty(parameterRequest.ValueSensitive) && x.Description.Contains(parameterRequest.Description)) ||

        //    x.Id == id);
        //    if (quiz.IsAny())
        //    {
        //        quizResponse = this.mapper.Map<List<ParameterResponse>>(quiz)?.OrderBy(x => x.Sequence)?.ToList();
        //    }

        //    return quizResponse;
        //}
    }
}
