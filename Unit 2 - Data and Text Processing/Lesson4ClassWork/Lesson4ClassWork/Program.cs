using System;

namespace Lesson4ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Sum to n: " + Sum(10));
            Console.WriteLine("Factorial to n: " + Factorial(10));
            Console.ReadLine();
        }

        static int Sum(int n)
        {
            if (n == 1)
                return 1;
            return n + Sum(n - 1);
        }

        static int Factorial(int n)
        {
            if (n == 1)
                return 1;
            return n * Factorial(n - 1);
        }

        static int Fibonacci(int n)
        {
            if (n == 1)
                return 1;
            return Fibonacci(n) + Fibonacci(n - 1);
        }
    }
}
