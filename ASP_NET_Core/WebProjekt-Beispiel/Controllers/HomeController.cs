using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebProjekt_Beispiel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Games()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }
    }
}
