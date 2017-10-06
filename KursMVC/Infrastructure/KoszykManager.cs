using KursMVC.DAL;
using KursMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KursMVC.Infrastructure
{
    public class KoszykManager
    {
        private KursyContext db;
        private ISessionManager session;

        public KoszykManager(ISessionManager session, KursyContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;

            if (session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKey) == null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKey) as List<PozycjaKoszyka>;
            }

            return koszyk;

        }
        public void DodajDoKoszyka(int kursId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Kurs.KursID == kursId);

            if(pozycjaKoszyka != null)
            {
                pozycjaKoszyka.Ilosc++;
            }
            else
            {
                var kursDoDodania = db.Kursy.Where(k => k.KursID == kursId).SingleOrDefault();

                if(kursDoDodania != null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        Kurs = kursDoDodania,
                        Ilosc = 1,
                        Wartosc = kursDoDodania.CenaKursu
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }

            session.Set(Consts.KoszykSessionKey, koszyk);
        }

        public int UsunZKoszyka(int kursId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Kurs.KursID == kursId);

            if(pozycjaKoszyka != null)
            {
                if(pozycjaKoszyka.Ilosc > 1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }
            return 0;
        }

        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => (k.Ilosc * k.Kurs.CenaKursu));
        }

        public int PobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => k.Ilosc);
        }

        public Zamowienie UtworzZamowienie(Zamowienie noweZamowienie, string userID)
        {

            var koszyk = PobierzKoszyk();
            noweZamowienie.DataDodania = DateTime.Now;
            noweZamowienie.UserID = userID;

            db.Zamowienia.Add(noweZamowienie);

            if (noweZamowienie.PozycjeZamowienia == null)
            {
                noweZamowienie.PozycjeZamowienia = new List<PozycjaZamowienia>();
            }
            decimal koszykWartosc = 0;

            foreach(var koszykElement in koszyk)
            {
                var nowaPozycjaZamowienia = new PozycjaZamowienia()
                {
                    KursID = koszykElement.Kurs.KursID,
                    Ilosc = koszykElement.Ilosc,
                    CenaZakupu = koszykElement.Kurs.CenaKursu
                };

                koszykWartosc += (koszykElement.Ilosc * koszykElement.Kurs.CenaKursu);
                noweZamowienie.PozycjeZamowienia.Add(nowaPozycjaZamowienia);
            }

            noweZamowienie.WartoscZamowienia = koszykWartosc;
            db.SaveChanges();

            return noweZamowienie;
        }

        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Consts.KoszykSessionKey, null);
        }
    }
}