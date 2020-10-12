using System;
using System.Text;

namespace Lesson2Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            byte bits = 200;
            Console.WriteLine("200 = " + BinaryStringConvert(bits));
            bits += 56;
            Console.WriteLine("200 = " + BinaryStringConvert(bits));

            byte a = 0b0000_0011; // 3
            byte b = 0b0000_0101; // 5

            Console.WriteLine("a = " + BinaryStringConvert(a));
            Console.WriteLine("b = " + BinaryStringConvert(b));

            // XOR all bits
            Console.WriteLine("a^b = " + BinaryStringConvert((byte)(a^b)));

            // Invert all bits
            Console.WriteLine("~a = " + BinaryStringConvert((byte)~a));
            Console.WriteLine("~b = " + BinaryStringConvert((byte)~b));

            // Swap
            a = (byte)(a ^ b);
            b = (byte)(b ^ a);
            a = (byte)(a ^ b);

            Console.WriteLine("a = " + BinaryStringConvert(a));
            Console.WriteLine("b = " + BinaryStringConvert(b));

            // Getting a bit from an integer
            int flags = 0b0000_0000_0000_0000_1000_0000_0000_0000;
            int position = 15;
            flags >>= position;
            int final = flags & 1;
            Console.WriteLine("Bit at position {0} is {1}", position, final);

            // Setting a bit at position to 1
            flags = 0b0000_0000_0000_0000_1000_0000_0000_0000;
            position = 17;
            int one = 1 << position;
            final = flags | one;
            Console.WriteLine("Flag is now {0}", Convert.ToString(final, 2));

            Console.Read();
        }

        public static String BinaryStringConvert(byte b)
        {
            StringBuilder str = new StringBuilder(8);
            int[] bl = new int[8];

            for (int i = 0; i < bl.Length; i++)
            {
                bl[bl.Length - 1 - i] = ((b & (1 << i)) != 0) ? 1 : 0;
            }

            foreach (int num in bl) str.Append(num);

            return str.ToString();
        }
    }
}
