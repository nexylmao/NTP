using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Graph;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> x = new Graph<string>(new string[] { "mesto1", "mesto2", "mesto3", "mesto4", "mesto5", "mesto6", "mesto7", "mesto8" });
            x.ConnectDirectly(1, 3);
            x.ConnectDirectly(3, 5);
            /* if(x.isConnected(1,5))
            {
                Console.WriteLine("WORKS!");
            } */
            Action c = () => {
                Console.WriteLine("Hallä fitta!");
            };
            c.Invoke();
            Console.WriteLine(x.Print());
            Console.ReadKey(true);
        }
    }
}
