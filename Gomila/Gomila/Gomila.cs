using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomila
{
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
            if((Values.Count < Limit && Limit != 0) || Limit == 0)
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
                if(ChangeLength(value))
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
            while(Values[Count].Equals(default(T)) && Count >= 0)
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
}
