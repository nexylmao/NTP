using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NTP.nexylmao.Collections
{
    // single linked list
    public class SLElement<T>
    {
        public T Value;
        public SLElement<T> Next;
        public SLElement(T newValue, SLElement<T> nextElement)
        {
            Value = newValue;
            Next = nextElement;
        }
    }

    public class SLList<T> : IEnumerable<T>
    {
        #region Fields
        public SLElement<T> First;
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
        public SLElement<T> LastElement
        {
            get
            {
                return Last();
            }
        }
        public SLElement<T> FirstElement
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
                SLElement<T> search = First;
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
        private SLElement<T> Last()
        {
            if (First == null)
            {
                return null;
            }
            else
            {
                SLElement<T> Search = First;
                while (Search.Next != null)
                {
                    Search = Search.Next;
                }
                return Search;
            }
        }
        private bool CanAdd(uint number = 1)
        {
            if (Limiter == 0)
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
        public SLList(uint x = 0)
        {
            First = null;
            Limiter = x;
        }
        public SLList(IEnumerable<T> list)
        {
            if (list != null)
            {
                foreach (T x in list)
                {
                    Add(x);
                }
            }
        }
        public void Add(T newValue)
        {
            if (!CanAdd())
            {
                return;
            }
            if (First == null)
            {
                First = new SLElement<T>(newValue, First);
            }
            else
            {
                LastElement.Next = new SLElement<T>(newValue, LastElement.Next);
            }
        }
        public bool Remove(T toFind)
        {
            if (First == null)
            {
                return false;
            }
            else
            {
                SLElement<T> Search = First;
                while (!(toFind.Equals(Search.Next.Value)))
                {
                    Search.Next = Search.Next.Next;
                    return true;
                }
                return false;
            }
        }
        public bool Insert(T newValue, int Index)
        {
            if (!CanAdd())
            {

            }
            if (First == null)
            {
                return false;
            }
            else
            {
                Indexing(Index).Next = new SLElement<T>(newValue, Indexing(Index).Next);
                return false;
            }
        }
        public void AddFirst(T newValue)
        {
            First = new SLElement<T>(newValue, First);
        }
        public bool RemoveFirst()
        {
            if (First == null)
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
            if (First == null || Count < N)
            {
                return false;
            }
            else
            {
                try
                {
                    SLElement<T> Search = First;
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
            if (!CanAdd(Convert.ToUInt32(Elements.Count)))
            {
                return;
            }
            foreach (T x in Elements)
            {
                Add(x);
            }
        }
        public int IndexOf(T SearchValue)
        {
            if (First == null)
            {
                return 0;
            }
            else
            {
                int x = 1;
                SLElement<T> Search = First;
                while (Search != null)
                {
                    if (Search.Value.Equals(SearchValue))
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
            if (First == null)
            {
                return false;
            }
            else
            {
                SLElement<T> Search = First;
                while (Search != null)
                {
                    if (Search.Value.Equals(SearchValue))
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
        public SLElement<T> Indexing(int i)
        {
            if (First == null)
            {
                return null;
            }
            else
            {
                SLElement<T> Search = First;
                for (uint x = 0; x <= i; x++)
                {
                    Search = Search.Next;
                    if (x == i)
                    {
                        return Search;
                    }
                }
                return null;
            }
        }
        public void ForEach(Action<T> x)
        {
            if (!(First == null))
            {
                for (int i = 0; i < Count; i++)
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
            for (int i = 0; i < Count; i++)
            {
                Array[i] = Indexing(i).Value;
            }
            return Array;
        }


        // DONT KNOW HOW TO FIX THIS, NEEDED TO MAKE foreach WORK!
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    // double linked list
    public class DLElement<T>
    {
        public T Value;
        public DLElement<T> Next;
        public DLElement<T> Previous;

        public DLElement(T newValue, DLElement<T> previousElement = null, DLElement<T> nextElement = null)
        {
            Value = newValue;
            Previous = previousElement;
            Next = nextElement;
        }
    }

    public class DLList<T>
    {
        #region Fields
        public DLElement<T> First;
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
        public DLElement<T> LastElement
        {
            get
            {
                return Last();
            }
        }
        public DLElement<T> FirstElement
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
                DLElement<T> search = First;
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
        private DLElement<T> Last()
        {
            if (First == null)
            {
                return null;
            }
            else
            {
                DLElement<T> Search = First;
                while (Search.Next != null)
                {
                    Search = Search.Next;
                }
                return Search;
            }
        }
        private bool CanAdd(uint number = 1)
        {
            if (Limiter == 0)
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
        public DLList(uint x = 0)
        {
            First = null;
            Limiter = x;
        }
        public void Add(T newValue)
        {
            if (!CanAdd())
            {
                return;
            }
            if (First == null)
            {
                First = new DLElement<T>(newValue, null, First);
            }
            else
            {
                LastElement.Next = new DLElement<T>(newValue, LastElement, LastElement.Next);
            }
        }
        public bool Remove(T toFind)
        {
            if (First == null)
            {
                return false;
            }
            else
            {
                DLElement<T> Search = First;
                while (!(toFind.Equals(Search.Next.Value)))
                {
                    Search.Next = Search.Next.Next;
                    Search.Next.Previous = Search;
                    return true;
                }
                return false;
            }
        }
        public bool Insert(T newValue, int Index)
        {
            if (!CanAdd())
            {

            }
            if (First == null)
            {
                return false;
            }
            else
            {
                Indexing(Index).Next = new DLElement<T>(newValue, Indexing(Index), Indexing(Index).Next);
                return false;
            }
        }
        public void AddFirst(T newValue)
        {
            First = new DLElement<T>(newValue, null, First);
        }
        public bool RemoveFirst()
        {
            if (First == null)
            {
                return false;
            }
            else
            {
                First = First.Next;
                First.Previous = null;
                return true;
            }
        }
        public bool DeleteFirstN(uint N)
        {
            if (First == null || Count < N)
            {
                return false;
            }
            else
            {
                try
                {
                    DLElement<T> Search = First;
                    for (int i = 0; i < N; i++)
                    {
                        Search = Search.Next;
                    }
                    First = Search;
                    First.Previous = null;
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
            if (!CanAdd(Convert.ToUInt32(Elements.Count)))
            {
                return;
            }
            foreach (T x in Elements)
            {
                Add(x);
            }
        }
        public int IndexOf(T SearchValue)
        {
            if (First == null)
            {
                return 0;
            }
            else
            {
                int x = 1;
                DLElement<T> Search = First;
                while (Search != null)
                {
                    if (Search.Value.Equals(SearchValue))
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
            if (First == null)
            {
                return false;
            }
            else
            {
                DLElement<T> Search = First;
                while (Search != null)
                {
                    if (Search.Value.Equals(SearchValue))
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
        public DLElement<T> Indexing(int i)
        {
            if (First == null)
            {
                return null;
            }
            else
            {
                DLElement<T> Search = First;
                for (uint x = 0; x <= i; x++)
                {
                    Search = Search.Next;
                    if (x == i)
                    {
                        return Search;
                    }
                }
                return null;
            }
        }
        public void ForEach(Action<T> x)
        {
            if (!(First == null))
            {
                for (int i = 0; i < Count; i++)
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
            for (int i = 0; i < Count; i++)
            {
                Array[i] = Indexing(i).Value;
            }
            return Array;
        }
        #endregion
    }

    // some more lists
    public class SingleLinkNode<T>
    {
        public T Value;
        public SingleLinkNode<T> Next;

        public SingleLinkNode(T Value, SingleLinkNode<T> Next = null)
        {
            this.Value = Value;
            this.Next = Next;
        }
    }

    public class DoubleLinkNode<T>
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
                if (Temp.Next == Head)
                {
                    return 1;
                }
                int Counter = 0;
                while (Temp.Next != Head)
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
            if (Head == null)
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
                if (Count >= Limit && Limit != 0)
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
            if (Head != null)
            {
                SingleLinkNode<T> Temp = Head;
                while (Temp.Next != Head)
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
                if (Head == null)
                {
                    return 0;
                }
                if (Head.Next == Head)
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
                if (Head == null)
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
                    while (Temp.Next != Tail)
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
                if (Head == null)
                {
                    return false;
                }
                if (Count < 2)
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

    // Ucenik - non-generic list
    public class Ucenik
    {
        private string ime;
        public string Ime
        {
            get
            { return ime; }
            set
            { ime = value; }
        }
        private string prezime;
        public string Prezime
        {
            get
            { return prezime; }
            set
            { prezime = value; }
        }
        public Ucenik(string ime = "", string prezime = "")
        {
            this.ime = ime;
            this.prezime = prezime;
        }
    }

    public class Element
    {
        public Ucenik Ucenik;
        public Element Pointer;
        public Element(Ucenik u = null)
        {
            Ucenik = u;
        }
    }

    public class Lista
    {
        public Element Prvi;
        public Lista()
        {
            Prvi = null;
        }
        public void AddToStart(Ucenik u)
        {
            Element x = Prvi;
            Prvi = new Element(u);
            Prvi.Pointer = x;
        }
        public void AddToEnd(Ucenik u)
        {
            if (Prvi == null)
            {
                Prvi = new Element(u);
            }
            else
            {
                Element search = Prvi;
                while (search.Pointer != null)
                {
                    search = search.Pointer;
                }
                search.Pointer = new Element(u);
            }
        }
        public void Obrisi(int broj)
        {
            if (!(Prvi == null))
            {
                Element search = Prvi;
                for (int i = 0; i < broj - 2; i++)
                {
                    search = search.Pointer;
                }
                search.Pointer = search.Pointer.Pointer;
            }
        }
        public int Broj()
        {
            int x = 0;
            if (!(Prvi == null))
            {
                Element search = Prvi;
                while (search != null)
                {
                    ++x;
                    search = search.Pointer;
                }
            }
            return x;
        }
        public bool IsEmpty()
        {
            if (Broj() == 0)
            {
                return true;
            }
            return false;
        }
        public Ucenik PrviUcenik()
        {
            return Prvi.Ucenik;
        }
        public void ObrisiPrvi(int n)
        {
            try
            {
                if (!(Prvi == null))
                {
                    Element search = Prvi;
                    while (search != null)
                    {
                        search = search.Pointer;
                    }
                    Prvi = search;
                }
            }
            catch
            {
                Console.WriteLine("PUCE!");
            }
        }
        public override string ToString()
        {
            string x = string.Empty;
            if (!(Prvi == null))
            {
                Element y = Prvi;
                uint brojac = 0;
                while (y != null)
                {
                    x += string.Format("\n {2}. Ime > {0} \n Prezime > {1} \n", y.Ucenik.Ime, y.Ucenik.Prezime, ++brojac);
                    y = y.Pointer;
                }
            }
            return x;
        }
        public void Print()
        {
            Console.WriteLine(this);
            Console.WriteLine("\n Broj clanova : {0}", Broj());
        }
    }

    // stacks
    public class ListStack<T>
    {
        List<T> Values;
        int Limit;

        public ListStack(int Limiter = 0)
        {
            Values = new List<T>();
            Limit = Limiter;
        }

        public int Count
        {
            get
            {
                return Values.Count;
            }
        }

        public int hasLimit
        {
            get
            {
                return Limit;
            }
        }

        public bool Push(T Value)
        {
            if ((Values.Count < Limit && Limit != 0) || Limit == 0)
            {
                Values.Add(Value);
                return true;
            }
            return false;
        }

        public T Top()
        {
            try
            {
                return Values.Last();
            }
            catch
            {
                return default(T);
            }
        }

        public bool Pop()
        {
            return Values.Remove(Values.Last());
        }
    }

    public class ArrayStack<T>
    {
        T[] Values;

        public ArrayStack(int Length)
        {
            Values = new T[Length];
        }

        public int Length
        {
            get
            {
                return Values.Length;
            }
            set
            {
                if (ChangeLength(value))
                {
                    Console.WriteLine("Successfully changed length!");
                }
                else
                {
                    Console.WriteLine("Couldn't change the length!");
                }
            }
        }

        public int Count
        {
            get
            {
                return Counter();
            }
        }

        private int Counter()
        {
            int Count = Length;
            while (Values[Count].Equals(default(T)) && Count >= 0)
            {
                Count--;
            }
            return Count;
        }

        private bool ChangeLength(int newLength)
        {
            try
            {
                int minLen = Math.Min(newLength, Length);
                T[] Temp = new T[minLen];
                Values.CopyTo(Temp, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Push(T Value)
        {
            if (Count < Length)
            {
                Values[Count + 1] = Value;
                return true;
            }
            return false;
        }

        public T Top()
        {
            return Values[Count];
        }

        public bool Pop()
        {
            try
            {
                Values[Count] = default(T);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    // matrix -- old
    public class Matrica
    {
        private int[,] Vrednosti;
        public Matrica(int a, int b)
        {
            Vrednosti = new int[a, b];
        }
        public int BrojRedova()
        {
            return Vrednosti.GetLength(1);
        }
        public int BrojKolona()
        {
            return Vrednosti.GetLength(0);
        }
        public void PromeniVrednost(int a, int b, int vrednost)
        {
            try
            {
                Vrednosti[a, b] = vrednost;
            }
            catch
            {
                Console.WriteLine("Neka od vrednosti je izvan ranga!");
            }
        }
        public override string ToString()
        {
            string x = string.Empty;

            x += "\n{";
            for (int i = 0; i < BrojRedova(); i++)
            {
                x += "\n( ";
                for (int j = 0; j < BrojKolona(); j++)
                {
                    x += string.Format(" {0} ", Vrednosti[i, j]);
                    if (!(j + 1 == BrojKolona()))
                    {
                        x += " , ";
                    }
                }
                x += " ) ";
            }
            x += "\n}\n";

            return x;
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public static Matrica UnosConsole()
        {
            Console.WriteLine("Unosenje matrice : ");
            Console.WriteLine("Unesite broj redova : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesite broj kolona : ");
            int b = Convert.ToInt32(Console.ReadLine());
            Matrica m = new Matrica(a, b);
            for (int i = 0; i < m.BrojRedova(); i++)
            {
                Console.WriteLine("Unosenje {0}. reda", i + 1);
                Console.WriteLine();
                for (int j = 0; j < m.BrojKolona(); j++)
                {
                    Console.Write("> ");
                    try
                    {
                        m.Vrednosti[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Uneli ste nesto bezvezno lul, stavljam kao jedan");
                        m.Vrednosti[i, j] = 1;
                    }
                }
            }
            return m;
        }
        public void Invert()
        {
            for (int i = 0; i < BrojRedova(); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int swap = Vrednosti[i, j];
                    Vrednosti[i, j] = Vrednosti[j, i];
                    Vrednosti[j, i] = swap;
                }
            }
        }
        public List<List<int>> ToList()
        {
            List<List<int>> x = new List<List<int>>();
            for (int i = 0; i < BrojRedova(); i++)
            {
                x.Add(new List<int>());
                for (int j = 0; j < BrojKolona(); j++)
                {
                    x[i].Add(Vrednosti[i, j]);
                }
            }
            return x;
        }
    }
}
