﻿using KursMVC.DAL;
using KursMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursMVC.Controllers
{
    public class HomeController : Controller
    {
        private KursyContext db = new KursyContext();

        public ActionResult Index()
        {
            var listaKategorii = db.Kategorie.ToList();

            return View();
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}