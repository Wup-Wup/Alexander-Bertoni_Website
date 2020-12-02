using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjekt_Beispiel.Models;

namespace WebProjekt_Beispiel.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LogIn(User newUser)
        {
            if (newUser == null)
            {
                return RedirectToAction("Log Into your Account");
            }

            ValidateUserInfo(newUser);

            if (ModelState.IsValid)
            {
                return RedirectToAction("index", "home");
            }
            return View(newUser);
        }

        [HttpGet]

        public IActionResult SignUp()
        {
            return View(new User());
        }

        public IActionResult SignUp(User newUser)
        {
            if (newUser == null)
            {
                return RedirectToAction("createNewAccount");
            }

            ValidateUserInfo(newUser);

            if (ModelState.IsValid)
            {
                return RedirectToAction("index", "home");
            }
            return View(newUser);
        }

        private void ValidateUserInfo(User a)
        {
            if (a == null)
            {
                return;
            }

        }

    }
}
