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
                new Kategoria() {KategoriaID=1, NazwaKategori = "Asp.Net", NazwaPlikuIkony="aspnet.png", OpisKategorii="opis asp net mvc"},
                new Kategoria() {KategoriaID=2, NazwaKategori = "JavaScript", NazwaPlikuIkony="javascript.png", OpisKategorii="opis javascript"},
                new Kategoria() {KategoriaID=3, NazwaKategori = "Jquery", NazwaPlikuIkony="jquery.png", OpisKategorii="opis jquery"},
                new Kategoria() {KategoriaID=4, NazwaKategori = "Html5", NazwaPlikuIkony="html.png", OpisKategorii="opis html"},
                new Kategoria() {KategoriaID=5, NazwaKategori = "Css3", NazwaPlikuIkony="css.png", OpisKategorii="opis css"},
                new Kategoria() {KategoriaID=6, NazwaKategori = "Xml", NazwaPlikuIkony="xml.png", OpisKategorii="opis xml"},
                new Kategoria() {KategoriaID=7, NazwaKategori = "C#", NazwaPlikuIkony="csharp.png", OpisKategorii="opis c#"}
            };

            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();

            var kursy = new List<Kurs>
            {
                new Kurs() { AutorKursu="Tomek", TytulKursu="Asp.NET mvc", KategoriaID=1, CenaKursu=99, Bestseller=true,
                    NazwaPlikuObrazka ="obrazekaspnet.png", DataDodania = DateTime.Now, OpisKursu="opis kursu"},
                new Kurs() { AutorKursu="Jacek", TytulKursu="Asp.NET MVC2", KategoriaID=1, CenaKursu=120, Bestseller=true,
                    NazwaPlikuObrazka ="obrazekmvc2.png", DataDodania = DateTime.Now, OpisKursu="opis kursu"},
                new Kurs() { AutorKursu="Irek", TytulKursu="HTML5", KategoriaID=1, CenaKursu=120, Bestseller=true,
                    NazwaPlikuObrazka ="obrazekhtml.png", DataDodania = DateTime.Now, OpisKursu="opis kursu"},
                new Kurs() { AutorKursu="Romek", TytulKursu="CSS3", KategoriaID=1, CenaKursu=140, Bestseller=true,
                    NazwaPlikuObrazka ="obrazekcss.png", DataDodania = DateTime.Now, OpisKursu="opis kursu"},
                new Kurs() { AutorKursu="Arek", TytulKursu="HTML", KategoriaID=4, CenaKursu=140, Bestseller=false,
                    NazwaPlikuObrazka ="obrazekhyml.png", DataDodania = DateTime.Now, OpisKursu="HTML stronki internetowe"}
            };

            kursy.ForEach(k => context.Kursy.AddOrUpdate(k));
            context.SaveChanges();
        }
    }
}