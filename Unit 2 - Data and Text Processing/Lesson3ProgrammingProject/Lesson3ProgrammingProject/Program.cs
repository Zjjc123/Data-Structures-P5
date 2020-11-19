////////////////////////////////////////////////////////////////////////
//
// Unit 2, Lesson 3: Programming Project
//
// Financial Planning Options
//
// written by {$NAME}
// Data Structures, Period {$PERIOD}
//
////////////////////////////////////////////////////////////////////////

using System;

namespace Lesson3ProgrammingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            
            while (!exit)
            {
                int pick = 0;

                Console.WriteLine(
                    "   1. Mortgage Monthly Payment Calculator\r\n" +
                    "   2. Remaining Mortgage Loan Balance Calculator\r\n" +
                    "   3. Remaining Mortgage Loan Balance Yearly Report\r\n" +
                    "   4. Future Value of a Fixed Asset\r\n" +
                    "   5. Retirement Account Value Estimate\r\n" +
                    "   6. Retirement Account Value Yearly Report\r\n" +
                    "   7. Exit\r\n");

                Console.WriteLine("Enter Option Below...");

                while (!int.TryParse(Console.ReadLine(), out pick) || pick < 1 || pick > 7)
                {
                    Console.WriteLine("Invalid Number!");
                }

                switch (pick)
                {
                    case 1:
                        int amountBorrowed = GetUserInteger("Amount borrowed (in dollars)");
                        int termsOfMortgage = GetUserInteger("Term of mortgage (in years)");
                        int yearlyInterestRate = GetUserInteger("Yearly interest rate (as a percentage)");

                        MortgageMonthlyPaymentCalculator(amountBorrowed, termsOfMortgage, yearlyInterestRate);

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        exit = true;
                        break;
                }
            }

            Console.WriteLine("Hello World!");
        }

        static int GetUserInteger(string prompt)
        {
            int i = 0;

            Console.WriteLine(prompt);

            while (!int.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Invalid Number!");
            }

            return i;
        }

        static void MortgageMonthlyPaymentCalculator(int p, int n, int r)
        {
            double rate = r / 100.0 / 12;
            double months = n * 12;
            double monthlyMortgageAmount = p * (rate * Math.Pow(1 + rate, months) / (Math.Pow(1 + rate, months) - 1));
            double totalAmountPaid = monthlyMortgageAmount * n * 12;
            double totalInterestPaid = totalAmountPaid - p;

            Console.WriteLine("Monthly Mortgage Amount: {0,20:c}", monthlyMortgageAmount);
            Console.WriteLine("Total Amount Paid:       {0,20:c}", totalAmountPaid);
            Console.WriteLine("Total Interest Paid:     {0,20:c}", totalInterestPaid);
            Console.WriteLine();
        }
        
    }
}