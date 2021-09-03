using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "统治者")]
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
