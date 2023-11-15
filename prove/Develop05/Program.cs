class Program
{
    static void Main()
    {
        List<BaseGoal> goals = new List<BaseGoal>(); // Create a list to store goals

        while (true)
        {
            Console.WriteLine($"You have {CalculateTotalPoints(goals)} points");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal;");
            Console.WriteLine("2. List Goals;");
            Console.WriteLine("3. Save Goals;");
            Console.WriteLine("4. Load Goals;");
            Console.WriteLine("5. Record Events;");
            Console.WriteLine("6. Quit;");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewGoal(goals);
                        break;
                    case 2:
                        ListGoals(goals);
                        break;
                    case 3:
                        SaveGoals(goals);
                        break;
                    case 4:
                        LoadGoals(goals);
                        break;
                    case 5:
                        RecordEvent(goals);
                        break;
                    case 6:
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    // Helper method to calculate total points
    static int CalculateTotalPoints(List<BaseGoal> goals)
    {
        int totalPoints = 0;
        foreach (var goal in goals)
        {
            totalPoints += goal.CalculateTotalAmountPoints();
        }
        return totalPoints;
    }

    // Helper method to create a new goal
    static void CreateNewGoal(List<BaseGoal> goals)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal;");
        Console.WriteLine("2. Eternal Goals;");
        Console.WriteLine("3. Checklist Goals;");
        Console.Write("Which type of goal would you like to create? ");

        if (int.TryParse(Console.ReadLine(), out int goalType))
        {
            BaseGoal newGoal = null;

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            if (int.TryParse(Console.ReadLine(), out int amountPoints))
            {
                switch (goalType)
                {
                    case 1:
                        newGoal = new SimpleGoal(name, description, amountPoints);
                        break;
                    case 2:
                        Console.Write("How many times should this goal be done? ");
                        if (int.TryParse(Console.ReadLine(), out int times))
                        {
                            newGoal = new EternalGoal(name, description, amountPoints, times);
                        }
                        break;
                    case 3:
                        Console.Write("How many times should this goal be done? ");
                        if (int.TryParse(Console.ReadLine(), out int timesForAccomplishGoal))
                        {
                            newGoal = new ChecklistGoal(name, description, amountPoints, timesForAccomplishGoal);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid goal type.");
                        return;
                }

                if (newGoal != null)
                {
                    goals.Add(newGoal);
                    Console.WriteLine($"Goal '{name}' created!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for amount of points.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for goal type.");
        }
    }

    // Helper method to list goals
    static void ListGoals(List<BaseGoal> goals)
    {
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - Completed: {goal.GetCompletion()}, Points: {goal.CalculateTotalAmountPoints()}");

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"Completed {checklistGoal.TimesAccomplished}/{checklistGoal.TimesForAccomplishGoal} times");
            }
        }
    }


    // Helper method to save goals
    static void SaveGoals(List<BaseGoal> goals)
    {
        Console.Write("Enter a name for the file to save goals: ");
        string fileName = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter($"{fileName}.txt"))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal._description},{goal.IsCompleted},{goal._amountPoints}");
            }
        }
        Console.WriteLine($"Goals saved to {fileName}.txt");
    }

    // Helper method to load goals
    static void LoadGoals(List<BaseGoal> goals)
    {
        Console.Write("Enter the name of the file to load goals: ");
        string fileName = Console.ReadLine();
        try
        {
            string[] lines = File.ReadAllLines($"{fileName}.txt");

            foreach (var line in lines)
            {
                string[] parts = line.Split(",");
                string typeName = parts[0];
                string name = parts[1];
                string description = parts[2];
                bool isCompleted = bool.Parse(parts[3]);
                int amountPoints = int.Parse(parts[4]);

                BaseGoal goal = null;

                switch (typeName)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(name, description, amountPoints);
                        break;
                    case "EternalGoal":
                        int times = int.Parse(parts[5]);
                        goal = new EternalGoal(name, description, amountPoints, times);
                        break;
                    case "ChecklistGoal":
                        int timesForAccomplishGoal = int.Parse(parts[5]);
                        goal = new ChecklistGoal(name, description, amountPoints, timesForAccomplishGoal);
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type: {typeName}");
                        break;
                }

                if (goal != null)
                {
                    goal.IsCompleted = isCompleted;
                    goals.Add(goal);
                }
            }

            Console.WriteLine($"Goals loaded from {fileName}.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File {fileName}.txt not found.");
        }
    }

    // Helper method to record events
    static void RecordEvent(List<BaseGoal> goals)
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= goals.Count)
        {
            BaseGoal goal = goals[goalIndex - 1];

            if (goal is EternalGoal eternalGoal)
            {
                Console.WriteLine($"Recorded an event for {goal.Name}");
                eternalGoal.RecordEvent();
                Console.WriteLine($"Congratulations! You earned {goal.CalculateTotalAmountPoints()} points.");
            }
            else
            {
                Console.WriteLine("Recorded an event for {goal.Name}");
                goal.RecordEvent();
                Console.WriteLine($"Congratulations! You earned {goal.CalculateTotalAmountPoints()} points.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
}