using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class JournalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
