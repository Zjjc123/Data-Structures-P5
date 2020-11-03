////////////////////////////////////////////////////////////////////////
//
// Unit 2, Lesson 1: Class Work
//
// Maximumal Sequence
//
// written by Jason Zhang
// Data Structures, Period 5
//
////////////////////////////////////////////////////////////////////////

using System;

namespace Lesson1ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Array Length (1 to infinity)");

            int arrayLength;

            while (!int.TryParse(Console.ReadLine(), out arrayLength) || arrayLength < 1)
            {
                Console.WriteLine("Invalid Input! Try Again!");
            }

            int[] sequence = new int[arrayLength];

            int maxlength = 0;
            int length = 1;
            int index = 0;
            int previous = 0;

            for (int i = 0; i < arrayLength; i++)
            {
                int element;
                Console.WriteLine("Enter element at index {0} below", i);
                while (!int.TryParse(Console.ReadLine(), out element))
                {
                    Console.WriteLine("Invalid Input! Try Again!");
                }
                if (i > 0)
                {
                    if (element > previous)
                    {
                        length++;
                    }
                    else
                    {
                        if (length > maxlength)
                        {
                            maxlength = length;
                            index = i - length - 1;
                        }
                        length = 1;
                    }
                }

                if (length > maxlength)
                {
                    maxlength = length;
                    index = i - length + 1;
                }

                previous = element;
                sequence[i] = element;
            }

            int[] subSequence = new int[maxlength];
            for (int i = 0; i < maxlength;  i++)
            {
                subSequence[i] = sequence[i + index];
            }

            Console.WriteLine("Maximum increasing integers is [" + string.Join(", ", subSequence) + "]");
            Console.ReadLine();
        }
    }
}
