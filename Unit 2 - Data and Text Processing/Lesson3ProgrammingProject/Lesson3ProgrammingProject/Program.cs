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

                Console.Clear();

                switch (pick)
                {
                    case 7:
                        exit = true;
                        break;
                    case 1:
                        Console.WriteLine("Mortgage Monthly Payment Calculator\n");
                        int amountBorrowed = GetUserInteger("Amount borrowed (in dollars)");
                        int termsOfMortgage = GetUserInteger("Term of mortgage (in years)");
                        int yearlyInterestRate = GetUserInteger("Yearly interest rate (as a percentage)");

                        MortgageMonthlyPaymentCalculator(amountBorrowed, termsOfMortgage, yearlyInterestRate);
                        break;
                    case 2:
                        Console.WriteLine("Remaining Mortgage Loan Balance Calculator\n");
                        int amountBorrowed2 = GetUserInteger("Amount borrowed (in dollars)");
                        int termsOfMortgage2 = GetUserInteger("Term of mortgage (in years)");
                        int yearlyInterestRate2 = GetUserInteger("Yearly interest rate (as a percentage)");
                        int numberOfMonthpyPaymentsPaid2 = GetUserInteger("Number of monthly payments paid");
                        RemainingMortgageLoanBalanceCalculator(amountBorrowed2, termsOfMortgage2, yearlyInterestRate2, numberOfMonthpyPaymentsPaid2);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }

                if (pick != 7)
                    WaitToContinue();

                Console.Clear();
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
        static void WaitToContinue()
        {
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadLine();
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

        static void RemainingMortgageLoanBalanceCalculator(int p, int n, int r, int m)
        {
            double rate = r / 100.0 / 12;
            double months = n * 12;
            double remainingMortgagePayment = p * ((Math.Pow(1 + rate, months) - Math.Pow(1 + rate, m)) / (Math.Pow(1 + rate, months) - 1));

            Console.WriteLine("Remaining Mortgage Payment:     {0,20:c}", remainingMortgagePayment);
        }
        
    }
}