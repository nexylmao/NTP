using System;
using System.Collections.Generic;
using System.Linq;

namespace NTP.nexylmao.Sorting
{
    public enum SortingOrder { Ascending, Descending };
    public static class Algorithms
    {
        public static void SelectionSort<T>(IEnumerable<T> x, SortingOrder Order = SortingOrder.Ascending)
        {
            if (!typeof(T).IsSubclassOf(typeof(object)))
            {
                for (int i = 0; i < x.Count() - 1; i++)
                {
                    int pivot = i;
                    Comparer<T> comparer = Comparer<T>.Default;
                    for (int j = i + 1; j < x.Count(); j++)
                    {
                        if (comparer.Compare(x.ElementAt(pivot), x.ElementAt(j)) > 0 && Order == SortingOrder.Ascending)
                        {
                            pivot = j;
                        }
                        else if (comparer.Compare(x.ElementAt(pivot), x.ElementAt(j)) < 0 && Order == SortingOrder.Descending)
                        {
                            pivot = j;
                        }
                    }
                    if (pivot != i)
                    {
                        T swap = x.ElementAt(pivot);
                        x.ToArray()[pivot] = x.ElementAt(i);
                        x.ToArray()[i] = swap;
                    }
                }
            }
        }
    }
}
