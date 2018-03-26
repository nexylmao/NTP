using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_test
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            //      Kontrolni zadatak - Vuletic Nenad
            //      Objekat - Mapa
            //

            /* test class Objekat
            Objekat o1 = new Objekat(), o2 = new Objekat(3, 3, VrstaObjekta.Igraonica, "Igraonica KUM", 5);
            Console.WriteLine(o1 + "\n" + o2);
            */

            /* test class Mapa 
            Mapa m1 = new Mapa(), m2 = new Mapa(150, 150, new List<Objekat>() { new Objekat(), new Objekat(3, 3, VrstaObjekta.Igraonica, "Igraonica KUM", 5) });
            Console.WriteLine(m1.ToString() + m2.ToString());
            */

            /* onaj slucaj
            List<Objekat> Objekti = new List<Objekat>()
            {
                new Objekat(2,2),
                new Objekat(-2,2),
                new Objekat(-2,-2),
                new Objekat(2, -2)
            };

            Mapa m = new Mapa(100,100,Objekti);

            Console.WriteLine(m);

            try
            {
                Console.WriteLine(m.Nadji(3, 3, 5, 0));
            }
            catch
            {
                Console.WriteLine("Doslo je do greske pri nalazenju!");
            }

            Console.ReadKey(true);
            */

            // ima 12, sa 2 koja se nece pojaviti!
            
            List<Objekat> Prefabs = new List<Objekat>()
            {
                new Objekat(60,60,VrstaObjekta.Default,"Ovaj ne treba da se pojavi! (Barem u 100,100 slucaju!)"),
                new Objekat(-60,-60,VrstaObjekta.Default,"A ni ovaj! (Barem u 100,100 slucaju!)"),
                new Objekat(),
                new Objekat(20,10),
                new Objekat("#region"),
                new Objekat(VrstaObjekta.Galerija),
                new Objekat(15,15, VrstaObjekta.Prodavnica, "Hehe"),
                new Objekat(25,-30, VrstaObjekta.Galerija, "See this!", 3),
                new Objekat(-20, -20, VrstaObjekta.Default, "Default Objekat"),
                new Objekat(-30, 30, VrstaObjekta.Muzej, "BOOOOORRRIIIING!", 2),
                new Objekat(2,2,VrstaObjekta.Klub,"Centar",3),
                new Objekat(16,16,VrstaObjekta.Restoran,"One and only place you can eat u gradu je poisoned xD",5)
            };

            Mapa mapa = new Mapa(100,100,Prefabs);

            Console.WriteLine(mapa);

            Objekat pogresan = new Objekat(60, 60);
            try
            {
                mapa.Dodaj(pogresan);
            }
            catch
            {
                Console.WriteLine("\nDoslo je do greske ! - Ona treba da se desi!\n");
            }

            Console.WriteLine(mapa);
            try
            {
                mapa.Sort();
                Console.WriteLine(mapa);
            }
            catch
            {
                Console.WriteLine("\n\tDoslo je do greske kad smo sortirali objekte!\n");
            }

            try
            {
                Console.WriteLine("Za vas smo pronasli objekat : \n\t" + mapa.Nadji(13, 13, 30, 0));
            }
            catch
            {
                Console.WriteLine("\n\tDoslo je do greske kad smo trazili objekat za vas!\n");
            }

            Console.ReadKey(true);
        }
    }
}
