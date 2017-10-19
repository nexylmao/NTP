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
            prvi.AddToEnd(new Ucenik("Pero", "Peric I"));
            prvi.AddToEnd(new Ucenik("Pero", "Peric II Perin Mali"));
            prvi.AddToStart(new Ucenik("Pero", "Peric III Veliki"));
            prvi.AddToEnd(new Ucenik("Pero", "Peric Pericic IV Nejaki"));
            prvi.Obrisi(2);
            prvi.Print();

            Console.ReadKey();
        }
    }
}
