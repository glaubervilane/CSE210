using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> scriptures = new List<Scripture>();

    public void LoadScripturesFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    Reference reference = Reference.Parse(parts[0]);
                    scriptures.Add(new Scripture(reference, parts[1]));
                }
            }
        }
    }

    public void AddScripture(Reference reference, string text)
    {
        scriptures.Add(new Scripture(reference, text));
    }

    public Scripture SelectRandomScripture()
    {
        if (scriptures.Count == 0)
        {
            Console.WriteLine("The scripture library is empty.");
            return null;
        }

        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}