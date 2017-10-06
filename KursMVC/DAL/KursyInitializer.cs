using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KursMVC.Models;
using KursMVC.Migrations;
using System.Data.Entity.Migrations;

namespace KursMVC.DAL
{
    public class KursyInitializer : MigrateDatabaseToLatestVersion<KursyContext, Configuration>
    {
        public static void SeedKursyData(KursyContext context)
        {
            var kategorie = new List<Kategoria>
            {
                new Kategoria() { KategoriaID=1, NazwaKategori="Asp.Net", NazwaPlikuIkony="aspnet.png", OpisKategorii="programowanie w asp net" },
                new Kategoria() { KategoriaID=2, NazwaKategori="JavaScript", NazwaPlikuIkony="javascript.png", OpisKategorii="skryptowy język programowania" },
                new Kategoria() { KategoriaID=3, NazwaKategori="jQuery", NazwaPlikuIkony="jquery.png", OpisKategorii="lekka biblioteka programistyczna dla języka JavaScript" },
                new Kategoria() { KategoriaID=4, NazwaKategori="Html5", NazwaPlikuIkony="html.png", OpisKategorii="język wykorzystywany do tworzenia i prezentowania stron internetowych www" },
                new Kategoria() { KategoriaID=5, NazwaKategori="Css3", NazwaPlikuIkony="css.png", OpisKategorii="język służący do opisu formy prezentacji (wyświetlania) stron www" },
                new Kategoria() { KategoriaID=6, NazwaKategori="Xml", NazwaPlikuIkony="xml.png", OpisKategorii="uniwersalny język znaczników przeznaczony do reprezentowania różnych danych w strukturalizowany sposób" },
                new Kategoria() { KategoriaID=7, NazwaKategori="C#", NazwaPlikuIkony="csharp.png", OpisKategorii="obiektowy język programowania zaprojektowany dla platformy .Net" }
            };

            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();

            var kursy = new List<Kurs>
            {
                new Kurs() { KursID=1, AutorKursu="Mariusz", TytulKursu="Asp.Net", KategoriaID=1, CenaKursu=0, Bestseller=true, NazwaPlikuObrazka="obrazekaspnet.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs ASP.NET - doskonała platforma do tworzenia dynamicznych aplikacji internetowych. Kurs jest przeznaczony dla wszystkich osób, które chcą nauczyć się od podstaw tworzenia stron internetowych wykorzystując technologię ASP-NET."},
                new Kurs() { KursID=2, AutorKursu="Mariusz", TytulKursu="Asp.Net Mvc", KategoriaID=1, CenaKursu=0, Bestseller=true, NazwaPlikuObrazka="obrazekmvc.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs ASP.NET MVC - przeznaczony jest dla wszystkich osób, które chcą nauczyć się od podstaw tworzenia stron internetowych wykorzystując technologię ASP-NET MVC."},
                new Kurs() { KursID=3, AutorKursu="Mariusz", TytulKursu="Asp.Net Mvc - Sklep Internetowy", KategoriaID=1, CenaKursu=100, Bestseller=true, NazwaPlikuObrazka="obrazekmvc2.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs Asp.Net Mvc - Sklep Internetowy - to praktyczne rozwiązanie wykorzystujące technologię Asp.Net Mvc pokazujące krok po kroku budowanie serwisu internetowego sprzedającego kursy on-line"},

                new Kurs() { KursID=4, AutorKursu="Mariusz", TytulKursu="JavaScript", KategoriaID=2, CenaKursu=70, Bestseller=false, NazwaPlikuObrazka="obrazekjavascript.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs JavaScript - skryptowy język programowania"},
                new Kurs() { KursID=5, AutorKursu="Mariusz", TytulKursu="jQuery", KategoriaID=3, CenaKursu=90, Bestseller=true, NazwaPlikuObrazka="obrazekjquery.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs jQuery - lekka biblioteka programistyczna dla języka JavaScript"},
                new Kurs() { KursID=6, AutorKursu="Mariusz", TytulKursu="Html5", KategoriaID=4, CenaKursu=70, Bestseller=false, NazwaPlikuObrazka="obrazekhtml.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs Html5 - język wykorzystywany do tworzenia i prezentowania stron internetowych www"},

                new Kurs() { KursID=7, AutorKursu="Mariusz", TytulKursu="Css3", KategoriaID=5, CenaKursu=70, Bestseller=false, NazwaPlikuObrazka="obrazekcss.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs Css3 - język służący do opisu formy prezentacji (wyświetlania) stron www"},
                new Kurs() { KursID=8, AutorKursu="Mariusz", TytulKursu="Xml", KategoriaID=6, CenaKursu=60, Bestseller=false, NazwaPlikuObrazka="obrazekxml.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs Xml - uniwersalny język znaczników przeznaczony do reprezentowania różnych danych w strukturalizowany sposób"},
                new Kurs() { KursID=9, AutorKursu="Mariusz", TytulKursu="C#", KategoriaID=7, CenaKursu=90, Bestseller=true, NazwaPlikuObrazka="obrazekcsharp.png",
                DataDodania = DateTime.Now, OpisKursu="Kurs C# - obiektowy język programowania zaprojektowany dla platformy .Net"}
            };

            kursy.ForEach(k => context.Kursy.AddOrUpdate(k));
            context.SaveChanges();
        }
    }
}