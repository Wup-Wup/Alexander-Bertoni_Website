using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjekt_Beispiel.Models;
using WebProjekt_Beispiel.Models.database;
using System.Data.Common;
using WebProjekt_Beispiel.Models.database.sricpts;

namespace WebProjekt_Beispiel.Controllers
{

    public class ShopController : Controller
    {

        IRepositoryArticle rep = new RepositoryArticle();

        public IActionResult Merch()
        {
            try
            {
                rep.Open();
                return View(rep.GetAllArticles());
            }
            catch (Exception ex)
            {
                return View("Message", new Message("Datenbakfehler", ex.Message));
            }
            finally
            {
                rep.Close();
            }
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View(new Merch());
        }

        [HttpPost]

        public IActionResult CreateArticle(Merch newMerch)
        {
            if(newMerch == null)
            {
                return RedirectToAction("createNewMerch");
            }
            ValidateMerchData(newMerch);

           
            if (ModelState.IsValid)
            {
                try
                {
                    rep.Open();

                    if (rep.Insert(newMerch))
                    {
                        return View("Message", new Message("Alles gut", "Merch gespeichert!"));
                    }
                }
                catch(DbException)
                {
                    return View("Message", new Message("Datenbank-Fehler", "Merch konnte nicht abgespeichert werden", "Versuchen Sie es bitte erneut"));
                }
                finally
                {
                    rep.Close();
                }

                return RedirectToAction("index", "home");
            }

            return View(newMerch);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                rep.Open();

                if (rep.Delete(id))
                {
                    return View("Message", new Message("Datebank", "Der Artikel wurde gelöscht!"));
                }
                else
                {
                    return View("Message", new Message("Datebank", "Der Artikel konnte nicht gelöscht werden!"));
                }
            }
            catch (Exception ex)
            {
                return View("Message", new Message("Datenbakfehler", ex.Message));
            }
            finally
            {
                rep.Close();
            }
        }

        private void ValidateMerchData(Merch a)
        {

            if (a == null)
            {
                return;
            }


            if (a.ArticleName.Length < 3)
            {
                ModelState.AddModelError(nameof(Models.Merch.ArticleName), "Artikelname muss mind. 3 Zeichen lang sein!");
            }
            if (a.ArticlePrice <= Decimal.Zero)
            {
                ModelState.AddModelError(nameof(Models.Merch.ArticlePrice), "Der Artikelpreis muss positiv sein!");
            }
        }
    }
}
