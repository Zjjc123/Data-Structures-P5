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

                        int[] info = GetMorgageInfo();
                        
                        MortgageMonthlyPaymentCalculator(info[0], info[1], info[2]);
                        break;
                    case 2:
                        Console.WriteLine("Remaining Mortgage Loan Balance Calculator\n");

                        int[] info2 = GetMorgageInfo();

                        int numberOfMonthpyPaymentsPaid = GetUserInteger("Number of monthly payments paid");

                        Console.WriteLine("Remaining Mortgage Payment: {0,20:c}", RemainingMortgageLoanBalanceCalculator(info2[0], info2[1], info2[2], numberOfMonthpyPaymentsPaid)[0]);
                        Console.WriteLine("Interest Paid: {0,20:c}", RemainingMortgageLoanBalanceCalculator(info2[0], info2[1], info2[2], numberOfMonthpyPaymentsPaid)[1]);
                        break;
                    case 3:
                        Console.WriteLine("Remaining Mortgage Loan Balance Calculator\n");

                        int[] info3 = GetMorgageInfo();

                        YearlyStatus[] remainingList = RemainingMortgageLoanBalanceYearlyReport(info3[0], info3[1], info3[2]);
                        Console.WriteLine("          Balance Remaining          Total Amount Paid          Total Interest Paid");
                        for (int i = 0; i < info3[1]; i++)
                        {
                            Console.WriteLine("Year {0,2} {1,19:C} {2,25:C} {3,27:C}", i + 1, remainingList[i].remainingMortgagePayment, remainingList[i].totalAmountPaid, remainingList[i].totalInterestPaid);
                            Console.WriteLine();
                        }
                        
                        break;
                    case 4:
                        Console.WriteLine("Remaining Mortgage Loan Balance Calculator\n");
                        int presentValue = GetUserInteger("Present value of the asset (in dollars)");
                        int termsOfInvestment = GetUserInteger("Term of investment period (in years)");
                        int estimatedYearlyInterest = GetUserInteger("Estimated yearly interest rate (as a percentage)");

                        double FV = FutureValueOfAFixedAsset(presentValue, termsOfInvestment, estimatedYearlyInterest);
                        Console.WriteLine("Future Value of Asset: {0,20:c}", FV);
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

        static int[] GetMorgageInfo()
        {
            int amountBorrowed = GetUserInteger("Amount borrowed (in dollars)");
            int termsOfMortgage = GetUserInteger("Term of mortgage (in years)");
            int yearlyInterestRate = GetUserInteger("Yearly interest rate (as a percentage)");

            int[] result = { amountBorrowed, termsOfMortgage, yearlyInterestRate };
            return result;
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

        static double[] RemainingMortgageLoanBalanceCalculator(int p, int n, int r, int m)
        {
            double rate = r / 100.0 / 12;
            double months = n * 12;
            double remainingMortgagePayment = p * ((Math.Pow(1 + rate, months) - Math.Pow(1 + rate, m)) / (Math.Pow(1 + rate, months) - 1));
            double monthlyMortgageAmount = p * (rate * Math.Pow(1 + rate, months) / (Math.Pow(1 + rate, months) - 1));

            double[] result = new double[2];
            result[0] = remainingMortgagePayment;
            result[1] = monthlyMortgageAmount * m + remainingMortgagePayment - p;
            return result;
        }
        
        static YearlyStatus[] RemainingMortgageLoanBalanceYearlyReport(int p, int n, int r)
        {
            double rate = r / 100.0 / 12;
            double months = n * 12;

            YearlyStatus[] result = new YearlyStatus[n];

            for (int i = 1; i <= n; i++)
            {
                int m = i * 12;

                double monthlyMortgageAmount = p * (rate * Math.Pow(1 + rate, months) / (Math.Pow(1 + rate, months) - 1));
                double t = monthlyMortgageAmount *  m;
                double[] rM = RemainingMortgageLoanBalanceCalculator(p, n, r, m);

                result[i - 1] = new YearlyStatus
                {
                    remainingMortgagePayment = rM[0],
                    totalAmountPaid = t,
                    totalInterestPaid = rM[1]
                };
            }
            
            return result;
        }

        static double FutureValueOfAFixedAsset(int PV, int n, int r)
        {
            double rate = r / 100.0 / 12;
            double months = n * 12;
            double FV = PV * Math.Pow(1 + rate, months);
            return FV;
        }

        static double RetirementAccountValueEstimation(int c, int n, int r)
        {
            return 0.0;
        }

    }

    struct YearlyStatus
    {
        public double remainingMortgagePayment;
        public double totalAmountPaid;
        public double totalInterestPaid;
    }
}