using KursMVC.DAL;
using KursMVC.Infrastructure;
using KursMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursMVC.Controllers
{
    public class KoszykController : Controller
    {
        private KoszykManager koszykManager;
        private ISessionManager sessionManager { get; set; }
        private KursyContext db;

        public KoszykController()
        {
            db = new KursyContext();
            sessionManager = new SessionManager();
            koszykManager = new KoszykManager(sessionManager, db);
        }

        public ActionResult Index()
        {
            var pozycjeKoszyka = koszykManager.PobierzKoszyk();
            var cenaCalkowita = koszykManager.PobierzWartoscKoszyka();
            KoszykViewModel koszykVM = new KoszykViewModel()
            {
                PozycjeKoszyka = pozycjeKoszyka,
                CenaCalkowita = cenaCalkowita
            };

            return View(koszykVM);
        }

        public ActionResult DodajDoKoszyka(int id)
        {
            koszykManager.DodajDoKoszyka(id);
            return RedirectToAction("Index");
        }

        public int PobierzIloscElementowKoszyka()
        {
            return koszykManager.PobierzIloscPozycjiKoszyka();
        }

        public ActionResult UsunZKoszyka(int kursId2)
        {
            int iloscPozycji = koszykManager.UsunZKoszyka(kursId2);
            int iloscPozycjiKoszyka = koszykManager.PobierzIloscPozycjiKoszyka();
            decimal wartoscKoszyka = koszykManager.PobierzWartoscKoszyka();

            var wynik = new KoszykUsuwanieViewModel
            {
                IdPozycjiUsuwanej = kursId2,
                IloscPozycjiUsuwanej = iloscPozycji,
                KoszykCenaCalkowita = wartoscKoszyka,
                KoszykIloscPozycji = iloscPozycjiKoszyka
            };

            return Json(wynik);
        }
    }
}