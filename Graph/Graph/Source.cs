using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph<T>
    {
        #region Static
        public readonly static int DefaultLimit = 5;
        #endregion
        #region Fields
        T[] data;
        bool[,] connected;
        #endregion
        #region Constructor
        public Graph()
        {
            data = new T[DefaultLimit];
            connected = new bool[DefaultLimit, DefaultLimit];
        }
        public Graph(int limit)
        {
            data = new T[limit];
            connected = new bool[limit, limit];
        }
        public Graph(IEnumerable<T> data)
        {
            this.data = new T[data.Count()];
            data.ToList().CopyTo(this.data);
            connected = new bool[data.Count(), data.Count()];
        }
        public Graph(IEnumerable<T> data, int limit)
        {
            this.data = new T[limit];
            data.ToList().CopyTo(this.data, Math.Min(limit, data.Count()));
            connected = new bool[limit, limit];
        }
        #endregion
        #region Properties
        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        #endregion
        #region Methods
        public IEnumerable<bool> Connect(int[] indexes)
        {
            try
            {
                List<bool> returns = new List<bool>(indexes.Count() - 1);
                for(int i = 0; i < indexes.Count() - 1; i++)
                {
                    returns.Add(ConnectDirectly(indexes[i], indexes[i + 1]));
                }
                return returns;
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public bool isConnected(int indexOne, int indexTwo)
        {
            if(isDirectlyConnected(indexOne, indexTwo))
            {
                return true;
            }
            else
            {
                for(int i = 1; i <= data.Length; i++)
                {
                    if(i == indexOne)
                    {
                        continue;
                    }
                    if(isDirectlyConnected(indexOne, i))
                    {
                        return isConnected(i, indexTwo);
                    }
                }
                return false;
            }
        }
        public bool ConnectDirectly(int indexOne, int indexTwo)
        {
            try
            {
                if(!connected[indexOne-1, indexTwo-1])
                {
                    connected[indexOne-1, indexTwo-1] = true;
                    connected[indexTwo-1, indexOne-1] = true;
                    return true;
                }
                return false;
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public bool isDirectlyConnected(int indexOne, int indexTwo)
        {
            try
            {
                if(connected[indexOne, indexTwo])
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public string Print()
        {
            string returning = "\n";
            for(int i = 0; i < data.Count(); i++)
            {
                returning += string.Format("\tData - {0} : {1}\n", i + 1, data[i]);
            }
            returning += string.Format("\n\t");
            for(int i = 0; i < connected.GetLength(0); i++)
            {
                returning += string.Format(" {0} ", i + 1);
            }
            for(int i = 0; i < connected.GetLength(0); i++)
            {
                returning += string.Format("\n\t");
                for (int j = 0; j < connected.GetLength(1); j++)
                {
                    if(connected[i,j])
                    {
                        returning += string.Format(" + ");
                    }
                    else
                    {
                        returning += string.Format(" - ");
                    }
                }
                returning += string.Format(" {0} ", i + 1);
            }
            return returning;
        }
        #endregion
    }
}
