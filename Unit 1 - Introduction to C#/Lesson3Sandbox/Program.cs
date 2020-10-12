using System;

namespace Lesson3Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            string smallPrimes;
            smallPrimes = String.Format("Prime numbers less than 10: {0}, {1}, {2}, {3}", 2, 3, 5, 7);
            Console.WriteLine(smallPrimes);

            string e1 = "Christine";
            string e2 = "Emma";
            string e3 = "Rian";
            string e4 = "Rohan";
            string e5 = "Jason";

            Console.WriteLine("{0, -20} {1}", "Name", "Awesomeness");
            Console.WriteLine("{0, -20} {1, 6}", e1, 100);
            Console.WriteLine("{0, -20} {1, 6}", e2, 100);
            Console.WriteLine("{0, -20} {1, 6}", e3, -40);
            Console.WriteLine("{0, -20} {1, 6}", e4, 0);
            Console.WriteLine("{0, -20} {1, 6}", e5, 9999);
            Console.WriteLine("{0, -20} {1, 6:x}", e5, 9999);

            DateTime now = DateTime.Now;

            Console.Beep(544, 1000);
            Console.WriteLine(now);

            Console.Read();
        }
    }
}
