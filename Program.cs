using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
}

class Program
{
    // Guess, commenting just for highlighting purposes, (Player guess)
    public static void Guess(char[] charify, string secretWord)
    {
        int guessNum = 10;
        StringBuilder sb = new StringBuilder("", 10);

        Console.WriteLine("Guess the word, carefully...");
        // UnderscoreBuilder of secretWord
        for (int i = 0; i < secretWord.Length; i++)
        {
            charify[i] = '_';
        }
        while (guessNum > 0)
        {

            string? stringGuess = Convert.ToString(Console.ReadLine()).ToUpper();
            StringBuilder guess = new StringBuilder(stringGuess);
            if (guessNum <= stringGuess.Length)
            {
                Print("You lose");
            }


            int guessLength = stringGuess.Length;
            guessNum -= guessLength;
            Console.WriteLine($"You have {guessNum} number of guesses remaining, {guessLength} is the number of characters just used for this attempt");


            // Collector of wrong chars


            for (int j = 0; j < secretWord.Length; j++)
            {
                if (stringGuess == secretWord[j].ToString())
                {

                    charify[j] = Convert.ToChar(stringGuess);
                }
            }

            var sbToString = sb.ToString();
            if (stringGuess != secretWord || stringGuess.Contains(charify.ToString()))
            {
                Console.WriteLine("zigi");
            }
            string charified = new string(charify);
            Console.WriteLine(charified);

            if (stringGuess.Contains(secretWord, StringComparison.OrdinalIgnoreCase) || sbToString.Contains(secretWord, StringComparison.OrdinalIgnoreCase) || charified.Equals(secretWord) || stringGuess.Equals(secretWord))
            {
                Print("You win");
            }
            else
            {
                //TBA   
            }


        }
    }
    


    // Print (Print status, Print end result)
    public static void Print(string printArg)
    {
        switch (printArg)
        {
            case string a when printArg.Contains("You lose"):
                string text = "How about a(n)other game? Ahahahahahaha! :D\n(y or n)";
                Console.Clear();
                for (int i = 0; i < 3; i++)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine(" ~ You lose, hahaha! ~");
                    Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }
                Console.ReadKey();
                Console.Clear();
                Game(text);
                break;
            case string b when printArg.Contains("You win"):
                text = "You did well, how about giving it another go? :D\n(y or n)";
                Console.Clear();
                for (int i = 0; i < 3; i++)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine(" ~ You win, hahaha! ~");
                    Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }
                Console.ReadKey();
                Console.Clear();
                Game(text);
                break;
        }
        //Printa returns från spelet efter gissning. 
    }

    // Game, Main Menu for Game.
    static void Game(string text)
    {

        Console.WriteLine(text);


        char key = Console.ReadKey().KeyChar;
        switch (key)
        {
            case 'y':
            case 'Y':
                GetSecretWord();
                break;
            case 'n':
            case 'N':
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nIt's treason, then.");
                Console.ResetColor();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("\nNice try - I'll ask again! :D");
                Console.Clear();
                Game(text);
                break;
        }
    }

    // GetSecretWord, Randomizer ov hidden nouns is complete! (Initiate: Secret Word, Char array, Stringbuilder
    static void GetSecretWord()
    {
        Console.WriteLine("Randomizing secret word...");
        Random rando = new Random();
        var secretWordList = new string[10] { "Potato", "Gerpgork", "Tomato", "Cockatoo", "Bird", "Macaw", "Chocolate", "Book", "Cake", "Glasses", };
        int index = rando.Next(secretWordList.Count());
        //string randomString = secretWordList[index];
        //Console.WriteLine(($"The secret word is {secretWordList[index]}"));

        string secretWord = secretWordList[index].ToString().ToUpper();


        char[] charify = new char[secretWord.Length];
        

        Guess(charify, secretWord);
    }
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Welcome to Hangman!\nMade by Siavash Gosheh\nSaravasha on GitHub");
        string text = "How about a game? (y or n)";
        Console.ResetColor();
        Game(text);
    }
}
    
