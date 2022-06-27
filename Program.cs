using System.Text;

namespace Hangman
{
}

class Program
{
    // Guess, commenting just for highlighting purposes
    public static void Guess(StringBuilder sb) {
        int guessNum = 10;
        do {
            Console.WriteLine("Guess the word, carefully...");
            string? stringGuess = Convert.ToString(Console.ReadLine());
            int guessLength = stringGuess.Length;
            guessNum -= guessLength;
            Console.WriteLine($"{guessNum} is the remaining number of guesses, {guessLength} is the number of characters just used for this attempt");
            Console.WriteLine(sb);
            //sb.ToString().IndexOf(Convert.ToString(guessLength));
            //Console.WriteLine(sb.ToString());


            // Behöver en enkapsulering av rätt gissningar.

        } while (guessNum > 0);
    }
    
    
    // Game
    static void Game()
    {
        Console.WriteLine("Game");
        //StringBuilder sb = new StringBuilder("ABC", 50);
        //sb.Append("WWWWWWW");
        //Console.WriteLine(sb);
        //Console.WriteLine(sb.Length);
        //Console.ReadKey();
    
        GetSecretWord();
    }

    // GetSecretWord, Randomizer ov hidden nouns is complete!
    static void GetSecretWord()
    {
        Random rando = new Random();
        var secretWordList = new string[10] { "Potato", "Gerpgork", "Tomato", "Cockatoo", "Bird", "Macaw", "Chocolate", "Book", "Cake", "Glasses"};
        int index = rando.Next(secretWordList.Count());
        string randomString = secretWordList[index];
        Console.WriteLine(($"The secret word is {secretWordList[index].ToUpper()}"));

        string secretWord = (string) secretWordList[index];

        StringBuilder sb = new StringBuilder(secretWord, 10);
        char[] chars = secretWord.ToCharArray();
        //foreach (char c in chars)
        //{
        //    //sb.Append(c);
        //    Console.WriteLine(c);
        //}

        Guess(sb);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Zigi plz");
        Game();
    }
}
    
