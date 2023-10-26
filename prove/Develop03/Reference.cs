public class Reference
{
  private string _book;
  private int _chapter;
  private int _startVerse;
  private int _endVerse;

  public Reference(string book, int chapter, int startVerse)
  {
    _book = book;
    _chapter = chapter;
    _startVerse = startVerse;
    _endVerse = startVerse;
  }

  public Reference(string book, int chapter, int startVerse, int endVerse)
  {
    _book = book;
    _chapter = chapter;
    _startVerse = startVerse;
    _endVerse = endVerse;
  }

  public string GetFormattedReference()
  {
    return $"{_book} {_chapter}:{_startVerse}";
  }

  public static Reference Parse(string referenceString)
  {
    string[] parts = referenceString.Split('|');
    if (parts.Length == 2)
    {
      string referencePart = parts[0].Trim();
      string textPart = parts[1].Trim();

      string[] referenceParts = referencePart.Split(' ');
      if (referenceParts.Length >= 3)
      {
        string book = referenceParts[0];
        int chapter = int.Parse(referenceParts[1]);
        string[] verseParts = referenceParts[2].Split('-');
        int startVerse = int.Parse(verseParts[0]);
        int endVerse = startVerse;
        if (verseParts.Length > 1)
        {
          endVerse = int.Parse(verseParts[1]);
        }
        return new Reference(book, chapter, startVerse, endVerse);
      }
    }
    throw new ArgumentException("Invalid reference format.");
  }
}
