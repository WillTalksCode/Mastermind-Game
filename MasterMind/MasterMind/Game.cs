using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class Game
    {
        private List<int> Numbers;
        public int NumberOfTurns;
        public bool WonGame;
        public string ActualValue;
        public Game() //Call constructor to start new game
        {
            ActualValue = String.Empty;
            WonGame = false;
            NumberOfTurns = 10;
            Random rnd = new Random();
            Numbers = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                int nextNumber = rnd.Next(1, 7);
                Numbers.Add(nextNumber);
                ActualValue += nextNumber.ToString();
            }
        }

        public void SetDifficulty(string difficulty)
        {
            switch(difficulty)
            {
                case "1":
                    NumberOfTurns = 10;
                    break;
                case "2":
                    NumberOfTurns = 5;
                    break;
                default:
                    NumberOfTurns = 3;
                    break;
            }
        }

        public string TakeGuess(string Guess)
        {
            bool WonThisTime = true;
            string result = String.Empty;
            List<char> GuessList = Guess.ToCharArray().ToList<char>();
            List<int> GuessIntList = new List<int>();
            foreach(char c in GuessList)
            {
                GuessIntList.Add((int)c - '0');
            }

            for (int i=0; i< GuessIntList.Count(); i++)
            {
                if (GuessIntList[i] != Numbers[i] && !Numbers.Contains(GuessIntList[i])) //If number in the spot isn't right and list doesn't contain the number leave a blank
                {
                    WonThisTime = false;
                    result += " ";
                }
                else if (GuessIntList[i] != Numbers[i] && Numbers.Contains(GuessIntList[i])) //if the number is in the list but the guess isn't in the right spor leave a dash
                {
                    WonThisTime = false;
                    result += "-";
                }
                else //Number is in the list and in the right spot
                    result += "+";
            }
            WonGame = WonThisTime;
            return result;
        }


        


    }
}
