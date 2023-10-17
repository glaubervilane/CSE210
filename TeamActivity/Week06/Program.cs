using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

        library.AddScripture(new Reference("John", 3, 16), "For God so loved the world...");
        library.AddScripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart...");


        // Load scriptures from files
        library.LoadScripturesFromFile("scriptures.txt"); // You can provide your own file path

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

                    Console.Write("Press Enter to hide words or type 'quit' to exit: ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                        break;

                    scripture.HideNextWords(3);

                    if (scripture.IsCompletelyHidden())
                    {
                        Console.Clear();
                        Console.WriteLine("You've memorized the entire scripture!");
                        break;
                    }
                }

                Console.WriteLine("Press Enter to select another scripture or type 'quit' to exit.");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "quit")
                    break;
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
