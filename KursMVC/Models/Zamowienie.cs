using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KursMVC.Models
{
    public class Zamowienie
    {
        public int ZamowienieID { get; set; }
        [Required(ErrorMessage = "Wprowadz Imię")]
        [StringLength(50)]

        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadz Nazwisko")]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wprowadz Ulice")]
        [StringLength(100)]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Wprowadz Miasto")]
        [StringLength(100)]
        public string Miasto { get; set; }

        [Required(ErrorMessage = "Wprowadz Kod Pocztowy")]
        [StringLength(6)]
        public string KodPocztowy{ get; set; }

        public string Telefon { get; set; }

        public string Komentarz { get; set; }

        public DateTime DataDodania { get; set; }

        public StanZamowienia StanZamowienia { get; set; }

        public decimal WartoscZamowienia { get; set; }

        public List<PozycjaZamowienia> PozycjeZamowienia { get; set; }
    }

    public enum StanZamowienia
    {
        Nowe,
        Zrealizowane
    }
}