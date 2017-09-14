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
                new Kategoria() {KategoriaID=1, NazwaKategori = "Asp.Net", NazwaPlikuIkony="asp.png", OpisKategorii="opis asp net mvc"},
                new Kategoria() {KategoriaID=2, NazwaKategori = "Java", NazwaPlikuIkony="java.png", OpisKategorii="opis java"},
                new Kategoria() {KategoriaID=3, NazwaKategori = "php", NazwaPlikuIkony="php.png", OpisKategorii="opis php"},
                new Kategoria() {KategoriaID=4, NazwaKategori = "Html5", NazwaPlikuIkony="html.png", OpisKategorii="opis html"},
                new Kategoria() {KategoriaID=5, NazwaKategori = "Css3", NazwaPlikuIkony="css.png", OpisKategorii="opis css"},
                new Kategoria() {KategoriaID=6, NazwaKategori = "Xml", NazwaPlikuIkony="xml.png", OpisKategorii="opis xml"},
                new Kategoria() {KategoriaID=7, NazwaKategori = "C#", NazwaPlikuIkony="c#.png", OpisKategorii="opis c#"}
            };

            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();

            var kursy = new List<Kurs>
            {
                new Kurs() { AutorKursu="Tomek", TytulKursu="asp.net mvc", KategoriaID=1, CenaKursu=99, Bestseller=true, NazwaPlikuObrazka="Tomek.png",
                DataDodania = DateTime.Now, OpisKursu="opis kursu"},
                new Kurs() { AutorKursu="Jacek", TytulKursu="asp.net mvc3", KategoriaID=1, CenaKursu=120, Bestseller=true, NazwaPlikuObrazka="Jacek.png",
                DataDodania = DateTime.Now, OpisKursu="opis kursu"},
                new Kurs() { AutorKursu="Irek", TytulKursu="asp.net mvc4", KategoriaID=1, CenaKursu=120, Bestseller=true, NazwaPlikuObrazka="Irek.png",
                DataDodania = DateTime.Now, OpisKursu="opis kursu"},
                new Kurs() { AutorKursu="Romek", TytulKursu="asp.net mvc5", KategoriaID=1, CenaKursu=140, Bestseller=true, NazwaPlikuObrazka="Romek.png",
                DataDodania = DateTime.Now, OpisKursu="opis kursu"}
            };

            kursy.ForEach(k => context.Kursy.AddOrUpdate(k));
            context.SaveChanges();
        }
    }
}