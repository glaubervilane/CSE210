public class EternalGoal : BaseGoal
{
  // Attribute specific to EternalGoal
  private int _instancePoints;

  // Constructor
  public EternalGoal(string name, string description, int amountPoints, int instancePoints) : base(name, description, amountPoints)
  {
    _instancePoints = instancePoints;
  }

  // Override methods
  public override void RecordEvent()
  {
    base.RecordEvent();
    _amountPoints += _instancePoints;
    Console.WriteLine($"Event recorded for {Name}.");
  }

  public override int CalculateTotalAmountPoints()
  {
    return base.CalculateTotalAmountPoints();
  }
}
