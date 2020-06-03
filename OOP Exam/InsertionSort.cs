using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    public class InsertionSort<T>
    {
        public static void Sort(Collection<T> collection)
        {
            int n = collection.Count;
            for (int i = 1; i < n; ++i)
            {
                T key = collection[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && Comparer<T>.Default.Compare(collection[j], key) > 0)
                {
                    collection[j + 1] = collection[j];
                    j = j - 1;
                }
                collection[j + 1] = key;
            }
        }
    }
}
