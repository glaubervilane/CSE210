public class ChecklistGoal : BaseGoal
{
  // Attributes specific to ChecklistGoal
  private int _timesForAccomplishGoal;
  private int _timesAccomplished;
  private int _totalAmountPoints;

  public int TimesAccomplished => _timesAccomplished;
  public int TimesForAccomplishGoal => _timesForAccomplishGoal;


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

    base.RecordEvent(); // Call the base method

    if (_timesAccomplished == _timesForAccomplishGoal)
    {
      IsCompleted = true;
      Console.WriteLine($"{Name} goal completed!");
    }
  }

  public override int CalculateTotalAmountPoints()
  {
    return _totalAmountPoints;
  }
}
