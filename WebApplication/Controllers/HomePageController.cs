using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Utility;

namespace WebApplication.Controllers
{
    public class HomePageController : Controller
    {
        //[Authorize]
        [ActionLoginFilter(true)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
