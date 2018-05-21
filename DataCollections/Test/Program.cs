using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCollections;

/// <summary>
/// This main tests the class Graph -> and the paths methods
/// </summary>

namespace Test
{
    class Program
    {
        static void PrintConnections(bool[,] connections)
        {
            // Console.WriteLine(" 0123456789");
            Console.Write(' ');
            for(int i = 0; i < connections.GetLength(0); i++)
            {
                Console.Write(i % 10);
            }
            Console.WriteLine();
            for(int i = 0; i < connections.GetLength(0); i++)
            {
                Console.Write(i % 10);
                for(int j = 0; j < connections.GetLength(0); j++)
                {
                    if(connections[i,j] == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write(' ');
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int VertacyCount = 40;
            int EdgesCount = 60;

            Graph x = new Graph(VertacyCount);
            for (int i = 0; i < x.Size; i++)
            {
                x.Data[i] = "vertex" + i;
            }
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < EdgesCount;)
            {
                int index1 = r.Next(0, x.Size);
                int index2 = r.Next(0, x.Size);
                if (index1 != index2)
                {
                    Console.WriteLine("Connecting " + index1 + " and " + index2 + " !");
                    x.Connect(index1, index2);
                    i++;
                }
            }
            foreach (string y in x.Data)
            {
                Console.Write(" {0} ", y);
            }
            Console.WriteLine();
            PrintConnections(x.Connections);

            for (int i = 0; i < x.Size; i++)
            {
                for (int j = 0; j < x.Size; j++)
                {
                    if (i == j)
                        continue;
                    Console.WriteLine("Paths from " + i + " to " + j + " !");
                    List<string> Paths = new List<string>(x.DFSAllPaths(i, j));
                    if (Paths.Count == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("No paths found!");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    foreach (string Path in Paths)
                    {
                        Console.WriteLine(Path);
                    }
                }
            }

            int one = r.Next(0, x.Size);
            int two = r.Next(0, x.Size);

            Console.WriteLine("Quickest path from " + one + " -> " + two);
            Console.WriteLine(x.BFSQuickestPath(one,two));

            Console.ReadKey();
        }
    }
}
