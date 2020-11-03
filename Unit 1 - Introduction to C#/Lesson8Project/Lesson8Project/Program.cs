////////////////////////////////////////////////////////////////////////
//
// Unit 1, Lesson 8: Programming Project
//
// Random Number Guessing Game
//
// written by Jason Zhang
// Data Structures, Period 5
//
////////////////////////////////////////////////////////////////////////

using System;

namespace Lesson8ProgrammingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an application that generates a random number
            // from 1 to 1000 and asks the user what the number is.
            // If the user's guess is too high or too low, the 
            // program should display an appropriate message, such 
            // as "Too high" or "Too low".  However, if the guess
            // is within 10, then the program should simply state
            // that the user is "getting warmer".  If the user 
            // guesses the number, congratulate the user and ask 
            // if the user would like to play again.  If the user
            // cannot guess the number with 10 or 12 tries, the 
            // game ends without the congratulatory message but 
            // the user is still prompted to play again.
            //
            // The game should keep certain statistics about the 
            // session, including:
            //
            //    session win-loss record
            //    session fastest time to solve
            //    session minimum number of tries to solve
            //
            // This information should be displayed after each 
            // game ends.  

            Random r = new Random();
            int rand = r.Next(1, 1000);
            Console.WriteLine("Please Guess a Number from (1-1000)");

            int guess = 0;

            while (guess != rand)
            {
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Invalid Input! Try Again!");
                }
                if (guess > rand)
                {
                    Console.WriteLine("Too high!");
                }
                if (guess < rand)
                {
                    Console.WriteLine("Too low!");
                }
            }
            Console.WriteLine("Good Job! You Got It!");
            Console.ReadLine();
        }
    }
}
