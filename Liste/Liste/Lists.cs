using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class SingleLinkNode<T>
    {
        public T Value;
        public SingleLinkNode<T> Next;

        public SingleLinkNode(T Value, SingleLinkNode<T> Next = null)
        {
            this.Value = Value;
            this.Next = Next;
        }
    }

    class DoubleLinkNode<T>
    {
        public T Value;
        public SingleLinkNode<T> Previous, Next;

        public DoubleLinkNode(T Value, SingleLinkNode<T> Next = null, SingleLinkNode<T> Previous = null)
        {
            this.Value = Value;
            this.Previous = Previous;
            this.Next = Next;
        }
    }

    public class LinkedCircularList<T>
    {
        SingleLinkNode<T> Head;
        int Limit;

        public LinkedCircularList(int Limit = 0)
        {
            Head = null;
            this.Limit = Limit;
        }

        #region Properties
        public int Count
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
        #endregion

        #region Private_Methods
        public int Counter()
        {
            try
            {
                if (Head == null)
                {
                    return 0;
                }
                SingleLinkNode<T> Temp = Head;
                if(Temp.Next == Head)
                {
                    return 1;
                }
                int Counter = 0;
                while(Temp.Next != Head)
                {
                    Temp = Temp.Next;
                    Counter++;
                }
                return Counter;
            }
            catch
            {
                return -1;
            }
        }
        public bool EmptyChecker()
        {
            if(Head == null)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Public_Methods
        public bool Add(T newValue)
        {
            try
            {
                if(Count >= Limit && Limit != 0)
                {
                    return false;
                }
                if (Head == null)
                {
                    Head = new SingleLinkNode<T>(newValue);
                    Head.Next = Head;
                }
                else
                {
                    SingleLinkNode<T> Temp = Head;
                    while (Temp.Next != Head)
                    {
                        Temp = Temp.Next;
                    }
                    Temp.Next = new SingleLinkNode<T>(newValue, Head);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            string Returning = string.Empty;
            if(Head != null)
            {
                SingleLinkNode<T> Temp = Head;
                do
                {
                    Returning += string.Format(" {0} ", Temp.Value);
                    Temp = Temp.Next;
                }
                while (Temp != Head);
            }
            return Returning;
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public bool DeleteFirstAndLast()
        {
            try
            {
                if(Head == null)
                {
                    return false;
                }
                if(Count <= 2)
                {
                    Head = null;
                }
                else
                {
                    SingleLinkNode<T> Temp = Head;
                    while (Temp.Next.Next != Head)
                    {
                        Temp = Temp.Next;
                    }
                    Temp.Next = Temp.Next.Next.Next;
                    Head = Temp.Next;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ReplaceFirstAndLast()
        {
            try
            {
                if (Head == null)
                {
                    return false;
                }
                if (Count < 2)
                {
                    return false;
                }
                else
                {
                    SingleLinkNode<T> Temp = Head;
                    while (Temp.Next != Head)
                    {
                        Temp = Temp.Next;
                    }
                    T Swap = Head.Value;
                    Head.Value = Temp.Value;
                    Temp.Value = Swap;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

    public class TailedLinkedCircularList<T>
    {
        SingleLinkNode<T> Head;
        int Limit;

        public TailedLinkedCircularList(int Limit = 0)
        {
            this.Limit = Limit;
        }

        #region Properties
        private SingleLinkNode<T> Tail
        {
            get
            {
                return GetTail();
            }
        }
        public T FirstValue
        {
            get
            {
                return Head.Value;
            }
        }
        public T LastValue
        {
            get
            {
                return Tail.Value;
            }
        }
        public int Count
        {
            get
            { return Counter(); }
        }
        #endregion

        #region Private_Methods
        private SingleLinkNode<T> GetTail()
        {
            if(Head != null)
            {
                SingleLinkNode<T> Temp = Head;
                while(Temp.Next != Head)
                {
                    Temp = Temp.Next;
                }
                return Temp;
            }
            else
            {
                return null;
            }
        }
        public int Counter()
        {
            try
            {
                if(Head == null)
                {
                    return 0;
                }
                if(Head.Next == Head)
                {
                    return 1;
                }
                SingleLinkNode<T> Temp = Head;
                int counter = 0;
                do
                {
                    Temp = Temp.Next;
                    counter++;
                }
                while (Temp != Head);
                return counter;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

            #region Public_Methods
        public bool Add(T newValue)
        {
            try
            {
                if(Head == null)
                {
                    Head = new SingleLinkNode<T>(newValue, Head);
                    Head.Next = Head;
                }
                else
                {
                    Tail.Next = new SingleLinkNode<T>(newValue, Head);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            string Returning = string.Empty;
            if (Head != null)
            {
                SingleLinkNode<T> Temp = Head;
                do
                {
                    Returning += string.Format(" {0} ", Temp.Value);
                    Temp = Temp.Next;
                }
                while (Temp != Head);
            }
            return Returning;
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public bool DeleteFirstAndLast()
        {
            try
            {
                if (Head == null)
                {
                    return false;
                }
                if (Count <= 2)
                {
                    Head = null;
                }
                else
                {
                    SingleLinkNode<T> Temp = Head;
                    while(Temp.Next != Tail)
                    {
                        Temp = Temp.Next;
                    }
                    Temp.Next = Head.Next;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ReplaceFirstAndLast()
        {
            try
            {
                if(Head == null)
                {
                    return false;
                }
                if(Count < 2)
                {
                    return false;
                }
                T Swap = Tail.Value;
                Tail.Value = Head.Value;
                Head.Value = Swap;
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

    public class DoubleCircularList<T>
    {
        DoubleLinkNode<T> Head;
        int Limit;

        public DoubleCircularList(int Limit = 0)
        {
            this.Limit = Limit;
        }

        #region Properties

        #endregion

        #region Private_Methods
        public int Counter()
        {
            try
            {
                if(Head == null)
                {
                    return 0;
                }
                else
                {
                    int Counter = 1;
                    DoubleLinkNode<T> Temp = Head;
                    while(Temp.Next != Head)
                    {
                        Temp = Temp.Next;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
        #endregion
    }
}
