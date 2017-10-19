using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpregnutaLista
{
    public class Ucenik
    {
        private string ime;
        public string Ime
        {
            get
            { return ime; }
            set
            { ime = value; }
        }
        private string prezime;
        public string Prezime
        {
            get
            { return prezime; }
            set
            { prezime = value; }
        }
        public Ucenik(string ime = "", string prezime = "")
        {
            this.ime = ime;
            this.prezime = prezime;
        }
    }

    public class Element
    {
        public Ucenik Ucenik;
        public Element Pointer;
        public Element(Ucenik u = null)
        {
            Ucenik = u;
        }
    }

    public class Lista
    {
        public Element Prvi;
        public Lista()
        {
            Prvi = null;
        }
        public void AddToStart(Ucenik u)
        {
            Element x = Prvi;
            Prvi = new Element(u);
            Prvi.Pointer = x;
        }
        public void AddToEnd(Ucenik u)
        {
            if(Prvi == null)
            {
                Prvi = new Element(u);
            }
            else
            {
                Element search = Prvi;
                while(search.Pointer != null)
                {
                    search = search.Pointer;
                }
                search.Pointer = new Element(u);
            }
        }
        public void Obrisi(int broj)
        {
            if(!(Prvi == null))
            {
                Element search = Prvi;
                for(int i = 0; i < broj-2; i++)
                {
                    search = search.Pointer;
                }
                search.Pointer = search.Pointer.Pointer;
            }
        }
        public int Broj()
        {
            int x = 0;
            if(!(Prvi == null))
            {
                Element search = Prvi;
                while(search != null)
                {
                    ++x;
                    search = search.Pointer;
                }
            }
            return x;
        }
        public override string ToString()
        {
            string x = string.Empty;
            if(!(Prvi == null))
            {
                Element y = Prvi;
                uint brojac = 0;
                while (y != null)
                {
                    x += string.Format("\n {2}. Ime > {0} \n Prezime > {1} \n", y.Ucenik.Ime, y.Ucenik.Prezime, ++brojac);
                    y = y.Pointer;
                }
            }
            return x;
        }
        public void Print()
        {
            Console.WriteLine(this);
            Console.WriteLine("\n Broj clanova : {0}", Broj());
        }
    }


}
