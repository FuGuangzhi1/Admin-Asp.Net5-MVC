using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStudyFu.Interface.DomainInterface;
using MvcStudyFu.Services.DomainServices;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 主页面
    /// </summary>
    public class HomePageController : Controller
    {
        private readonly IHomePage _homePage;

        public HomePageController(IHomePage homePage)
        {
            this._homePage = homePage;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetmenuList()
        {
            AjaxResult ajaxResult = new AjaxResult();
            string id = base.HttpContext.Session.GetString("Id");
            if (id == null) base.HttpContext.Response.Redirect("/Account/login");
            ajaxResult.Data = await _homePage.GetmenuListAsync(id);
            if (ajaxResult.Data != null)
            {
                ajaxResult.Message = "操作成功"; ajaxResult.Success = true;
            }
            return Json(data: ajaxResult);
        }


    }
}
