using Equatorial.PLR.Core.Services.Interfaces;
using Equatorial.PLR.Domain.Enum;
using Equatorial.PLR.Domain.Model.Response;
using Equatorial.PLR.Infrastructure.Extensions;
using Equatorial.PLR.Web.BootStrapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equatorial.PLR.Web.Controllers
{
    /// </summary>
    [Route("api/v1")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService commonService;

        public CommonController(
            ICommonService _commonService)
        {
            this.commonService = _commonService;
        }

        [HttpGet]
        [Route("tipos-hierarquia")]
        public async Task<IActionResult> GetAllHierarchyTypesAsync(string id)
        {
            try
            {
                var hierachyTypes = await this.commonService.GetAllHierarchyTypesAsync(id);
                if (hierachyTypes.IsAny())
                {
                    return this.Result<List<TypeHierarchyResponse>>(ResponseStatus.Status200OK, true, hierachyTypes.Count, hierachyTypes, Constants.HierarchyTypesData);
                }

                return this.Result(ResponseStatus.Status200OK, false, 0);
            }
            catch (Exception ex)
            {
                return this.Result(ResponseStatus.Status500InternalServerError, false, 0, null, ex.ToString());
            }
        }

        [HttpGet]
        [Route("classificacoes-cargo")]
        public async Task<IActionResult> GetAllClassificationOfficesAsync(string id)
        {
            try
            {
                var classificationOffices = await this.commonService.GetAllClassificationOfficesAsync(id);
                if (classificationOffices.IsAny())
                {
                    return this.Result<List<ClassificationOfficeResponse>>(ResponseStatus.Status200OK, true, classificationOffices.Count, classificationOffices, Constants.ClassificationOfficesData);
                }

                return this.Result(ResponseStatus.Status200OK, false, 0);
            }
            catch (Exception ex)
            {
                return this.Result(ResponseStatus.Status500InternalServerError, false, 0, null, ex.ToString());
            }
        }

        [HttpGet]
        [Route("tipos-ranking")]
        public async Task<IActionResult> GetAllRankingTypesAsync(int? id)
        {
            try
            {
                var typeRankings = await this.commonService.GetAllRankingTypesAsync(id);
                if (typeRankings.IsAny())
                {
                    return this.Result<List<TypeRankingResponse>>(ResponseStatus.Status200OK, true, typeRankings.Count, typeRankings, Constants.ClassificationOfficesData);
                }

                return this.Result(ResponseStatus.Status200OK, false, 0);
            }
            catch (Exception ex)
            {
                return this.Result(ResponseStatus.Status500InternalServerError, false, 0, null, ex.ToString());
            }
        }

        [HttpGet]
        [Route("perfis-acesso")]
        public async Task<IActionResult> GetAllProfileAccessesAsync(int? id)
        {
            try
            {
                var profileAccesses = await this.commonService.GetAllProfileAccessesAsync(id);
                if (profileAccesses.IsAny())
                {
                    return this.Result<List<ProfileAccessResponse>>(ResponseStatus.Status200OK, true, profileAccesses.Count, profileAccesses, Constants.ProfileAccessesData);
                }

                return this.Result(ResponseStatus.Status200OK, false, 0);
            }
            catch (Exception ex)
            {
                return this.Result(ResponseStatus.Status500InternalServerError, false, 0, null, ex.ToString());
            }
        }

        [HttpGet]
        [Route("empresas")]
        public async Task<IActionResult> GetAllCompaniesAsync(int? id)
        {
            try
            {
                var companies = await this.commonService.GetAllCompaniesAsync(id);
                if (companies.IsAny())
                {
                    return this.Result<List<CompanyResponse>>(ResponseStatus.Status200OK, true, companies.Count, companies, Constants.CompaniesData);
                }

                return this.Result(ResponseStatus.Status200OK, false, 0);
            }
            catch (Exception ex)
            {
                return this.Result(ResponseStatus.Status500InternalServerError, false, 0, null, ex.ToString());
            }
        }

        [HttpGet]
        [Route("questionario")]
        public async Task<IActionResult> GetAllQuizesAsync(int? id)
        {
            try
            {
                var quizes = await this.commonService.GetAllQuizesAsync(id);
                if (quizes.IsAny())
                {
                    return this.Result<List<QuizResponse>>(ResponseStatus.Status200OK, true, quizes.Count, quizes, Constants.QuizesData);
                }

                return this.Result(ResponseStatus.Status200OK, false, 0);
            }
            catch (Exception ex)
            {
                return this.Result(ResponseStatus.Status500InternalServerError, false, 0, null, ex.ToString());
            }
        }

        [HttpGet]
        [Route("menu")]
        public async Task<IActionResult> GetAllMenuesAsync()
        {
            try
            {
                var role = string.Empty;
                var allMenuItems = new MenuListResponse();
                allMenuItems.pge = new List<MenuResponse>();
                allMenuItems.ppme = new List<MenuResponse>();
                allMenuItems.admin = new List<MenuResponse>();
                allMenuItems.banners = new List<MenuResponse>();
                var pgeMenus = await this.commonService.GetAllMenuesAsync(Constants.PgeMenu, role);
                if (pgeMenus.IsAny())
                {
                    allMenuItems.pge.AddRange(pgeMenus);
                }

                var ppmeMenus = await this.commonService.GetAllMenuesAsync(Constants.PpmeMenu, role);
                if (ppmeMenus.IsAny())
                {
                    allMenuItems.ppme.AddRange(ppmeMenus);
                }

                var adminMenu = await this.commonService.GetAllMenuesAsync(Constants.AdminMenu, role);
                if (adminMenu.IsAny())
                {
                    allMenuItems.admin.AddRange(adminMenu);
                }

                var bannerMenus = await this.commonService.GetAllMenuesAsync(Constants.BannerMenu, role);
                if (bannerMenus.IsAny())
                {
                    allMenuItems.banners.AddRange(bannerMenus);
                }

                if (allMenuItems.admin.IsAny() || allMenuItems.banners.IsAny() || allMenuItems.pge.IsAny() || allMenuItems.ppme.IsAny())
                {
                    return this.Result<MenuListResponse>(ResponseStatus.Status200OK, true, allMenuItems.admin.Count + allMenuItems.banners.Count + allMenuItems.pge.Count + allMenuItems.ppme.Count, allMenuItems, Constants.MenusData);
                }

                return this.Result(ResponseStatus.Status200OK, false, 0);
            }
            catch (Exception ex)
            {
                return this.Result(ResponseStatus.Status500InternalServerError, false, 0, null, ex.ToString());
            }
        }

        //[HttpGet]
        //[Route("questionario")]
        //public async Task<IActionResult> GetAllQuizesAsync(int? id)
        //{
        //    try
        //    {
        //        var quizes = await this.commonService.GetAllQuizesAsync(id);
        //        if (quizes.IsAny())
        //        {
        //            return this.Result<List<QuizResponse>>(ResponseStatus.Status200OK, true, quizes.Count, quizes, Constants.QuizesData);
        //        }

        //        return this.Result(ResponseStatus.Status200OK, false, 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.Result(ResponseStatus.Status500InternalServerError, false, 0, null, ex.ToString());
        //    }
        //}
    }
}
