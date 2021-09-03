using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Authorize(Roles = "统治者,大将")]
    public class UserManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
