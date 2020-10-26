using System;

namespace Lesson6ExitTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number from [0...999]");
            int num;
            
            while (!int.TryParse(Console.ReadLine(), out num) || num > 999 || num < 0)
            {
                Console.WriteLine("Invalid Number!");
                Console.WriteLine("Please enter a number from [0...999]");

            }

            int hund = num / 100;
            int tens = num % 100 / 10;
            int ones = num % 10;

            string output = "";

            if (hund > 0)
            {
                output += SingleDigitConvert(hund);
                output += " hundred ";
            }

            switch (tens)
            {
                case 1:
                    switch (ones)
                    {
                        case 0:
                            output += "ten";
                            break;
                        case 1:
                            output += "eleven";
                            break;
                        case 2:
                            output += "twelve";
                            break;
                        case 3:
                            output += "thirteen";
                            break;
                        case 4:
                            output += "fourteen";
                            break;
                        case 5:
                            output += "fifteen";
                            break;
                        case 6:
                            output += "sixteen";
                            break;
                        case 7:
                            output += "seventeen";
                            break;
                        case 8:
                            output += "eighteen";
                            break;
                        case 9:
                            output += "ninteen";
                            break;
                    }
                    break;
                case 2:
                    output += "twenty";
                    break;
                case 3:
                    output += "thirty";
                    break;
                case 4:
                    output += "fourty";
                    break;
                case 5:
                    output += "fifty";
                    break;
                case 6:
                    output += "sixty";
                    break;
                case 7:
                    output += "seventy";
                    break;
                case 8:
                    output += "eighty";
                    break;
                case 9:
                    output += "ninty";
                    break;
            }

            if (tens > 1 && ones > 0)
            {
                output += " " + SingleDigitConvert(ones);
            }
            if (tens == 0 && ones != 0)
            {
                output += SingleDigitConvert(ones);
            }
            if (hund == 0 && tens == 0 && ones == 0)
            {
                output = "zero";
            }
            Console.WriteLine("Your Output is: " + output);
            Console.ReadLine();
        }

        static string SingleDigitConvert(int digit)
        {
            string result;
            switch (digit)
            {
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
                default:
                    result = "null";
                    break;
            }
            return result;
        }
    }
}
