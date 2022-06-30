using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
}

class Program
{
    // Guess, commenting just for highlighting purposes, (Player guess)
    public static void Guess(char[] charify, int secretWordLength, string secretWord)
    {
        int guessNum = 10;
        StringBuilder sb = new StringBuilder("", 10);
        StringBuilder wrongChars = new StringBuilder();

        Console.WriteLine("Guess the word, carefully...");
        do
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


            // UnderscoreBuilder of SecretWordLength
            var secretWordToUnderScores = Regex.Replace(secretWord, @"[\w:]", "_ ").ToString();
            Console.WriteLine(secretWordToUnderScores);

            // Collector of wrong chars




            foreach (char w in charify)
            {
                if (stringGuess.Contains(w))
                {
                    Console.WriteLine("poopy butt");
                    sb = sb.Append(w);
                }

                Console.WriteLine($"char in charify = {w}");
            }
            var sbToString = sb.ToString();
            Console.WriteLine($"sb = {sb}");



            //var input = Console.ReadKey().ToString().Length;


            //Console.WriteLine(input);

            // Call Matches method without specifying any options.

            // Char array index finder

            foreach (Match match in Regex.Matches(secretWord, stringGuess, RegexOptions.None, TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                //char[] charsy = secretWordToUnderScores.ToCharArray();
                //    var zigi = match.Value;
                //charsy[match.Index] = zigi;
                //charsy = new string(charsy);
                //secretWordToUnderScores.Replace(match.Groups[1].Value, match.Groups[2].Value);
                //int index = match.Index;

            }


            Console.WriteLine(secretWordToUnderScores);

            if (stringGuess.Contains(secretWord, StringComparison.OrdinalIgnoreCase) || sbToString.Contains(secretWord, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Love u dood");
                Print("You win");
            }
            else
            {
                //TBA   
            }

            //sb.ToString().IndexOf(Convert.ToString(guessLength));
            //Console.WriteLine(sb.ToString());

            // Pseudo Code: If stringGuess Contains()


            // Behöver en enkapsulering av rätt gissningar.

        } while (guessNum > 0);
        if (guessNum <= 0)
        {
            Print("You lose");
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

    // Validator (Check Guess)
    static void Validator()
    {
        //kollar om giltig inmatning och catchar felaktig input, ber användaren att försöka igen.
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
        Console.WriteLine(($"The secret word is {secretWordList[index]}"));

        string secretWord = secretWordList[index].ToString().ToUpper();

        
        int secretWordLength = secretWord.Length;

        char[] charify = secretWord.ToCharArray();
        //foreach (char c in chars)
        //{
        //    sb.Append(c);
        // Console.WriteLine(c);
        // }

        Guess(charify, secretWordLength, secretWord);
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
    
