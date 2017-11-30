using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Ucenik
    {
        public string Ime, Prezime;
        public int Razred;
    }

    public class Program
    {
        static void main(string[] args)
        {
            Ucenik prvi = new Ucenik(), drugi = new Ucenik();
            prvi.Ime = "Petar";
            drugi.Ime = "Ana";
        }
    }
}
