using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KursMVC.Models;

namespace KursMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Kategoria> Kategorie { get; set; }
        public IEnumerable<Kurs> Nowosci { get; set; }
        public IEnumerable<Kurs> Bestsellery { get; set; }


    }
}