using KursMVC.DAL;
using KursMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using KursMVC.ViewModels;
using KursMVC.Infrastructure;
using System.Collections.Generic;

namespace KursMVC.Controllers
{
    public class HomeController : Controller
    {
        private KursyContext db = new KursyContext();

        public ActionResult Index()
        {
            ICacheProvider cache = new DefaultCacheProvider();

            List<Kategoria> kategorie;

            if (cache.IsSet(Consts.NowosciCacheKey))
            {
                kategorie = cache.Get(Consts.KategorieCacheKey) as List<Kategoria>;
            } else {
                kategorie = db.Kategorie.ToList();
                cache.Set(Consts.KategorieCacheKey, kategorie, 60000);
            }

            List<Kurs> nowosci;

            if (cache.IsSet(Consts.NowosciCacheKey))
            {
                nowosci = cache.Get(Consts.NowosciCacheKey) as List<Kurs>;
            } else {
                nowosci = db.Kursy.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(3).ToList();
                cache.Set(Consts.NowosciCacheKey, nowosci, 60000);
            }

            List<Kurs> bestsellery;

            if (cache.IsSet(Consts.NowosciCacheKey))
            {
                bestsellery = cache.Get(Consts.BestselleryCacheKey) as List<Kurs>;
            } else {
                bestsellery = db.Kursy.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Consts.BestselleryCacheKey, bestsellery, 60000);
            }

            var vm = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestsellery = bestsellery
            };

            return View(vm);
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}