using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

        library.AddScripture(new Reference("John", 3, 16), "For God so loved the world...");
        library.AddScripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart...");
        library.AddScripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd, I shall not want.");
        library.AddScripture(new Reference("Isaiah", 40, 31), "But those who hope in the Lord will renew their strength.");
        library.AddScripture(new Reference("Matthew", 11, 28), "Come to me, all you who are weary and burdened, and I will give you rest.");
        library.AddScripture(new Reference("Philippians", 4, 13), "I can do all things through Christ who strengthens me.");


        while (true)
        {
            Console.Clear();

            Scripture scripture = library.SelectRandomScripture();

            if (scripture != null)
            {
                // Display and interact with the selected scripture
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(scripture.RenderScripture());

                    Console.Write("Press Enter to hide a word or type 'quit' to exit: ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                        // Exit the program if 'quit' is typed
                        return;

                    scripture.HideNextWord();

                    if (scripture.IsCompletelyHidden())
                    {
                        Console.Clear();
                        Console.WriteLine("You've memorized the entire scripture!");
                        // Exit the inner loop
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("The scripture library is empty. Add scriptures or load them from files.");
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
                return;
            }
        }
    }
}