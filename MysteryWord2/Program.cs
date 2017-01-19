//Method to check entire word taken from http://stackoverflow.com/questions/20943040/hangman-array-c-sharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program

    {

        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines(@"..\..\words.txt");
            var rng = new Random();
            int randomNumber = rng.Next(words.Length);
            var hiddenWord = words[randomNumber]; //gets random word from list
            int letterCount = hiddenWord.Length; //determines spaces
            int livesLeft = 8;      //guesses left
            string guessed = "";
            bool winner = false;
            char[] blankWord = new char[letterCount]; //new array with starred out letter
            for (int i = 0; i < letterCount; i++)
            {
                blankWord[i] = '*';
            }

            while (livesLeft > 0 && winner == false)
            {
                bool noMatch = true;

                Console.WriteLine("==============================================================================");
                Console.WriteLine($"The word has {letterCount} letters, you have {livesLeft} lives left!");
                Console.WriteLine();
                Console.WriteLine($"So far you have guessed:  {guessed}");
                Console.WriteLine();
                Console.WriteLine(blankWord);

                var tmpGuess = Console.ReadLine().ToLower(); //gets guess and turns it into lowercase
                char guess = tmpGuess.ToArray()[0]; //turns the string into char

                /*if (tmpGuess.Length != 1)
                {
                   Console.Writeline("Only 1 letter allowed"); 
                }
                else
                */

                if (guessed.Contains<char>(guess)) // checks for duplicate guess
                {
                    Console.Clear();
                    Console.WriteLine("You have already guessed this. Guess again");

                }
                else
                {
                    guessed += $"{guess}, ";


                    for (int i = 0; i < letterCount; i++) //checks word for guess
                    {
                        if (hiddenWord[i] == guess) //guess matches word
                        {
                            blankWord[i] = guess; //changes blank to letter guessed                                            
                            noMatch = false;
                        }
                    }

                    if (noMatch == true) //guess is not in word
                    {
                        Console.Clear();
                        Console.WriteLine("No Luck. Guess again");
                        livesLeft--;
                    }

                    if (livesLeft == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Out of lives. You killed the poor man");
                        Console.WriteLine($"The word was {hiddenWord}");
                        Console.ReadLine();
                    }

                    if (blankWord.Contains<char>('*')) //Thanks for the logic help Joel!
                    {
                        winner = false;
                    }

                    else
                    {
                        winner = true;
                        Console.WriteLine($"Congrats! You Win!!! The word was {hiddenWord}");
                    }
                }

            }


        }
    }
}