using LinqToDB.Linq.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        [Obsolete]
        private readonly IHostingEnvironment _env;
        [Obsolete]
        public PersonalInfoController(IPersonalInfo personalInfo, IHostingEnvironment env)
        {
            this._personalInfo = personalInfo;
            this._env = env;
        }

        public IActionResult Index() => View();

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
            return Json(data: ajaxResult);
        }
        [HttpPost]
        [Obsolete]
        public async Task SingleFile(IFormFile file)
        {
            //.. / images / 小新.jpg 格式模板
            var dir = _env.ContentRootPath;
            using (var filestream = new FileStream(Path.Combine(dir,@"wwwroot\\images", file.FileName), FileMode.Create, FileAccess.Write))
            {
               await file.CopyToAsync(filestream);
            }
            //保存或编辑图片  未完善
        }
    }
}
