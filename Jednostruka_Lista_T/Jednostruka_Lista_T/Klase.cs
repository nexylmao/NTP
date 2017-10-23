using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class Element<T>
    {
        public T Value;
        public Element<T> Next;

        public Element(T newValue, Element<T> nextElement)
        {
            Value = newValue;
            Next = nextElement;
        }
    }

    public class List<T>
    {
        #region Fields
        public Element<T> First;
        public uint Limiter;
        #endregion

        #region Properties
        public T this[int index]
        {
            get
            {
                try
                {
                    return Indexing(index).Value;
                }
                catch
                {
                    return default(T);
                }
            }
            set
            {
                Indexing(index).Value = value;
            }
        }
        public uint Limit
        {
            get
            {
                return Limiter;
            }
        }
        public uint Count
        {
            get
            {
                return Counter();
            }
        }
        public bool IsEmpty
        {
            get
            {
                return EmptyChecker();
            }
        }
        public bool IsLimited
        {
            get
            {
                if (Limiter == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public Element<T> LastElement
        {
            get
            {
                return Last();
            }
        }
        public Element<T> FirstElement
        {
            get
            {
                return First;
            }
        }
        #endregion

        #region Methods/Private
        private uint Counter()
        {
            uint x = 0;
            if (First == null)
            {
                return x;
            }
            else
            {
                Element<T> search = First;
                while (search != null)
                {
                    search = search.Next;
                    x++;
                }
                return x;
            }
        }
        private bool EmptyChecker()
        {
            if (First == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Element<T> Last()
        {
            if (First == null)
            {
                return null;
            }
            else
            {
                Element<T> Search = First;
                while (Search.Next != null)
                {
                    Search = Search.Next;
                }
                return Search;
            }
        }
        private bool CanAdd(uint number = 1)
        {
            if(Limiter == 0)
            {
                return true;
            }
            if (Count + number <= Limiter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Methods/Public
        public List(uint x = 0)
        {
            First = null;
            Limiter = x;
        }
        public void Add(T newValue)
        {
            if(!CanAdd())
            {
                return;
            }
            if(First == null)
            {
                First = new Element<T>(newValue, First);
            }
            else
            {
                LastElement.Next = new Element<T>(newValue, LastElement.Next);
            }
        }
        public bool Remove(T toFind)
        {
            if(First == null)
            {
                return false;
            }
            else
            {
                Element<T> Search = First;
                while(!(toFind.Equals(Search.Next.Value)))
                {
                    Search.Next = Search.Next.Next;
                    return true;
                }
                return false;
            }
        }
        public bool Insert(T newValue, int Index)
        {
            if(!CanAdd())
            {

            }
            if(First == null)
            {
                return false;
            }
            else
            {
                Indexing(Index).Next = new Element<T>(newValue, Indexing(Index).Next);
                return false;
            }
        }
        public void AddFirst(T newValue)
        {
            First = new Element<T>(newValue, First);
        }
        public bool RemoveFirst()
        {
            if(First == null)
            {
                return false;
            }
            else
            {
                First = First.Next;
                return true;
            }
        }
        public bool DeleteFirstN(uint N)
        {
            if(First == null || Count < N)
            {
                return false;
            }
            else
            {
                try
                {
                    Element<T> Search = First;
                    for (int i = 0; i < N; i++)
                    {
                        Search = Search.Next;
                    }
                    First = Search;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public void AddList(ICollection<T> Elements)
        {
            if(!CanAdd(Convert.ToUInt32(Elements.Count)))
            {
                return;
            }
            foreach(T x in Elements)
            {
                Add(x);
            }
        }
        public int IndexOf(T SearchValue)
        {
            if(First == null)
            {
                return 0;
            }
            else
            {
                int x = 1;
                Element<T> Search = First;
                while(Search != null)
                {
                    if(Search.Value.Equals(SearchValue))
                    {
                        return x;
                    }
                    Search = Search.Next;
                    x++;
                }
                return 0;
            }
        }
        public bool Contains(T SearchValue)
        {
            if(First == null)
            {
                return false;
            }
            else
            {
                Element<T> Search = First;
                while(Search != null)
                {
                    if(Search.Value.Equals(SearchValue))
                    {
                        return true;
                    }
                    Search = Search.Next;
                }
                return false;
            }
        }
        public void Clear()
        {
            First = null;
        }
        public Element<T> Indexing(int i)
        {
            if(First == null)
            {
                return null;
            }
            else
            {
                Element<T> Search = First;
                for(uint x = 0; x <= i; x++)
                {
                    Search = Search.Next;
                    if(x == i)
                    {
                        return Search;
                    }
                }
                return null;
            }
        }
        public void ForEach(Action<T> x)
        {
            if(!(First == null))
            {
                for(int i = 0; i < Count; i++)
                {
                    x(Indexing(i).Value);
                }
            }
        }
        public new Type GetType()
        {
            return First.Value.GetType();
        }
        public T[] ToArray()
        {
            T[] Array = new T[Count];
            for(int i = 0; i < Count; i++)
            {
                Array[i] = Indexing(i).Value;
            }
            return Array;
        }
        #endregion
    }
}
