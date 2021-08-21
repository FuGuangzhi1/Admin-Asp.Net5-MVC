using System.Text;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class StudyController : Controller
    {
        public IActionResult FrontEndknowledge()
        {
            return View();
        }

        public IActionResult BackEndknowledge()
        {
            return View();
        }

        public IActionResult Databaseknowledge()
        {
            return View();
        }
    }
}
