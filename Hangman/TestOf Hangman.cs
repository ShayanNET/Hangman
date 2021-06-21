using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hangman
{
    class TestOf_Hangman
    {
        static void Main()
        {
            string UserInput = "";
            do
            {
                Console.WriteLine("");
                Console.WriteLine("---- Enter Command (1.Play with guess of Letter, 2. Play with guess Word or  99. Exit: -----)");
                UserInput = (Console.ReadLine() ?? "");

                switch (UserInput)
                {
                    case "1":
                        PlayerLetterGuess();
                        break;
                    case "2":
                        PlayerWordGuess();
                        break;
                    case "99":
                        break;
                }
            } while (UserInput != "99");

        } //End Main

        //----------------String Array to call-----------
        static string RollGame()
        {
            //Array of string
            string[] MyList = { "Shayan", "Malin", "Jimmy", "David", "Allen", "Louis", "Sammi" };
            Random r = new Random();

            // Randomly takes a word from our "Array list" & put in string variable Guess
            string Guess = MyList[r.Next(0, MyList.Length)];
            Console.WriteLine(Guess);
            return Guess;
        }

        //----------------Play method------------------
        static void PlayerLetterGuess()
        {
            string answer = RollGame();
            string WoGuessTOlower = answer.ToLower();

            StringBuilder displayToPlayer = new StringBuilder(answer.Length);
            for (int i = 0; i < answer.Length; i++)
                displayToPlayer.Append('-');

            //---lists---
            List<char> RightGuess = new List<char>();
            List<char> WrongGuess = new List<char>();
            char[] test2 = new char[answer.Length];

            // variables;
            char newInput;
            int lettersRevealed = 0;
            int lives = 10;
            bool won = false;

            while (!won && lives > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Enter a letter to guess for a {0} word ", answer.Length);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have {0} live", lives);

                string playerInput = Console.ReadLine().ToLower();
                newInput = playerInput[0];

                if (RightGuess.Contains(newInput))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You've already tried '{0}', and it was correct! ", newInput);
                    continue;
                }
                else if (WrongGuess.Contains(newInput))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You've already tried '{0}', and it was wrong! ", newInput);
                    continue;
                }
                if (WoGuessTOlower.Contains(newInput))
                {
                    RightGuess.Add(newInput);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Nice try");

                    for (int i = 0; i < answer.Length; i++)
                    {
                        if (WoGuessTOlower[i] == newInput)
                        {
                            displayToPlayer[i] = answer[i];
                            lettersRevealed++;
                        }
                    }
                    if (lettersRevealed == answer.Length)
                    {
                        won = true;
                    }
                }
                else
                {
                    WrongGuess.Add(newInput);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("No No, there's no '{0}' in it! ", newInput);
                    Console.ForegroundColor = ConsoleColor.Red;
                    lives--;
                }
                Console.WriteLine(displayToPlayer.ToString());
            }
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-----------------------\n");
                Console.WriteLine("Congratulations You won!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("You lost! It was '{0}'", answer);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
        //----------------------------Play with Word method------------------------------------------

        static void PlayerWordGuess()
        {
            string answer2 = RollGame();
            string wordGuessTOlower = answer2.ToLower();

            StringBuilder displayToPlayer = new StringBuilder(answer2.Length);

            //create two list to store wrong and wright elements

            List<string> RightGuess = new List<string>();
            List<string> WrongGuess = new List<string>();
            char[] test = new char[answer2.Length];

            //Variables
            int lives = 3;
            bool won = false;

            while (!won && lives > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------");
                Console.WriteLine("Enter a Word to guess for a {0} letter ", answer2.Length);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have {0} live", lives);
                string playerInput = Console.ReadLine().ToLower();

                //determine whether an element is in list-----
                if (RightGuess.Contains(playerInput))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" You've already tried,'{0}' and it was correct! ", playerInput);
                    continue;
                }
                else if (WrongGuess.Contains(playerInput))
                {
                    Console.WriteLine(" You've already tried '{0}', and it was not a word! ", playerInput);
                    continue;
                }
                else if (playerInput.Length != answer2.Length)
                {
                    WrongGuess.Add(playerInput);
                    Console.WriteLine(" Your input isn't a word or containing " + answer2.Length + " letter word! ");
                    lives--;
                    continue;
                }
                //-------------------------------------------------------
                if (wordGuessTOlower != playerInput)
                {
                    WrongGuess.Add(playerInput);
                    Console.WriteLine("Wrong Guess.... try again..");
                    lives--;
                }
                else if (wordGuessTOlower == playerInput)
                {
                    RightGuess.Add(playerInput);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Nice try");
                    Console.WriteLine("Congratulations You won!");
                    Console.ResetColor();
                    won = true;
                }
                Console.WriteLine(displayToPlayer.ToString());
            }
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-----------------------\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("You lost! It was '{0}'", answer2);
                Console.ResetColor();
            }
            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}