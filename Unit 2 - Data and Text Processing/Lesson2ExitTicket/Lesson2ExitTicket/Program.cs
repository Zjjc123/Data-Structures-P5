using System;

namespace Lesson2ExitTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter square array size");
            int s;
            while (!int.TryParse(Console.ReadLine(), out s) || s <= 1)
            {
                Console.WriteLine("Invalid Number!");
            }

            int[,] square = new int[s, s];
            for (int i = 0; i < square.GetLength(0); i++)
            {
                Console.WriteLine("Enter {0} Row", i + 1);
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    int.TryParse(Console.ReadLine(), out square[i, j]);
                }
            }

            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    Console.Write($"{square[i, j]} ");
                }
                Console.WriteLine();
            }

            int[] checkSums = new int[2 * s + 2];

            int diagonal = 0;
            int diagonal2 = 0;

            for (int i = 0; i < square.GetLength(0); i++)
            {
                diagonal += square[i, i];
            }
            for (int i = 0; i < square.GetLength(0); i++)
            {
                diagonal2 += square[i, s - i - 1];
            }
            
            for (int i = 0; i < square.GetLength(0); i++)
            {
                int currentRow = 0;
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    currentRow += square[i, j];
                }
                checkSums[i] = currentRow;

                Console.WriteLine("Row: {0}", currentRow);
            }

            for (int i = 0; i < square.GetLength(0); i++)
            {
                int currentColumn = 0;
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    currentColumn += square[j, i];
                }
                checkSums[s + i] = currentColumn;

                Console.WriteLine("Column: {0}", currentColumn);
            }

            Console.WriteLine("Diagonal: {0}", diagonal);
            Console.WriteLine("Diagonal: {0}", diagonal2);
          
            checkSums[checkSums.Length - 1] = diagonal;
            checkSums[checkSums.Length - 2] = diagonal2;

            Console.WriteLine(string.Join(", ", checkSums));

            bool isMagic = true;

            for (int i = 1; i < checkSums.Length; i++)
            {
                Console.WriteLine(checkSums[i] + " --> " + checkSums[i-1]);
                if (checkSums[i] != checkSums[i - 1])
                {
                    Console.WriteLine(checkSums[i]);
                    isMagic = false;
                    break;
                }
            }

            Console.WriteLine("Magic Square: " + isMagic);
            
            Console.ReadLine();
        }
    }
}
