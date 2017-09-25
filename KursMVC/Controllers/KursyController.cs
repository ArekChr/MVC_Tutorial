using KursMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursMVC.Controllers
{
    public class KursyController : Controller
    {
        private KursyContext db = new KursyContext();
        // GET: Kursy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lista(int kategoriaID)
        {
            var kategoria = db.Kategorie.Include("Kursy").Where(k => k.KategoriaID == kategoriaID).Single();
            var kursy = kategoria.Kursy.ToList();
            return View(kursy);
        }
        public ActionResult Szczegoly(int id)
        {
            var kurs = db.Kursy.Find(id);
            return View(kurs);
        }

        [ChildActionOnly]
        public ActionResult KategorieMenu()
        {
            var kategorie = db.Kategorie.ToList();
            return PartialView("_KategorieMenu", kategorie);
        }
    }
}