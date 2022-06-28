using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
}

class Program
{
    // Guess, commenting just for highlighting purposes, (Player guess)
    public static void Guess(StringBuilder sb, int secretWordLength, string secretWord) {
        int guessNum = 10;
        Console.WriteLine("Guess the word, carefully...");
        do {
            
            string? stringGuess = Convert.ToString(Console.ReadLine().ToUpper());
            
            int guessLength = stringGuess.Length;
            guessNum -= guessLength;
            Console.WriteLine($"You have {guessNum} number of guesses remaining, {guessLength} is the number of characters just used for this attempt");
            Console.WriteLine(sb);

            // UnderscoreBuilder of SecretWordLength
            var secretWordToUnderScores = Regex.Replace(secretWord, @"[\w:]", "_ ");
            //var hiddenChar = "";
            //for (int i = 0; i < secretWordLength; i++)
            //{
            //    hiddenChar += "_" + ",";
            //}
            Console.WriteLine(secretWordToUnderScores);


            //Console.WriteLine(secretWord.ToUpper());
            //Console.WriteLine(stringGuess.ToUpper());

            if (stringGuess.Contains(secretWord.ToUpper()))
            {
                Console.WriteLine("Love u dood");
            } else
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
            string printArg = "You lose";
            Print(printArg);
        }
    }

    // Print (Print status, Print end result)
    public static void Print(string printArg)
    {
        string text = "How about (a)nother game? Ahahahahahaha! :D\n(Input: Y / y or N/ n)";
        switch (printArg)
        {
            case string a when printArg.Contains("You lose"):
                Console.Clear();
        Console.WriteLine("---------------------");
        Console.WriteLine("- You lose, hahaha! -");
        Console.WriteLine("---------------------");
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
        //StringBuilder sb = new StringBuilder("ABC", 50);
        //sb.Append("WWWWWWW");
        //Console.WriteLine(sb);
        //Console.WriteLine(sb.Length);
        string? wannaPlay = Console.ReadLine();

        switch (wannaPlay)
        {
            case string zigi when wannaPlay.Contains("ny"):
            case string plz when wannaPlay.Contains("yn"):
                Console.WriteLine("Nice try - I'll ask again! :D");
                Thread.Sleep(2000);
                Console.Clear();
                Game(text);
                break;
            case string gerk when wannaPlay.Contains("y"):
                GetSecretWord();
                break;
            case string bork when wannaPlay.Contains("n"):
                Console.WriteLine("It's treason, then.");
                Environment.Exit(0);
                break;
            default: Game(text);
                break;
        }
    }

    // GetSecretWord, Randomizer ov hidden nouns is complete! (Initiate: Secret Word, Char array, Stringbuilder
    static void GetSecretWord()
    {
        Console.WriteLine("Randomizing secret word...");
        Random rando = new Random();
        var secretWordList = new string[10] { "Potato", "Gerpgork", "Tomato", "Cockatoo", "Bird", "Macaw", "Chocolate", "Book", "Cake", "Glasses"};
        int index = rando.Next(secretWordList.Count());
        string randomString = secretWordList[index];
        Console.WriteLine(($"The secret word is {secretWordList[index].ToUpper()}"));

        string secretWord = (string) secretWordList[index];

        StringBuilder sb = new StringBuilder(secretWord, 10);
        int secretWordLength = secretWord.Length;

        char[] chars = secretWord.ToCharArray();
        //foreach (char c in chars)
        //{
        //    //sb.Append(c);
        //    Console.WriteLine(c);
        //}

        Guess(sb, secretWordLength, secretWord);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Hangman!\nMade by Siavash Gosheh\nSaravasha on GitHub");
        string text = "How about a game? (Input:Y/y or N/n)";
        Game(text);
    }
}
    
