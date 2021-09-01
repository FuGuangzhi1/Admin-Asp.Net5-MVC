using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcStudyFu.Interface.DomainInterface;
using MvcStudyFu.Services.DomainServices;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IHomePage _homePage;

        public HomePageController(IHomePage homePage)
        {
            this._homePage = homePage;
        }
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetmenuList()
        {
            AjaxResult ajaxResult = new AjaxResult();
            ajaxResult.Data = await _homePage.GetmenuList();
            if (ajaxResult.Data != null)
            {
                ajaxResult.Message = "操作成功"; ajaxResult.Success = true;
            }
            return Json(data: ajaxResult);
        }


    }
}
