public class ChecklistGoal : BaseGoal
{
  // Attributes specific to ChecklistGoal
  private int _timesForAccomplishGoal;
  private int _timesAccomplished;
  private int _totalAmountPoints;

  // Constructor
  public ChecklistGoal(string name, string description, int amountPoints, int timesForAccomplishGoal) : base(name, description, amountPoints)
  {
    _timesForAccomplishGoal = timesForAccomplishGoal;
    _totalAmountPoints = amountPoints * _timesForAccomplishGoal;
  }

  // Override methods
  public override void RecordEvent()
  {
    _timesAccomplished++;

    if (_timesAccomplished == _timesForAccomplishGoal)
    {
      base.IsCompleted = true;
      Console.WriteLine($"{Name} goal completed!");
    }

    base.RecordEvent();
    Console.WriteLine($"Event recorded for {Name}."); // Additional logic for recording events for checklist goals
  }

  public override int CalculateTotalAmountPoints()
  {
    return _totalAmountPoints;
  }
}
