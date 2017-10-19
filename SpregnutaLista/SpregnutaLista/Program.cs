using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpregnutaLista
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista prvi = new Lista();
            prvi.AddToEnd(new Ucenik("Pero jebeni", "Peric"));
            prvi.AddToEnd(new Ucenik("Pero jebeni", "Peric 2"));
            prvi.AddToStart(new Ucenik("Pero jebeni", "Peric najveci"));
            prvi.AddToEnd(new Ucenik("Pero jebeni", "Peric 3"));
            prvi.Obrisi(2);
            prvi.Print();

            Console.ReadKey();
        }
    }
}
