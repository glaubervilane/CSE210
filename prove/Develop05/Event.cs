class Event
{
  private string _name;
  protected string _description;
  private int _points;
  public bool Completed;

  public Event(string name, int points, string description)
  {
    _name = name;
    _points = points;
    _description = description;
  }

  public string GetName()
  {
    return _name;
  }

  public string GetDescription()
  {
    return _description;
  }

  public int GetPoints()
  {
    return _points;
  }

  public virtual void MarkComplete()
  {
    Completed = true;
  }
}