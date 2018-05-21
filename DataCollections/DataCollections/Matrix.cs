using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollections
{
    /// <summary>
    /// This class represents an abstract data-type of a graph, symmetric and non-weighted.
    /// Represented by a matrix of booleans to handle the connections
    /// </summary>
    
    // there is a flaw while writing the path here!
    public class Graph
    {
        public string[] Data;
        public bool[,] Connections { get; }

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


    public class MatrixGraph<DataType, ConnectionType> where ConnectionType: struct
    {
        public DataType[] Data;
        public ConnectionType[,] Connections { get; }
        bool symmetric;

        public int Size { get => Data.Length; }

        public MatrixGraph(int Size, bool Symmetric = true)
        {
            Data = new DataType[Size];
            Connections = new ConnectionType[Size, Size];
            symmetric = Symmetric;
        }
        
        public void Connect(int index1, int index2, ConnectionType weight)
        {
            Connections[index1, index2] = weight;
            if(symmetric)
            {
                Connections[index2, index1] = weight;
            }
        }
        public void Disconnect(int index1, int index2)
        {
            Connections[index1, index2] = default(ConnectionType);
            if(symmetric)
            {
                Connections[index2, index1] = default(ConnectionType);
            }
        }
        public bool IsConnected(int index1, int index2)
        {
            if(Comparer<ConnectionType>.Default.Compare(Connections[index1, index2], default(ConnectionType)) == 0)
            {
                return false;
            }
            return true;
        }
        public bool PathExists(int index1, int index2)
        {
            if (IsConnected(index1, index2))
            {
                return true;
            }
            else
            {
                Stack<int> Visitlist = new Stack<int>();
                HashSet<int> Visited = new HashSet<int>();
                Visitlist.Push(index1);
                while (Visitlist.Any())
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
                            if (Comparer<ConnectionType>.Default.Compare(Connections[index, i], default(ConnectionType)) != 0 && !Visited.Contains(i))
                            {
                                Visitlist.Push(i);
                            }
                        }
                    }
                }
                return false;
            }
        }

        internal int startindex, indexpass;

        public Dictionary<string, List<ConnectionType>> BFSAllPaths(int index1, int index2)
        {
            indexpass = -1;
            startindex = index1;
            Dictionary<string, List<ConnectionType>> Paths = new Dictionary<string, List<ConnectionType>>();
            Queue<int> Visitlist = new Queue<int>();
            Stack<int> Visited = new Stack<int>();
            Visitlist.Enqueue(index1);
            BFS(Visitlist, Visited, index2, Paths);
            return Paths;
        }
        void BFS(Queue<int> visitlist, Stack<int> visited, int target, Dictionary<string, List<ConnectionType>> paths)
        {
            int lastindex = indexpass;
            int index = visitlist.Dequeue();
            indexpass = index;
            visited.Push(index);
            if (index == target)
            {
                Stack<int> thispath = new Stack<int>(visited);
                List<ConnectionType> weights = new List<ConnectionType>();
                string path = "";
                int lxyz, xyz = -1;
                while (thispath.Any())
                {
                    lxyz = xyz;
                    xyz = thispath.Pop();
                    if(lxyz != -1)
                    {
                        weights.Add(Connections[lxyz, xyz]);
                    }
                    path += string.Format(" {0} ", xyz);
                    if (thispath.Count != 0)
                    {
                        path += " -> ";
                    }
                }
                paths.Add(path, weights);
            }
            else
            {
                List<int> vstd = new List<int>(visited);
                for (int i = 0; i < Size; i++)
                {
                    if (Comparer<ConnectionType>.Default.Compare(Connections[i, index], default(ConnectionType)) != 0 && !vstd.Contains(i))
                    {
                        visitlist.Enqueue(i);
                        BFS(visitlist, visited, target, paths);
                        visited.Pop();
                    }
                }
            }
        }

        public Dictionary<string, List<ConnectionType>> DFSAllPaths(int index1, int index2)
        {
            startindex = index1;
            Dictionary<string, List<ConnectionType>> Paths = new Dictionary<string, List<ConnectionType>>();
            Stack<int> Visitlist = new Stack<int>();
            Stack<int> Visited = new Stack<int>();
            Visitlist.Push(index1);
            DFS(Visitlist, Visited, index2, Paths);
            return Paths;
        }
        void DFS(Stack<int> visitlist, Stack<int> visited, int target, Dictionary<string, List<ConnectionType>> paths)
        {
            int lastindex = indexpass;
            int index = visitlist.Pop();
            indexpass = index;
            visited.Push(index);
            if (index == target)
            {
                Stack<int> thispath = new Stack<int>(visited);
                List<ConnectionType> weights = new List<ConnectionType>();
                string path = "";
                int lxyz, xyz = -1;
                while (thispath.Any())
                {
                    lxyz = xyz;
                    xyz = thispath.Pop();
                    if(lxyz != -1)
                    {
                        weights.Add(Connections[lxyz, xyz]);
                    }
                    path += string.Format(" {0} ", xyz);
                    if (thispath.Count != 0)
                    {
                        path += " -> ";
                    }
                }
                paths.Add(path, weights);
            }
            else
            {
                for (int i = 0; i < Size; i++)
                {
                    if (Comparer<ConnectionType>.Default.Compare(Connections[index, i], default(ConnectionType)) != 0 && !visited.Contains(i))
                    {
                        visitlist.Push(i);
                        DFS(visitlist, visited, target, paths);
                        visited.Pop();
                    }
                }
            }
        }

        public struct PathInfo
        {
            public string Path;
            public List<ConnectionType> Weights;
        }

        public PathInfo BFSQuickestPath(int index1, int index2)
        {
            Dictionary<string, List<ConnectionType>> result = BFSAllPaths(index1, index2);

            try
            {
                List<string> Paths = result.Keys.ToList();
                string Quickest = Paths.OrderBy(c => c.Length).FirstOrDefault();
                List<ConnectionType> Weights = result[Quickest];
                return new PathInfo()
                {
                    Path = Quickest,
                    Weights = Weights
                };
            }
            catch
            {
                return new PathInfo()
                {
                    Path = "",
                    Weights = null
                };
            }
        }
        public PathInfo DFSQuickestPath(int index1, int index2)
        {
            Dictionary<string, List<ConnectionType>> result = DFSAllPaths(index1, index2);

            List<string> Paths = result.Keys.ToList();
            string Quickest = Paths.OrderBy(c => c.Length).FirstOrDefault();
            List<ConnectionType> Weights = result[Quickest];

            return new PathInfo()
            {
                Path = Quickest,
                Weights = Weights
            };
        }
        
    }

}
