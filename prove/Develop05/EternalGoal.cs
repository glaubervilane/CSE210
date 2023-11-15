class EternalGoal : Event
{
  public EternalGoal(string name, int points, string description) : base(name, points, description)
  {

  }

  public override void MarkComplete()
  {
    Completed = false;
    Console.WriteLine("You are a step forward your Eternal Goal.");
  }
}