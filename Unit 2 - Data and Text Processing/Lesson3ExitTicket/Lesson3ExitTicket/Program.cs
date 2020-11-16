using System;

namespace Lesson3ExitTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size");
            int s;
            while (!int.TryParse(Console.ReadLine(), out s) || s <= 1)
            {
                Console.WriteLine("Invalid Number!");
            }

            int[] numArray = new int[s];

            for (int i = 0; i < s; i++)
            {
                Console.WriteLine("Enter [{0}] number", i);
                while (!int.TryParse(Console.ReadLine(), out numArray[i]))
                {
                    Console.WriteLine("Invalid Number!");
                }
            }
            Console.WriteLine(string.Join(", ", numArray));
            MergeSort(numArray, 0, numArray.Length - 1);
            Console.WriteLine(string.Join(", ", numArray));
            sort(numArray, 0, numArray.Length - 1);
            Console.WriteLine(string.Join(", ", numArray));
            Console.ReadLine();
        }
        

        static void merge(int[] arr, int l, int m, int r)
        {
            // Find size of both array
            int s1 = m - l + 1;
            int s2 = r - m;

            // Create temporary arrays
            int[] L = new int[s1];
            int[] R = new int[s2];

            // Copy into temporary arrays
            for (int i = 0; i < s1; i++)
            {
                L[i] = arr[l + i];
            }
            for (int i = 0; i < s2; i++)
            {
                R[i] = arr[m + i + 1];
            }

            Console.WriteLine("Left: " + string.Join(", ", L));
            Console.WriteLine("Right: " + string.Join(", ", R));


            // Keep track of progress on each array
            int li = 0;
            int ri = 0;

            // Starting at left side
            int k = l;
            while (li < s1 && ri < s2)
            {
                if (L[li] <= R[ri])
                {
                    arr[k] = L[li++];
                }
                else
                {
                    arr[k] = R[ri++];
                }
                k++;
            }

            // Fill in remaining numbers
            while (li < s1)
            {
                arr[k++] = L[li++];
            }

            while (ri < s2)
            {
                arr[k++] = R[ri++];
            }
        }

        static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find Middle
                int m = (l + r) / 2;

                // Sort Left Side
                MergeSort(arr, l, m);

                // Sort Right Side
                MergeSort(arr, m + 1, r);

                // Merge Both Sides
                merge(arr, l, m, r);
            }
        }



        static void merge2(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarry array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        static void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = (l + r) / 2;

                // Sort first and
                // second halves
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves
                merge2(arr, l, m, r);
            }
        }
    }
}
