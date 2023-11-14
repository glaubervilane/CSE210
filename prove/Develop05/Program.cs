class Program
{
    static void Main()
    {
        // Example usage of the classes
        BaseGoal simpleGoal = new SimpleGoal("Run a Marathon", "Run 26.2 miles in a single event", 1000);
        BaseGoal eternalGoal = new EternalGoal("Read Scriptures", "Read scriptures each day", 100, 10);
        BaseGoal checklistGoal = new ChecklistGoal("Attend the Temple", "Attend the temple 10 times", 50, 10);

        // Record events and mark completion
        simpleGoal.RecordEvent();
        ((SimpleGoal)simpleGoal).MarkComplete();
        eternalGoal.RecordEvent();
        checklistGoal.RecordEvent();
        checklistGoal.RecordEvent();

        // List and display goals
        List<BaseGoal> goals = new List<BaseGoal> { simpleGoal, eternalGoal, checklistGoal };
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - Completed: {goal.GetCompletion()}, Points: {goal.CalculateTotalAmountPoints()}");
        }

        // Save and load goals using the BaseGoal methods
        foreach (var goal in goals)
        {
            goal.SaveGoals();
            goal.LoadGoals();
        }
    }
}