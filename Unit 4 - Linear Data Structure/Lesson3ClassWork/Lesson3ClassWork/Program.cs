using System;
using System.Collections.Generic;

namespace Lesson3ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NodeBasedList<int> list = new NodeBasedList<int>();
            list.Add(1);
            list.Add(10);
            list.Add(100);
            Console.WriteLine($"list = {list}");
            foreach (int i in list)
            {
                Console.WriteLine($"value = {i}");
            }
            Console.WriteLine();

            list[0] = 2;
            Console.WriteLine($"list = {list}");

            IEnumerable<int> elist = list;
            Console.WriteLine("elist = " + list);

            Console.ReadLine();
        }
    }
}
