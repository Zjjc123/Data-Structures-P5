using System;

namespace Lesson1SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            byte centuries = 20;
            System.Byte millenia = 2;
            ushort years = 2000;
            System.UInt16 decade = 10;
            uint days = 730490;
            ulong hours = 17531520;

            Console.WriteLine(centuries + " centuries are " +
                years + " years, or " +
                days + " days, or " +
                hours + " hours.");


            float floatPI = 3.141592653589793238f; // needs the f
            double doublePI = 3.141592653589793238; // doesn't need the f
            Console.Out.WriteLine("System.Single PI is " + floatPI);
            Console.Out.WriteLine("System.Double PI is " + doublePI);

            float zeroPointOneFloat = 0.1f;
            double zeroPointOneDouble = zeroPointOneFloat;
            decimal zeroPointOneDecimal = (decimal)zeroPointOneFloat; //decimal types must be cast from double/float

            Console.Out.WriteLine(zeroPointOneFloat);
            Console.Out.WriteLine(zeroPointOneDouble);
            Console.Out.WriteLine(zeroPointOneDecimal);

            Nullable<bool> testResult = null;
            Console.WriteLine("Has the test been administered? " + testResult.HasValue);

            // Integer Variables and Literals
            int fourteen = 14;
            short sixteen = 0x10;
            byte eighteen = 0b0001_0010;
            Console.WriteLine("The numbers are {0} {1} {2}", fourteen, sixteen, eighteen);
            ulong speedOfLight = 299792458uL;
            Console.WriteLine("Speed of light: " + speedOfLight);

            Console.Read();
        }
    }
}
