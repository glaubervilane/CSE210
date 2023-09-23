using System;

class Program
{
  static void Main(string[] args)
  {
    Journal journal = new Journal();
    bool isRunning = true;

    while (isRunning)
    {
      Console.WriteLine("\nJournal App Menu:");
      Console.WriteLine("1. Write a new entry");
      Console.WriteLine("2. Display the journal");
      Console.WriteLine("3. Save the journal to a file");
      Console.WriteLine("4. Load the journal from a file");
      Console.WriteLine("5. Exit");

      Console.Write("Select an option (1-5): ");
      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          Console.Write("Enter your response: ");
          string response = Console.ReadLine();
          journal.AddEntry(Journal.GetRandomPrompt(), response);
          break;

        case "2":
          journal.DisplayEntries();
          break;

        case "3":
          Console.Write("Enter the file name to save: ");
          string saveFileName = Console.ReadLine();
          journal.SaveToFile(saveFileName);
          Console.WriteLine("Journal saved successfully.");
          break;

        case "4":
          Console.Write("Enter the file name to load: ");
          string loadFileName = Console.ReadLine();
          journal.LoadFromFile(loadFileName);
          Console.WriteLine("Journal loaded successfully.");
          break;

        case "5":
          isRunning = false;
          break;

        default:
          Console.WriteLine("Invalid choice. Please select a valid option (1-5).");
          break;
      }
    }
  }
}