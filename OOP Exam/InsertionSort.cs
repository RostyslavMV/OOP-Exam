using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OOP_Exam
{
    public class InsertionSort<T>
    {
        public static Collection<T> Sort(Collection<T> collection, Comparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }
            int n = collection.Count;
            for (int i = 1; i < n; ++i)
            {
                T key = collection[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && comparer.Compare(collection[j], key) > 0)
                {
                    collection[j + 1] = collection[j];
                    j = j - 1;
                }
                collection[j + 1] = key;
            }
            return collection;
        }
    }
}
