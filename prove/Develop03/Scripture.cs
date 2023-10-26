// Scripture.cs
using System;
using System.Collections.Generic;

public class Scripture
{
    private List<Word> _words;
    public Reference Reference { get; }

    private int currentWordIndex = 0;

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ');
        foreach (var word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandom()
    {
        if (currentWordIndex < _words.Count)
        {
            List<int> hiddenIndexes = _words
                .Select((word, index) => new { Word = word, Index = index })
                .Where(item => !item.Word.IsHidden)
                .Select(item => item.Index)
                .ToList();

            if (hiddenIndexes.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, hiddenIndexes.Count);
                _words[hiddenIndexes[randomIndex]].Hide();
                currentWordIndex++;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        return currentWordIndex >= _words.Count;
    }

    public string RenderScripture()
    {
        List<string> visibleWords = _words.ConvertAll(word => word.ToString());
        string renderedText = string.Join(" ", visibleWords);
        return $"{Reference.GetFormattedReference()}| {renderedText}";
    }
}
