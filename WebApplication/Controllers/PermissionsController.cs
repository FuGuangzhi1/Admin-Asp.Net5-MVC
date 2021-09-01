using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 权限
    /// </summary>
    public class PermissionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
