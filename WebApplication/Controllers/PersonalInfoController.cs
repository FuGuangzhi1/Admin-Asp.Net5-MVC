using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 个人信息
    /// </summary>
    public class PersonalInfoController : Controller
    {
        private readonly IPersonalInfo _personalInfo;

        public PersonalInfoController(IPersonalInfo personalInfo)
        {
            this._personalInfo = personalInfo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPersonalInfo()
        {
            AjaxResult ajaxResult = new AjaxResult();
            string id = base.HttpContext.Session.GetString("Id");
            ajaxResult.Data = await _personalInfo.FindIdUser(id);
            if (ajaxResult.Data != null)
            {
                ajaxResult.Success = true;
                ajaxResult.Message = "操作成功";
            }
            return Json(data:ajaxResult);
        }
    }
}
