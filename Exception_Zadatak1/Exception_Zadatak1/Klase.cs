using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Zadatak1
{
    public class Artikal
    {
        public string Naziv;
        public uint Cena;
        public Artikal(string Naziv, uint Cena)
        {
            this.Naziv = Naziv;
            this.Cena = Cena;
        }
    }

    public class Kupac
    {
        public List<Artikal> Korpa;
        public uint Novac;
        public Kupac(uint Novac = 0)
        {
            Korpa = new List<Artikal>();
            this.Novac = Novac;
        }
        public void DodajArtikal(Artikal a)
        {
            try
            {
                Korpa.Add(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void VratiArtikal(Artikal a)
        {
            try
            {
                Korpa.Remove(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Kasa
    {
        public Queue<Kupac> Red;
        public uint UkupnoNovca, UkupnoVreme, BrojKupaca;
        public static uint vremePoArtiklu = 10;
        public Kasa()
        {
            UkupnoNovca = 1500;
            UkupnoVreme = 0;
            BrojKupaca = 0;
            Red = new Queue<Kupac>(6);
        }
        public void DodajKupca(Kupac _Kupac)
        {
            Red.Enqueue(_Kupac);
        }

        public void UsluziKupca()
        {
            try
            {
                Kupac x = Red.Dequeue();
                foreach(Artikal y in x.Korpa)
                {
                    UkupnoNovca += y.Cena;
                    UkupnoVreme += vremePoArtiklu;
                }
                BrojKupaca++;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Red nema kupaca!");
            }
        }

        public void PrebaciKupca(Kasa _Kasa, uint N = 1)
        {
            try
            {
                for(int i = 0; i < N; i++)
                {
                    _Kasa.DodajKupca(Red.ToList().Last());
                    Red.ToList().Remove(Red.ToList().Last());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Prodavnica
    {
        public List<Kasa> Kase;

        public Prodavnica(int BrojKasa)
        {
            Kase = new List<Kasa>(BrojKasa);
            foreach(Kasa k in Kase)
            {
                k = new Kasa();
            }
        }
    }
}
