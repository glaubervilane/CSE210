// Derived class for eternal goals
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
    _amountPoints += _instancePoints;
  }

  public override int CalculateTotalAmountPoints()
  {
    return _amountPoints;
  }
}
