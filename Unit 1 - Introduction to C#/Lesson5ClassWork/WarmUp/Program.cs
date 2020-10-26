using System;

namespace WarmUp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter first integer!");
                int x = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second integer!");
                int y = int.Parse(Console.ReadLine());

                Console.WriteLine("Addition: {0}", x + y);
                Console.WriteLine("Subtraction: {0}", x - y);
                Console.WriteLine("Multiplication: {0}", x * y);
                Console.WriteLine("Division: {0}", x / y);
                Console.WriteLine("Modular: {0}", x % y);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Cannot divide by 0");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input value is not an integer");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine();
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Overflow Value");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}
