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
    }
  }

  public override int CalculateTotalAmountPoints()
  {
    return _totalAmountPoints;
  }
}