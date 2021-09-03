using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 特殊处理
    /// </summary>
    public class SpecialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
