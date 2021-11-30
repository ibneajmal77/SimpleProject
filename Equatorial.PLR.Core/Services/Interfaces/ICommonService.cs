using Equatorial.PLR.Domain.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatorial.PLR.Core.Services.Interfaces
{
    public interface ICommonService
    {
        Task<List<TypeHierarchyResponse>> GetAllHierarchyTypesAsync(string id);
        Task<List<ClassificationOfficeResponse>> GetAllClassificationOfficesAsync(string id);
        Task<List<TypeRankingResponse>> GetAllRankingTypesAsync(int? id);
        Task<List<ProfileAccessResponse>> GetAllProfileAccessesAsync(int? id);
        Task<List<CompanyResponse>> GetAllCompaniesAsync(int? id);
        Task<List<QuizResponse>> GetAllQuizesAsync(int? id);
        Task<List<MenuResponse>> GetAllMenuesAsync(string area, string role);
    }
}
