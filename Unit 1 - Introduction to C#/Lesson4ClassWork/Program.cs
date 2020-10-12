using System;

namespace Lesson4ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Original Price");
            float price = float.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter Discount Percentage");
            float percentage = float.Parse(Console.ReadLine());

            Console.WriteLine("The Final Price is {0:C}", price - price * (percentage / 100));
            Console.ReadLine();
        }
    }
}
