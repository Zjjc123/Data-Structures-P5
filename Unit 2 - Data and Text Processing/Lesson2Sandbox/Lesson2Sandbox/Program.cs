using System;

namespace Lesson2Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] x = new int[4, 6];
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Console.Write($"{x[i, j]: F} ");
                }
                Console.WriteLine();
            }

            int[][] jagged2D = new int[4][];
            jagged2D[0] = new int[6];
            jagged2D[1] = new int[6];
            jagged2D[2] = new int[6];
            jagged2D[3] = new int[6];

            Console.ReadLine();
        }
    }
}
