using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetPersonalInfo()
        {
            string id =base.HttpContext.Session.GetString("Id");
            return View();
        }
    }
}
