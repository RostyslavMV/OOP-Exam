using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OOP_Exam
{
    public class MergeSort<T>
    {
        public static Collection<T> Sort(Collection<T> unsorted, Comparer<T> comparer = null)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            Collection<T> left = new Collection<T>();
            Collection<T> right = new Collection<T>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = Sort(left);
            right = Sort(right);
            return Merge(left, right, comparer);
        }

        private static Collection<T> Merge(Collection<T> left, Collection<T> right, Comparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }
            Collection<T> result = new Collection<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    //Comparing First two elements to see which is smaller
                    if (comparer.Compare(left.First(), right.First()) <= 0)
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
