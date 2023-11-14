public class SimpleGoal : BaseGoal
{
  // Attribute specific to SimpleGoal
  private int _totalAmountPoints;

  // Constructor
  public SimpleGoal(string name, string description, int amountPoints) : base(name, description, amountPoints)
  {
    _totalAmountPoints = amountPoints;
  }

  // Override methods
  public override void RecordEvent()
  {
    // Additional logic for recording events for simple goals
  }

  public override int CalculateTotalAmountPoints()
  {
    return _totalAmountPoints;
  }

  public override bool GetCompletion()
  {
    return base.IsCompleted;
  }

  // New method specific to SimpleGoal
  public void MarkComplete()
  {
    base.IsCompleted = true;
  }
}