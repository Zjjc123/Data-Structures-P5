using System;

namespace Lesson1ExitTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Length of the first array");
            int l1;
            while (!int.TryParse(Console.ReadLine(), out l1) || l1 < 0)
            {
                Console.WriteLine("Invalid Number!");
            }

            Console.WriteLine("Length of the second array");
            int l2;
            while (!int.TryParse(Console.ReadLine(), out l2) || l2 < 0)
            {
                Console.WriteLine("Invalid Number!");
            }

            int big = l1 > l2 ? l1 : l2;
            int small = l1 < l2 ? l1 : l2;

            int[] a1 = new int[big];
            int[] a2 = new int[big];

            for (int i = 0; i < l1; i++)
            {
                int element;
                Console.WriteLine("Enter array 1 element at index {0} below", i);
                while (!int.TryParse(Console.ReadLine(), out element))
                {
                    Console.WriteLine("Invalid Input! Try Again!");
                }
                a1[i] = element;
            }

            for (int i = 0; i < l2; i++)
            {
                int element;
                Console.WriteLine("Enter array 2 element at index {0} below", i);
                while (!int.TryParse(Console.ReadLine(), out element))
                {
                    Console.WriteLine("Invalid Input! Try Again!");
                }
                a2[i] = element;
            }

            int[] sum = new int[big];

            for (int i = 0; i < big; i++)
            {
                if (i >= small)
                {
                    if (l1 > l2)
                    {
                        a2[i] = a2[(i - l2) % l2];
                    }
                    else
                    {
                        a1[i] = a1[(i - l1) % l1];
                    }
                }
                sum[i] = a1[i] + a2[i];
            }

            Console.WriteLine(string.Join(", ", a1));
            Console.WriteLine(string.Join(", ", a2));
            Console.WriteLine(string.Join(", ", sum));
            Console.ReadLine();
        }
    }
}
