class User
{
  public int _score;
  public List<Event> _events;

  public User()
  {
    _score = 0;
    _events = new List<Event>();
  }

  public List<Event> GetEvents()
  {
    return _events;
  }

  public int GetScore()
  {
    return _score;
  }
}