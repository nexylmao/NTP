using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCollections;

namespace Test2
{
    class Program
    {
        static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }

        static void PrintConnections(float[,] connections)
        {
            // Console.WriteLine(" 0123456789");
            Console.Write(' ');
            for (int i = 0; i < connections.GetLength(0); i++)
            {
                Console.Write(i % 10);
            }
            Console.WriteLine();
            for (int i = 0; i < connections.GetLength(0); i++)
            {
                Console.Write(i % 10);
                for (int j = 0; j < connections.GetLength(0); j++)
                {
                    if (connections[j, i] > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (connections[j, i] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
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
            int VertacyCount = 5;
            int EdgesCount = 5;
            bool Symmetric = false;

            MatrixGraph<string, float> x = new MatrixGraph<string, float>(VertacyCount, Symmetric);
            for(int i = 0; i < VertacyCount; i++)
            {
                x.Data[i] = GetRandomString();
            }
            Random r = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < EdgesCount;)
            {
                int index1 = r.Next(0, x.Size);
                int index2 = r.Next(0, x.Size);
                if(index1 != index2)
                {
                    x.Connect(index1, index2, r.Next(-5, 6));
                    i++;
                }
            }

            foreach(string y in x.Data)
            {
                Console.WriteLine("Created node : " + y + " ");
            }

            Console.WriteLine();
            PrintConnections(x.Connections);

            for (int i = 0; i < x.Size; i++)
            {
                for (int j = 0; j < x.Size; j++)
                {
                    if (i == j)
                        continue;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Paths from " + i + " to " + j + " !");
                    Console.ResetColor();
                    Console.WriteLine();
                    Dictionary<string, List<float>> Paths = x.DFSAllPaths(i, j);
                    if (Paths.Count == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("No paths found!");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    for(int k = 0; k < Paths.Count; k++)
                    {
                        Console.WriteLine("Path : " + Paths.Keys.ToList()[k]);
                        foreach(float l in Paths.Values.ToList()[k])
                        {
                            Console.Write(l + " ");
                        }
                        Console.Write("\t");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Path weight : " + Paths.Values.ToList()[k].Sum());
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
