using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Common;
using MvcStudyFu.Interface;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class AccountControllers : Controller
    {
        private const string V = "操作成功";
        private readonly ILoginDomain _iloginDomain;

        public AccountControllers(ILoginDomain iloginDomain)
        {
            this._iloginDomain = iloginDomain;
        }
        [HttpGet]
        [CustomAllownonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [CustomAllownonymous]
        public async Task<ActionResult> Login([FromBody] Login login)
        {
            AjaxResult ajaxResult=new() {  Success=false,Data=string.Empty,Message=string.Empty};
            string checkCode = HttpContext.Session.GetString("CaptchaCode");
            if (ModelState.IsValid)
            {
                if (login.CheckCode.Equals(checkCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    //账号密码判断用户
                    (bool, Guid?) isUser = await _iloginDomain.GetUserasync(login.Name, login.Password);
                    if (isUser.Item1)
                    {
                        ajaxResult.Success = true;
                        ajaxResult.Message = V;
                        HttpContext.Session.SetString("Id", isUser.Item2.ToString());
                    }
                    else ajaxResult.Message = "账号或者密码错误";
                }
                else ajaxResult.Message = "验证码错误";
            }
            else ajaxResult.Message = "数据格式不对！！！";
            return Json(data:ajaxResult);
        }
        [HttpGet]
        [CustomAllownonymous]
        public IActionResult GetCaptchaImage()
        {
            int width = 140;
            int height = 40;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString("CaptchaCode", result.CaptchaCode);
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }
        [HttpGet]
        [CustomAllownonymous]
        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
