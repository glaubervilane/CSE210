public class Reference
{
  public string Book { get; private set; }
  public int Chapter { get; private set; }
  public int StartVerse { get; private set; }
  public int EndVerse { get; private set; }

  public Reference(string book, int chapter, int startVerse)
  {
    Book = book;
    Chapter = chapter;
    StartVerse = startVerse;
    EndVerse = startVerse;
  }

  public Reference(string book, int chapter, int startVerse, int endVerse)
  {
    Book = book;
    Chapter = chapter;
    StartVerse = startVerse;
    EndVerse = endVerse;
  }

  public static Reference Parse(string referenceString)
  {
    string[] parts = referenceString.Split(' ');
    if (parts.Length >= 3)
    {
      string book = parts[0];
      int chapter = int.Parse(parts[1]);
      string[] verseParts = parts[2].Split('-');
      int startVerse = int.Parse(verseParts[0]);
      int endVerse = startVerse;
      if (verseParts.Length > 1)
      {
        endVerse = int.Parse(verseParts[1]);
      }
      return new Reference(book, chapter, startVerse, endVerse);
    }
    throw new ArgumentException("Invalid reference format.");
  }
}
