using System;
using System.Collections.Generic;
using System.IO;

// Base class for all types of goals
public class BaseGoal
{
  public string Name { get; protected set; }
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
  public virtual void RecordEvent()
  {
    Console.WriteLine($"{Name} goal recorded!");
  }

  public virtual int CalculateTotalAmountPoints()
  {
    return _amountPoints;
  }

  public virtual bool GetCompletion()
  {
    return IsCompleted;
  }

  // Method to save goals to a file
  public void SaveGoals()
  {
    using (StreamWriter writer = new StreamWriter("goals.txt"))
    {
      writer.WriteLine($"{Name},{_description},{IsCompleted},{_amountPoints}");
    }
  }

  // Method to load goals from a file
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

        BaseGoal loadedGoal = new BaseGoal(name, description, amountPoints);
        loadedGoal.IsCompleted = isCompleted;
        Console.WriteLine($"{loadedGoal.Name} loaded - Completed: {loadedGoal.GetCompletion()}, Points: {loadedGoal.CalculateTotalAmountPoints()}");
      }
    }
    catch (FileNotFoundException)
    {
      Console.WriteLine("No goals found.");
    }
  }
}
