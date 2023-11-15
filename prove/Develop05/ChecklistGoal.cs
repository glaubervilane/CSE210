class ChecklistGoal : Event
{
    public int _times;
    public int _bonusPoints;
    public int _currentCount;

    public ChecklistGoal(string name, int points, int times, int bonusPoints, string description) : base(name, points, description)
    {
        _times = times;
        _bonusPoints = bonusPoints;
    }

    public override void MarkComplete()
    {
        if (!Completed)
        {
            _currentCount++;
            if (_currentCount >= _times)
            {
                Completed = true;
            }
        }
    }
}