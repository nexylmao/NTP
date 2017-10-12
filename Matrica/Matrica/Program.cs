using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrica
{
    public class Matrica
    {
        private int[,] Vrednosti;
        public Matrica(int a, int b)
        {
            Vrednosti = new int[a, b];
        }
        public int BrojRedova()
        {
            return Vrednosti.GetLength(1);
        }
        public int BrojKolona()
        {
            return Vrednosti.GetLength(0);
        }
        public void PromeniVrednost(int a, int b, int vrednost)
        {
            try
            {
                Vrednosti[a, b] = vrednost;
            }
            catch
            {
                Console.WriteLine("Neka od vrednosti je izvan ranga!");
            }
        }
        public override string ToString()
        {
            string x = string.Empty;

            x += "\n { ";
            for (int i = 0; i < BrojRedova(); i++)
            {
                x += " ( ";
                for(int j = 0; j < BrojKolona(); j++)
                {
                    x += string.Format(" {0} ", Vrednosti[i, j]);
                    if(!(j + 1 == BrojKolona()))
                    {
                        x += " , ";
                    }
                }
                x += " ) ";
            }
            x += " } ";

            return x;
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public static Matrica UnosConsole()
        {
            Console.WriteLine("Unosenje matrice : ");
            Console.WriteLine("Unesite broj redova : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesite broj kolona : ");
            int b = Convert.ToInt32(Console.ReadLine());
            Matrica m = new Matrica(a, b);
            for (int i = 0; i < m.BrojRedova(); i++)
            {
                Console.WriteLine("Unosenje {0}. reda", i + 1);
                Console.WriteLine();
                for (int j = 0; j < m.BrojKolona(); j++)
                {
                    Console.Write("> ");
                    try
                    {
                        m.Vrednosti[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Uneli ste nesto bezvezno lul, stavljam kao jedan");
                        m.Vrednosti[i, j] = 1;
                    }
                }
            }
            return m;
        }
        public void Invert()
        {
            for(int i = 0; i < BrojRedova(); i++)
            {
                for(int j = 0; j < i; j++)
                {
                    int swap = Vrednosti[i, j];
                    Vrednosti[i, j] = Vrednosti[j, i];
                    Vrednosti[j, i] = swap;
                }
            }
        }
        public List<List<int>> ToList()
        {
            List<List<int>> x = new List<List<int>>();
            for(int i = 0; i < BrojRedova(); i++)
            {
                x.Add(new List<int>());
                for(int j = 0; j < BrojKolona(); j++)
                {
                    x[i].Add(Vrednosti[i, j]);
                }
            }
            return x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
