using System;

public class BreathingActivity : BaseActivity
{
  public BreathingActivity(int duration) : base(duration) { }

  protected override string GetActivityName()
  {
    return "Breathing";
  }

  protected override void ShowPrompt(int index)
  {
    if (index % 2 == 1)
      Console.WriteLine("Breathe in...");
    else
      Console.WriteLine("Breathe out...");
    ShowAnimation();
    Thread.Sleep(1000);
  }
}
