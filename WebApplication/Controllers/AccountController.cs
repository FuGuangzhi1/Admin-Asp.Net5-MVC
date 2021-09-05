using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStudyFu.Common;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model;
using StudyMVCFu.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.AOP;

namespace WebApplication.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    /// <summary>
    /// 登录页
    /// </summary>
    public class AccountController : Controller
    {
        private const string V = "操作成功";
        private readonly ILoginDomain _iloginDomain;

        public AccountController(ILoginDomain iloginDomain)
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
            AjaxResult ajaxResult = new() { Success = false, Data = string.Empty, Message = string.Empty };
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
                        base.HttpContext.Session.SetString("Id", isUser.Item2.ToString());

                        var roleList = await _iloginDomain.GetRole(isUser.Item2);
                        var claims = new List<Claim>();
                        foreach (var item in roleList)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, item));
                        }
                        ClaimsPrincipal userPrincipal = new(new ClaimsIdentity(claims, "Customer"));

                        base.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                        }).Wait();

                        //var user = HttpContext.User;
                    }
                    else ajaxResult.Message = "账号或者密码错误";
                }
                else ajaxResult.Message = "验证码错误";
            }
            else ajaxResult.Message = "数据格式不对！！！";
            return Json(data: ajaxResult);
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
        [HttpPost]
        [CustomAllownonymous]
        [ValidateModel]
        public async Task<IActionResult> Create([FromForm] CreateUser createUser)
        {
            if (createUser == null) return default;
            AjaxResult ajaxResult = new();
            if (createUser.Password != createUser.Password1)
            {
                ajaxResult.Message = "两次密码输入不一样";
                return Json(data: ajaxResult);
            };
            var userGuid = Guid.NewGuid();
            User user = new()
            {
                Id = userGuid,
                Birthday = createUser.Birthday,
                CreateDateTime = DateTime.Now,
                Email = createUser.Email,
                Hobby = createUser.Hobby,
                QQ = createUser.QQ,
                Moblie = createUser.Moblie,
                Name = createUser.Name,
                UpdateDateTime = DateTime.Now,
                IsDel = true,
                Sex = createUser.Sex == 1 ? true : false
            };
            UserPassword userPassword = new()
            {
                UserId = userGuid,
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                UserPasswordId = Guid.NewGuid(),
                NewPassword = createUser.Password.ToMD5()
            };
            ajaxResult = await _iloginDomain.CeateUser(user, userPassword);
            return Json(data: ajaxResult);
        }
    }
}
