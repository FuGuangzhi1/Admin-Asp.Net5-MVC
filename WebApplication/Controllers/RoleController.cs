using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
