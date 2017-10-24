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
            List<string> Strings = new List<string>() { "x", "y", "z" };
            Console.WriteLine(Strings[-1]);

            Console.ReadKey();
        }
    }
}
