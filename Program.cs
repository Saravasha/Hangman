
using System.Text;



namespace Hangman
{





 

}


class Program
{

    static void Guess()
    {
        Console.WriteLine("Guess");
    }
    static void Game()
    {
        Console.WriteLine("Game");
    }

    static void GetSecretWord()
    {
        Console.WriteLine("Secred Word");
    }
    static void Main(string[] args)
    {
        Game();
        Console.WriteLine("Zigi plz");


        StringBuilder sb = new StringBuilder("ABC", 50);
        sb.Append("WWWWWWW");
        Console.WriteLine(sb);
        Console.WriteLine(sb.Length);
        Console.ReadKey();

        string text = "Hangman";

        char[] chars = text.ToCharArray();

        Console.WriteLine(chars);
        Console.WriteLine(text);

        foreach (char c in chars)
        {
            Console.WriteLine(c);
        }
    }
}
    
