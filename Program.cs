using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{

    //Hej Siavash,

    //Jag körde ditt program och är inte helt nöjd med följande punkter:

    // DONE Du tvingar användaren att välja en bokstav hela tiden.Sådan är inte tanken. Användaren ska kunna gissa på hela ordet för varje nytt försök.

    //Programmet ska visa de felaktiga tecknen efter varje gissning.

    // DONE -- Det ska även visas vilket ord som ska vara den korrekta, när man misslyckas.

    //Fixa ovanstående punkter för godkänt.

}



class Program
{
    // Guess, commenting just for highlighting purposes, (Player guess)
    public static void Guess(char[] charify, string secretWord, int secretLength)
    {
        int guessNum = 10;
        StringBuilder wrongGuess = new StringBuilder();

        StringBuilder correctGuess = new StringBuilder(secretLength);

        Console.WriteLine("Guess the word, carefully...");
        bool keepGoing = true;

        do
        {
            string stringGuess = Convert.ToString(Console.ReadLine().ToUpper());
            bool textInput = Regex.IsMatch(stringGuess, @"^[a-zA-Z]+$");
            bool empty = string.IsNullOrEmpty(stringGuess);
            int guessLength = stringGuess.Length;


            switch (stringGuess)
            {
                case string a when (empty == true):
                    Console.WriteLine("Empty input");
                    keepGoing = true;
                    break;
                case string b when (textInput == false):
                    Console.WriteLine("Unacceptable input, try again with a Alphabetical character! :D");
                    keepGoing = true;
                    break;
                default:
                    keepGoing = true;
                    guessNum--;

                    Console.WriteLine($"You have {guessNum} number of guesses remaining, {guessLength} is the number of characters just used for this attempt");
                    Console.WriteLine(stringGuess);

                    //my precious


                        
                    var wrongify = new char[secretLength];

                    foreach (char c in stringGuess)
                    {
                        //stringGuess 
                        stringGuess = c.ToString();
                        for (int i = 0; i < secretLength; i++)
                        {
                            if (stringGuess == secretWord[i].ToString())
                            {
                                Console.WriteLine($"{c} is correct!");
                                charify[i] = Convert.ToChar(stringGuess);
                            }
                            else 
                            //if (stringGuess != secretWord[i].ToString())
                            {
                                wrongify[i] = Convert.ToChar(stringGuess);
                                Console.WriteLine($"{c} is not correct!");
                            }
                        }
                    }
                    //foreach (char c in stringGuess)
                    //{
                    //    //stringGuess 
                    //    stringGuess = c.ToString();
                    //    for (int i = 0; i < secretLength; i++)
                    //    {
                    //    }
                    //}


                    if (wrongify.ToString().Contains(stringGuess))
                    {
                        wrongGuess = wrongGuess.Append(wrongify);
                    }
                    string revealChars = new string(charify);
                    Console.WriteLine(revealChars);


                    Console.WriteLine($"Wrong Guesses: {wrongGuess}");
                    if (stringGuess.Contains(wrongGuess.ToString()))
                    {
                        
                        Console.WriteLine($"Wrong Guesses before if statement: {wrongGuess}");
                    }

                    
                    if (
                    stringGuess.Contains(secretWord, StringComparison.OrdinalIgnoreCase)
                    ||
                    stringGuess.Equals(secretWord, StringComparison.OrdinalIgnoreCase)
                    ||
                    stringGuess.Equals(charify)
                    ||
                    revealChars.Equals(secretWord, StringComparison.OrdinalIgnoreCase)
                    )
                    {
                        Console.WriteLine("Love u dood");
                        Print(secretWord + " is correct!\nYou win! :) :) :)");
                        keepGoing = false;
                    }
                    else if (guessNum < 1)
                    {
                        Print("You ran out of guesses\n" + secretWord + " was the sought word\nYou lose! :( :( :(");
                        keepGoing = false;
                    }
            break;
            } 
        } while (keepGoing);
    }



    //Console.WriteLine(secretWordToUnderScores);
    // Behöver en enkapsulering av rätt gissningar i denna loop.
    // Game Win Conditions




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
                    Console.WriteLine($"{printArg}");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }
                //Console.ReadKey();
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
                    Console.WriteLine($"{printArg}");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }
                //Console.ReadKey();
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
                /*Console.ResetColor();*/
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nice try - I'll ask again! :D");
                Console.ResetColor();
                Game(text);
                break;
        }
    }

    // GetSecretWord, Randomizer ov hidden nouns is complete! (Initiate: Secret Word, Char array, Stringbuilder
    static void GetSecretWord()
    {
        Console.WriteLine("\nRandomizing secret word...");
        Random rando = new Random();
        var secretWordList = new string[10] { "Potato", "Gerpgork", "Tomato", "Cockatoo", "Bird", "Macaw", "Chocolate", "Book", "Cake", "Glasses", };
        int index = rando.Next(secretWordList.Count());
        //string randomString = secretWordList[index];


        string secretWord = new string(secretWordList[index].ToString().ToUpper());
        int secretLength = secretWord.Length;
        char[] charify = new char[secretLength];
        // UnderscoreBuilder of secretWord
        for (int i = 0; i < secretLength; i++)
        {
            charify[i] = '_';
        }
        Console.WriteLine(charify);
        //Console.WriteLine(charify);
        Console.WriteLine($"The secret word is ... {secretWord}");
        Guess(charify, secretWord, secretLength);
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
    
