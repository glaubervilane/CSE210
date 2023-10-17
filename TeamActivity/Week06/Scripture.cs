using System;
using System.Collections.Generic;

public class Scripture
{
    private List<Word> words;
    public Reference Reference { get; }

    private int currentWordIndex = 0;

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

    public void HideNextWord()
    {
        if (currentWordIndex < words.Count)
        {
            words[currentWordIndex].Hide();
            currentWordIndex++;
        }
    }

    public bool IsCompletelyHidden()
    {
        return currentWordIndex >= words.Count;
    }

    public string RenderScripture()
    {
        string renderedText = string.Join(" ", words);
        return $"{Reference}: {renderedText}";
    }
}
