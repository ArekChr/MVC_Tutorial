namespace KursMVC.Models
{
    public class PozycjaZamowienia
    {
        public int PozycjaZamowieniaID { get; set; }
        public int ZamowieniaID { get; set; }
        public int KursID { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZakupu { get; set; }

        public virtual Kurs kurs { get; set; }
        public virtual Zamowienie zamowienie { get; set; }

    }
}