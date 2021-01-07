using System;
namespace Lesson1ClassWork
{
    ////////////////////////////////////////////////////////
    // TODO: declare a enumerated type named "SlotSymbol" 
    // that inclues the following symbols:
    //
    // Wild, Lemon, Grape, Orange, Cherry, Bell, Bar, Seven

    enum SlotSymbol
    {
        Wild, Lemon, Grape, Orange, Cherry, Bell, Bar, Seven
    }

    ////////////////////////////////////////////////////////
    // TODO: declare a struct name "SlotMachine" that 
    // includes the following fields:
    //
    // a SlotSymbol type named "slot1"
    // a SlotSymbol type named "slot2"
    // a SlotSymbol type named "slot3"
    // a int type named "credits"

    struct SlotMachine
    {
        public SlotSymbol slot1;
        public SlotSymbol slot2;
        public SlotSymbol slot3;
        public int credits;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////
            // TODO: initialize a new SlotMachine object and set its
            // credits to 1000.  create a "balance" variable for the
            // player and set its initial value to 10.

            SlotMachine machine;
            machine.credits = 1000;

            int balance = 10;

            ////////////////////////////////////////////////////////
            // TODO: create a sentinel loop to play a virtual slot 
            // machine.  the player can continue playing until the 
            // player is out of credits or types the sentinel value.
            //
            // during each iteration of the loop, prompt the user 
            // for a bet (that must be an integer value greater than
            // zero but less than the player "balance"), randomly 
            // generate values for each of the slots, then collect
            // any winnings.
            //
            // To choose a random value from an enumerated type, 
            // consider the following four lines of code:
            //
            // int numSymbols = Enum.GetNames(typeof(SlotSymbol)).Length;
            // machine.slot1 = (SlotSymbol)r.Next(numSymbols);
            // machine.slot2 = (SlotSymbol)r.Next(numSymbols);
            // machine.slot3 = (SlotSymbol)r.Next(numSymbols);
            //
            // where "r" is a variable of "Random" type that was 
            // instantiated before entering the sentinel loop.
            //
            // The winnings will be calculated by a Payout() method
            // and added to the player balance and deducted from the
            // machine's credits.  If the slot machine's credits 
            // fall below 500, increase the credits back to 1000.
            int bet = 0;
            Random r = new Random();
            do
            {
                bet = GetUserInteger("Enter Bet: ");
                
                if (!(bet < 0 || bet > balance))
                {
                    int numSymbols = Enum.GetNames(typeof(SlotSymbol)).Length;
                    machine.slot1 = (SlotSymbol)r.Next(numSymbols);
                    machine.slot2 = (SlotSymbol)r.Next(numSymbols);
                    machine.slot3 = (SlotSymbol)r.Next(numSymbols);

                    balance -= bet;
                    int payout = bet * Payout(machine.slot1, machine.slot2, machine.slot3);
                    balance += payout;

                    Console.WriteLine("Payout: {0:c}", payout);
                    Console.WriteLine("Remaining balance: {0:c}", balance);
                } else
                {
                    if (bet != -1)
                    {
                        Console.WriteLine("Enter valid bet from greater than 0 to less than balance!");
                    }
                }
            } while (bet != -1);
            ////////////////////////////////////////////////////////
            // TODO: show the player's closing balance
            Console.WriteLine("Game Exited");
            Console.WriteLine("Final balance: {0:c}", balance);

            Console.Out.WriteLine("Hit enter key to close...");
            Console.In.ReadLine();
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

        ////////////////////////////////////////////////////////
        // TODO: write a method to calculate the payout.  the 
        // payout is determined by the following rules:
        //
        // if all three symbols match, the payout is equal to 
        // the value of the symbol raised to the 3rd power
        //
        // if two of the three symbols match, the payout is equal
        // to the value of the symbol 
        //
        // the "Wild" symbol matches all other symbols
        public static int Payout(SlotSymbol s1, SlotSymbol s2, SlotSymbol s3)
        {
            int num1 = (int)s1;
            int num2 = (int)s2;
            int num3 = (int)s3;

            int[] slots = { num1, num2, num3 };

            int max = Math.Max(Math.Max(num1, num2), num3);

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == 0)
                {
                    slots[i] = max;
                }
            }

            if (slots[0] == slots[1] && slots[1] != slots[2])
            {
                return slots[0];
            }

            if (slots[1] == slots[2] && slots[1] != slots[0])
            {
                return slots[1];
            }

            if (slots[0] == slots[2] && slots[0] != slots[1])
            {
                return slots[2];
            }

            if (slots[0] == slots[1] && slots[1] == slots[2])
            {
                return (int)Math.Pow(slots[0], 3);
            }

            return 0;
        }
    }
}