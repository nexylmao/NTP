using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollections
{
    public class Graph
    {
        public string[] Data;
        public bool[,] Connections;

        public int Size { get => Data.Length; }

        public Graph(int Size)
        {
            Data = new string[Size];
            Connections = new bool[Size, Size];
        }

        public void Connect(int index1, int index2)
        {
            Connections[index1, index2] = true;
            Connections[index2, index1] = true;
        }
        public void Disconnect(int index1, int index2)
        {
            Connections[index1, index2] = false;
            Connections[index2, index1] = false;
        }
        public bool IsConnected(int index1, int index2)
        {
            return Connections[index1, index2];
        }
        public bool PathExists(int index1, int index2)
        {
            if(IsConnected(index1, index2))
            {
                return true;
            }
            else
            {
                Stack<int> Visitlist = new Stack<int>();
                HashSet<int> Visited = new HashSet<int>();
                Visitlist.Push(index1);
                while(Visitlist.Any())
                {
                    int index = Visitlist.Pop();
                    Visited.Add(index);
                    if (index == index2)
                    {
                        return true;
                    }
                    else
                    {
                        for (int i = 0; i < Size; i++)
                        {
                            if(Connections[index, i] && !Visited.Contains(i))
                            {
                                Visitlist.Push(i);
                            }
                        }
                    }
                }
                return false;
            }
        }

        public string[] BFSAllPaths(int index1, int index2)
        {
            List<string> Paths = new List<string>();

            Queue<int> Visitlist = new Queue<int>();
            Stack<int> Visited = new Stack<int>();
            Visitlist.Enqueue(index1);

            BFS(Visitlist, Visited, index2, Paths);

            return Paths.ToArray();
        }
        void BFS(Queue<int> visitlist, Stack<int> visited, int target, List<string> paths)
        {
            int index = visitlist.Dequeue();
            visited.Push(index);
            if (index == target)
            {
                Stack<int> thispath = new Stack<int>(visited);
                string path = "";
                while (thispath.Any())
                {
                    path += string.Format(" {0} ", thispath.Pop());
                    if (thispath.Count != 0)
                    {
                        path += " -> ";
                    }
                }
                paths.Add(path);
            }
            else
            {
                for (int i = 0; i < Size; i++)
                {
                    if (Connections[index, i] && !visited.Contains(i))
                    {
                        visitlist.Enqueue(i);
                        BFS(visitlist, visited, target, paths);
                        visited.Pop();
                    }
                }
            }
        }
        public string BFSQuickestPath(int index1, int index2)
        {
            return BFSAllPaths(index1, index2).OrderBy(c => c.Length).FirstOrDefault();
        }

        public string[] DFSAllPaths(int index1, int index2)
        {
            List<string> Paths = new List<string>();

            Stack<int> Visitlist = new Stack<int>(), Visited = new Stack<int>();
            Visitlist.Push(index1);

            DFS(Visitlist, Visited, index2, Paths);

            return Paths.ToArray();
        }
        void DFS(Stack<int> visitlist, Stack<int> visited, int target, List<string> paths)
        {
            int index = visitlist.Pop();
            visited.Push(index);
            if(index == target)
            {
                Stack<int> thispath = new Stack<int>(visited);
                string path = "";
                while(thispath.Any())
                {
                    path += string.Format(" {0} ", thispath.Pop());
                    if(thispath.Count != 0)
                    {
                        path += " -> ";
                    }
                }
                paths.Add(path);
            }
            else
            {
                for(int i = 0; i < Size; i++)
                {
                    if(Connections[index, i] && !visited.Contains(i))
                    {
                        visitlist.Push(i);
                        DFS(visitlist, visited, target, paths);
                        visited.Pop();
                    }
                }
            }
        }
        public string DFSQuickestPath(int index1, int index2)
        {
            return DFSAllPaths(index1, index2).OrderBy(c => c.Length).FirstOrDefault();
        }
    }
}
