using System.Collections.ObjectModel;

namespace OOP_Exam
{
    public class RadixSort
    {
        public static Collection<int> Sort(Collection<int> colllection)
        {
            int n = colllection.Count;
            // Find the maximum number to know number of digits  
            int m = getMax(colllection, n);

            // Do counting sort for every digit. Note that instead  
            // of passing digit number, exp is passed. exp is 10^i  
            // where i is current digit number  
            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(colllection, n, exp);

            return colllection;
        }
        private static int getMax(Collection<int> collection, int n)
        {
            int mx = collection[0];
            for (int i = 1; i < n; i++)
                if (collection[i] > mx)
                    mx = collection[i];
            return mx;
        }

        private static void countSort(Collection<int> collection, int n, int exp)
        {
            int[] output = new int[n]; // output array  
            int i;
            int[] count = new int[10];

            //initializing all elements of count to 0 
            for (i = 0; i < 10; i++)
                count[i] = 0;

            // Store count of occurrences in count[]  
            for (i = 0; i < n; i++)
                count[(collection[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual  
            //  position of this digit in output[]  
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array  
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(collection[i] / exp) % 10] - 1] = collection[i];
                count[(collection[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now  
            // contains sorted numbers according to current digit  
            for (i = 0; i < n; i++)
                collection[i] = output[i];
        }
    }
}
