using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        User user = new User();

        while (true)
        {
            Console.WriteLine($"You have {user.GetScore()} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create a New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(user);
                    break;
                case "2":
                    ListGoals(user);
                    break;
                case "3":
                    SaveGoals(user);
                    break;
                case "4":
                    LoadGoals(user);
                    break;
                case "5":
                    RecordEvent(user);
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void CreateNewGoal(User user)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create: ");

        string goalTypeChoice = Console.ReadLine();

        switch (goalTypeChoice)
        {
            case "1":
                CreateSimpleGoal(user);
                break;
            case "2":
                CreateEternalGoal(user);
                break;
            case "3":
                CreateChecklistGoal(user);
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a valid goal type.");
                break;
        }
    }

    static void CreateSimpleGoal(User user)
    {
        Console.Write("What is the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it: ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            SimpleGoal simpleGoal = new SimpleGoal(name, points, description);
            user.GetEvents().Add(simpleGoal);
            Console.WriteLine("Simple Goal created successfully.");
        }
        else
        {
            Console.WriteLine("Invalid points value. Please enter a valid integer.");
        }
    }

    static void CreateEternalGoal(User user)
    {
        Console.Write("What is the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it: ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            EternalGoal eternalGoal = new EternalGoal(name, points, description);
            user.GetEvents().Add(eternalGoal);
            Console.WriteLine("Eternal Goal created successfully.");
        }
        else
        {
            Console.WriteLine("Invalid points value. Please enter a valid integer.");
        }
    }

    static void CreateChecklistGoal(User user)
    {
        Console.Write("What is the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it: ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus: ");
            if (int.TryParse(Console.ReadLine(), out int targetCount))
            {
                Console.Write("What is the bonus (points) for accomplishing it that many times: ");
                if (int.TryParse(Console.ReadLine(), out int bonusPoints))
                {
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, points, targetCount, bonusPoints, description);
                    user.GetEvents().Add(checklistGoal);
                    Console.WriteLine("Checklist Goal created successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid bonus points value. Please enter a valid integer.");
                }
            }
            else
            {
                Console.WriteLine("Invalid target count value. Please enter a valid integer.");
            }
        }
        else
        {
            Console.WriteLine("Invalid points value. Please enter a valid integer.");
        }
    }

    static void SaveGoals(User user)
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!filename.EndsWith(".txt"))
        {
            Console.WriteLine("Invalid file extension. Please use '.txt' extension.");
            return;
        }

        try
        {
            SaveGoalsToFile(user, filename);
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while saving goals: {ex.Message}");
        }
    }

    static void SaveGoalsToFile(User user, string filename)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
        {
            file.WriteLine(user.GetScore());

            foreach (Event goal in user.GetEvents())
            {
                string goalLine;
                if (goal is SimpleGoal)
                {
                    goalLine = $"SimpleGoal: \"{goal.GetName()}\", \"{goal.GetDescription()}\", {goal.GetPoints()}, {goal.Completed}";
                }
                else if (goal is EternalGoal)
                {
                    goalLine = $"EternalGoal: \"{goal.GetName()}\", \"{goal.GetDescription()}\", {goal.GetPoints()}";
                }
                else if (goal is ChecklistGoal)
                {
                    goalLine = $"ChecklistGoal: \"{goal.GetName()}\", \"{goal.GetDescription()}\", {goal.GetPoints()}, {((ChecklistGoal)goal)._bonusPoints}, {((ChecklistGoal)goal)._times}, {((ChecklistGoal)goal)._currentCount}";
                }
                else
                {
                    continue;
                }

                file.WriteLine(goalLine);
            }
        }
    }

    static void LoadGoals(User user)
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!filename.EndsWith(".txt"))
        {
            Console.WriteLine("Invalid file extension. Please use '.txt' extension.");
            return;
        }

        try
        {
            LoadGoalsFromFile(user, filename);
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while loading goals: {ex.Message}");
        }
    }

    static void LoadGoalsFromFile(User user, string filename)
    {
        if (!System.IO.File.Exists(filename))
        {
            throw new System.IO.FileNotFoundException("File not found.");
        }

        using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
        {
            if (int.TryParse(file.ReadLine(), out int score))
            {
                user._score = score;
            }

            user._events.Clear();

            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2)
                    continue;

                string type = parts[0].Trim();
                string data = parts[1].Trim();

                if (type == "SimpleGoal")
                {
                    string[] goalData = data.Split(new char[] { ',' });
                    if (goalData.Length == 4)
                    {
                        string name = goalData[0].Trim().Trim('\"');
                        string description = goalData[1].Trim().Trim('\"');
                        int points = int.Parse(goalData[2].Trim());
                        bool completed = bool.Parse(goalData[3].Trim());
                        SimpleGoal goal = new SimpleGoal(name, points, description)
                        {
                            Completed = completed,
                        };
                        user._events.Add(goal);
                    }
                }
                else if (type == "EternalGoal")
                {
                    string[] goalData = data.Split(new char[] { ',' });
                    if (goalData.Length == 3)
                    {
                        string name = goalData[0].Trim().Trim('\"');
                        string description = goalData[1].Trim().Trim('\"');
                        int points = int.Parse(goalData[2].Trim());
                        EternalGoal goal = new EternalGoal(name, points, description);
                        user._events.Add(goal);
                    }
                }
                else if (type == "ChecklistGoal")
                {
                    string[] goalData = data.Split(new char[] { ',' });
                    if (goalData.Length == 6)
                    {
                        string name = goalData[0].Trim().Trim('\"');
                        string description = goalData[1].Trim().Trim('\"');
                        int points = int.Parse(goalData[2].Trim());
                        int bonusPoints = int.Parse(goalData[3].Trim());
                        int targetCount = int.Parse(goalData[4].Trim());
                        int currentCount = int.Parse(goalData[5].Trim());
                        ChecklistGoal goal = new ChecklistGoal(name, points, targetCount, bonusPoints, description)
                        {
                            _currentCount = currentCount,
                        };
                        user._events.Add(goal);
                    }
                }
            }
        }
    }

    static void RecordEvent(User user)
    {
        List<Event> goals = user.GetEvents();

        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        Console.Write("What goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= goals.Count)
        {
            Event selectedGoal = goals[goalIndex - 1];

            if (selectedGoal is SimpleGoal simpleGoal && !simpleGoal.Completed)
            {
                simpleGoal.MarkComplete();

                user._score += selectedGoal.GetPoints();

                Console.WriteLine($"You have completed the Simple Goal: {selectedGoal.GetName()}.");
            }

            else if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal._currentCount < checklistGoal._times)
            {
                checklistGoal.MarkComplete();

                user._score += checklistGoal.GetPoints();

                Console.WriteLine($"You have completed the Checklist Goal: {selectedGoal.GetName()}.");

                if (checklistGoal._currentCount == checklistGoal._times)
                {
                    user._score += checklistGoal._bonusPoints;
                    Console.WriteLine($"Bonus Points awarded for completing the Checklist Goal: {checklistGoal._bonusPoints}.");
                }
            }

            else if (selectedGoal is EternalGoal)
            {
                user._score += selectedGoal.GetPoints();

                Console.WriteLine($"You are one step closer to your Eternal Goal: {selectedGoal.GetName()}.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select a valid goal.");
        }
    }

    static void ListGoals(User user)
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < user.GetEvents().Count; i++)
        {
            Event goal = user.GetEvents()[i];
            string status = goal.Completed ? "[X]" : "[ ]";
            string description = goal is ChecklistGoal ? $" -- Currently completed: {((ChecklistGoal)goal)._currentCount}/{((ChecklistGoal)goal)._times} times" : "";

            Console.WriteLine($"{i + 1}. {status} \"{goal.GetName()}\" (\"{goal.GetDescription()}\"){description}");
        }
    }

}