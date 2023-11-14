using System.Collections.Generic;
using System.IO;

// Base class for all types of goals
public class BaseGoal
{
  // Attributes
  protected string Name;
  protected string _description;
  protected bool IsCompleted;
  protected int _amountPoints;

  // Constructor
  public BaseGoal(string name, string description, int amountPoints)
  {
    Name = name;
    _description = description;
    IsCompleted = false;
    _amountPoints = amountPoints;
  }

  // Virtual methods
  public virtual void RecordEvent() { }

  public virtual int CalculateTotalAmountPoints()
  {
    return _amountPoints;
  }

  public virtual bool GetCompletion()
  {
    return IsCompleted;
  }

  // Methods to create a new goal, list goals, save goals to a file, and load goals from a file
  public void CreateGoal(BaseGoal goal)
  {
    // todo
  }

  public void ListGoals()
  {
    Console.WriteLine($"{Name} - Completed: {GetCompletion()}, Points: {CalculateTotalAmountPoints()}");
  }

  public void SaveGoals()
  {
    using (StreamWriter writer = new StreamWriter("goals.txt"))
    {
      writer.WriteLine($"{Name},{_description},{IsCompleted},{_amountPoints}");
    }
  }

  public void LoadGoals()
  {
    try
    {
      string[] lines = File.ReadAllLines("goals.txt");

      foreach (var line in lines)
      {
        string[] parts = line.Split(",");
        string name = parts[0];
        string description = parts[1];
        bool isCompleted = bool.Parse(parts[2]);
        int amountPoints = int.Parse(parts[3]);

        Name = name;
        _description = description;
        IsCompleted = isCompleted;
        _amountPoints = amountPoints;
      }
    }
    catch (FileNotFoundException)
    {
      Console.WriteLine("No goals found.");
    }
  }
}
