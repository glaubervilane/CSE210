using System;
using System.Collections.Generic;

public class Scripture
{
    private List<Word> words;
    public Reference Reference { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        words = new List<Word>();

        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (var word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void HideNextWords(int numWordsToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numWordsToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return words.TrueForAll(word => word.IsHidden);
    }

    public string RenderScripture()
    {
        string renderedText = string.Join(" ", words);
        return $"{Reference}: {renderedText}";
    }
}
