using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("I am thinking of 4 numbers, guess what they are");
                Game newGame = new Game();
                string Guess = string.Empty;
                string Difficulty = string.Empty;
                
                Console.WriteLine("1 - Easy (10 turns)");
                Console.WriteLine("2 - Hard (5 turns)");
                Console.WriteLine("3 - Extra Hard (3 turns)");
                while (Difficulty != "1" && Difficulty != "2" && Difficulty != "3")
                {
                    Console.WriteLine("Please Select Difficulty between 1 and 3:");
                    Difficulty = Console.ReadLine();
                }


                Console.WriteLine("+++++++++++++++++++++++++++++++");
                Console.WriteLine("-------------------------------");
                switch (Difficulty)
                {
                    case "1":
                        Console.WriteLine("Welcome to Easy Mode, you get 10 turns");
                        break;
                    case "2":
                        Console.WriteLine("Welcome to Hard Mode, you get 5 turns");
                        break;
                    default:
                        Console.WriteLine("Welcome to Extra Hard Mode, you get 3 turns");
                        break;
                }
                
                newGame.SetDifficulty(Difficulty);
                
                while (newGame.NumberOfTurns > 0)
                {
                    if (newGame.NumberOfTurns <= 3 && newGame.NumberOfTurns > 1)
                        Console.WriteLine("Only " + newGame.NumberOfTurns.ToString() + " turns left!");
                    if (newGame.NumberOfTurns == 1)
                        Console.WriteLine("Last turn!");

                    Console.WriteLine("Please enter 4 numbers between 1 and 6:");
                    Guess = Console.ReadLine();

                    if (Guess.Length != 4 || !Guess.All(char.IsDigit))
                    { Console.WriteLine("Please enter a string of 4 numeric characters only!"); }
                    else
                    {
                        Console.WriteLine(newGame.TakeGuess(Guess));
                        if (newGame.WonGame)
                            break;
                        else
                            newGame.NumberOfTurns -= 1;
                    }
                }

                if (newGame.WonGame)
                    Console.WriteLine("Congrats!!!! the string was " + newGame.ActualValue);
                else
                    Console.WriteLine("You Lose, the actual value was " + newGame.ActualValue);

                Console.Read();
            }
        }



    }

}
