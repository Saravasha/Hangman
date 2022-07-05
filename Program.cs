using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
}

class Program
{
    // Guess, commenting just for highlighting purposes, (Player guess)
    public static void Guess(char[] charify, string secretWord, int secretLength)
    {
        int guessNum = 10;
        StringBuilder wrongInput = new StringBuilder("");

        StringBuilder correctInput = new StringBuilder(secretWord);

        Console.WriteLine("Guess the word, carefully...");
        bool validInput = true;

        do
        {


            string? stringGuess = Convert.ToString(Console.ReadLine()).ToUpper();
            bool empty = String.IsNullOrEmpty(stringGuess);
            bool textInput = Regex.IsMatch(stringGuess, @"^[a-zA-Z]+$");


            int guessLength = stringGuess.Length;

            StringBuilder guess = new StringBuilder(stringGuess);

            switch (stringGuess)
            {
                case string when textInput == false:
                    Console.WriteLine("Unacceptable input, try again with a Alphabetical character! :D");
                    validInput = false;
                    break;
                case string when guessNum == 1:
                    Print(secretWord + " was the sought word\nYou lose! :( :( :(");
                    break;
                case string when empty == true:
                    validInput = false;
                    break;
                default:

                    //if (guessLength != 0)
                    //stringGuess;
                    //{

                    //if (guessNum <= guessLength)
                    //{
                    //    Print($"{secretWord} was the sought word\nYou lose!");
                    //}

                    //Hej Siavash,

                    //Jag körde ditt program och är inte helt nöjd med följande punkter:

                    //Du tvingar användaren att välja en bokstav hela tiden.Sådan är inte tanken. Användaren ska kunna gissa på hela ordet för varje nytt försök.

                    //Programmet ska visa de felaktiga tecknen efter varje gissning.

                    //Det ska även visas vilket ord som ska vara den korrekta, när man misslyckas.

                    //Fixa ovanstående punkter för godkänt.

                    // Guess Numbers reduced by 1 for each attempt.
                    guessNum = guessNum - 1;
                    Console.WriteLine($"You have {guessNum} number of guesses remaining, {guessLength} is the number of characters just used for this attempt");



                    // Revealer of secretWord if guess is correct // if guess is wrong.

                    for (int j = 0; j < secretLength; j++)
                    {
                        if (stringGuess == secretWord[j].ToString())
                        {
                            charify[j] = Convert.ToChar(stringGuess);
                        }
                        else if (stringGuess.Contains(charify[j]))
                        {
                            Console.WriteLine(stringGuess.Contains(charify.ToString()));
                        }
                    }
                    string charified = new string(charify);
                    Console.WriteLine("zigi" + charified);

                    if (stringGuess != secretWord.ToString())
                    {
                        wrongInput = wrongInput.Append(stringGuess);
                        Console.WriteLine("poopy butt");
                    }

                    ////var wrongInputToString = wrongInput.ToString();
                    //if (stringGuess != secretWord || stringGuess.Contains(charify.ToString()))
                    //{
                    //    //Console.WriteLine("zigi");
                    //}
                    //string charified2 = new string(charify);
                    //Console.WriteLine("charified2 = ", charified2);
                    // Collector of wrong chars

                    //foreach (char letter in charify)
                    //    {

                    //        if (stringGuess.Contains(letter) || stringGuess.Equals(charify))
                    //        {
                    //            var z = new string(charify);
                    //            Console.WriteLine("z =", z);
                    //            Console.WriteLine("Correct Guess");
                    //            wrongInput = wrongInput.Append(letter);
                    //Regex.IsMatch(input, @"^[a-zA-Z]+$");
                    //            foreach (Match match in Regex.Matches(secretWord, stringGuess, RegexOptions.None, TimeSpan.FromSeconds(1)))
                    //            {
                    //                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine($"char in charify = {wrongInput}");
                    //            wrongInput = wrongInput.Append(stringGuess);
                    //        }
                    //Console.WriteLine($"wrongInput = {wrongInput}");


                    //Console.WriteLine(charify);

                    Console.WriteLine($"wrongInput = {wrongInput}");
                    //Console.WriteLine($"wrongInputToString = {wrongInputToString}");

                    //Console.WriteLine($"correctInput = {correctInput}");


                    //var input = Console.ReadKey().ToString().Length;


                    //Console.WriteLine(input);

                    // Call Matches method without specifying any options.

                    // Char array index finder


                    //char[] charsy = secretWordToUnderScores.ToCharArray();
                    //    var zigi = match.Value;
                    //charsy[match.Index] = zigi;
                    //charsy = new string(charsy);
                    //secretWordToUnderScores.Replace(match.Groups[1].Value, match.Groups[2].Value);
                    //int index = match.Index;




                    //Console.WriteLine(secretWordToUnderScores);
                    // Game Condition checker
                    if (stringGuess.Contains(secretWord, StringComparison.OrdinalIgnoreCase) ||
                        charified.Contains(secretWord, StringComparison.OrdinalIgnoreCase) ||
                        charified.Equals(secretWord, StringComparison.OrdinalIgnoreCase) ||
                        //wrongInput.Equals(charify) ||
                        stringGuess.Equals(charify))
                    {
                        Console.WriteLine("Love u dood");
                        Print(secretWord+ " is correct!\nYou win! :) :) :)");
                    }
                    {
                        
                        //TBA   
                    }

                    //wrongInput.ToString().IndexOf(Convert.ToString(guessLength));
                    //Console.WriteLine(wrongInput.ToString());

                    // Pseudo Code: If stringGuess Contains()



                    // Behöver en enkapsulering av rätt gissningar.

                    break;
            
        }
        } while (!validInput) ;
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
                    Console.WriteLine($"{printArg}");
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
                    Console.WriteLine($"{printArg}");
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
        Console.WriteLine(($"The secret word is ... {secretWordList[index]}"));

        string secretWord = secretWordList[index].ToString().ToUpper();
        int secretLength = secretWord.Length;
        char[] charify = new char[secretLength];
        //foreach (char c in chars)
        //{
        //    wrongInput.Append(c);
        // Console.WriteLine(c);
        // }

        // UnderscoreBuilder of secretWord
        for (int i = 0; i < secretLength; i++)
        {
            charify[i] = '_';
        }

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
    
