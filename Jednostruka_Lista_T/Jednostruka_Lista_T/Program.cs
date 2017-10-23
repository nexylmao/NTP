using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> x = new List<int>();
            x.Add(9);
            int y = x[0];
            Console.WriteLine(y);
            Console.ReadKey();
        }
    }
}
