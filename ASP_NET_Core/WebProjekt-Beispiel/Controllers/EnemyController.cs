using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebProjekt_Beispiel.Controllers
{
    public class EnemyController : Controller
    {

        public IActionResult Heartless()
        {
            return View();
        }

        public IActionResult Nobodies()
        {
            return View();
        }

        public IActionResult Unversed()
        {
            return View();
        }

        public IActionResult DreamEater()
        {
            return View();
        }
    }
}
