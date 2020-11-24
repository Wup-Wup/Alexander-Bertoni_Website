using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjekt_Beispiel.Models;

namespace WebProjekt_Beispiel.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Merch()
        {
            return View(CreateArticleList());
        }

        public IActionResult CreateArticle()
        {
            return View();
        }
        

        private List<Merch> CreateArticleList()
        {
            return new List<Merch>()
            {
                new Merch(1, "Kairi Plush", 50.45m, null, Category.Plush),
                new Merch(1, "Sora Statue", 250m, new DateTime(2021, 5, 20), Category.Statue),
                new Merch(3, "Chibi Riku", 20m, null, Category.Figure),
                new Merch(4, "Xion Plush", 99.99m, new DateTime(2020, 12, 10), Category.Plush)
            };
        }
    }
}
