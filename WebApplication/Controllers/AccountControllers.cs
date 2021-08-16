using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Common;
using MvcStudyFu.Common.Enum;
using MvcStudyFu.EFCore.SQLSever.DomainModel;
using MvcStudyFu.Interface;
using MvcStudyFu.Interface.DomainInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Utility;

namespace WebApplication.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class AccountControllers : Controller
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly ILoginDomain _iloginDomain;

        public AccountControllers(IDbContextFactory dbContextFactory,ILoginDomain iloginDomain)
        {
            this._dbContextFactory = dbContextFactory;
            this._iloginDomain = iloginDomain;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] Login login)
        {
            using var dbcontex = _dbContextFactory.CreateDbContext(ReadWriteEnum.Read);
            string stringResult = string.Empty;
            string checkCode = HttpContext.Session.GetString("CaptchaCode");
            if (ModelState.IsValid)
            {
                if (login.CheckCode.Equals(checkCode, StringComparison.InvariantCultureIgnoreCase))
                {
                  (bool,Guid?) isUser= await _iloginDomain.GetUserasync(login.Name,login.Password);
                    if (isUser.Item1)
                    {
                        stringResult = "OK";
                        HttpContext.Session.SetString("Id", isUser.Item2.ToString());
                    }
                    else stringResult = "账号或者密码错误";
                }
                else stringResult = "验证码错误";
            }
            else stringResult = "数据格式不对！！！";
            ActionResult result = Content(stringResult);
            return result;
        }
        [HttpGet]
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
        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
