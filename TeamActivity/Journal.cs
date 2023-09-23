using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
  public string Prompt { get; set; }
  public string Response { get; set; }
  public DateTime Date { get; set; }

  public Entry(string prompt, string response)
  {
    Prompt = prompt;
    Response = response;
    Date = DateTime.Now;
  }

  public override string ToString()
  {
    return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
  }
}

class Journal
{
  private List<Entry> entries = new List<Entry>();

  public void AddEntry(string prompt, string response)
  {
    Entry entry = new Entry(prompt, response);
    entries.Add(entry);
  }

  public void DisplayEntries()
  {
    foreach (Entry entry in entries)
    {
      Console.WriteLine(entry);
    }
  }

  public void SaveToFile(string fileName)
  {
    using (StreamWriter writer = new StreamWriter(fileName))
    {
      foreach (Entry entry in entries)
      {
        writer.WriteLine($"Date: {entry.Date}");
        writer.WriteLine($"Prompt: {entry.Prompt}");
        writer.WriteLine($"Response: {entry.Response}\n");
      }
    }
  }

  public void LoadFromFile(string fileName)
  {
    entries.Clear();
    using (StreamReader reader = new StreamReader(fileName))
    {
      string line;
      string currentPrompt = null;
      string currentResponse = null;
      DateTime currentDate = DateTime.MinValue;

      while ((line = reader.ReadLine()) != null)
      {
        if (line.StartsWith("Date: "))
        {
          currentDate = DateTime.Parse(line.Substring(6));
        }
        else if (line.StartsWith("Prompt: "))
        {
          currentPrompt = line.Substring(8);
        }
        else if (line.StartsWith("Response: "))
        {
          currentResponse = line.Substring(10);
          entries.Add(new Entry(currentPrompt, currentResponse) { Date = currentDate });
        }
      }
    }
  }

  public static string GetRandomPrompt()
  {
    List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

    Random random = new Random();
    int index = random.Next(prompts.Count);
    return prompts[index];
  }
}
