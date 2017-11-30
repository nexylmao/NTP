using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liste;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedCircularList<int> Lista = new LinkedCircularList<int>();
            Lista.Add(3);
            Lista.Add(4);
            Lista.Add(5);
            Lista.Add(6);
            Lista.Print();
            Lista.ReplaceFirstAndLast();
            Lista.Print();
            Lista.DeleteFirstAndLast();
            Lista.Print();
            Console.ReadKey();
        }
    }
}
