using System;
using System.Threading;

public class ReflectionActivity : BaseActivity
{
  public ReflectionActivity(int duration) : base(duration) { }

  protected override string GetActivityName()
  {
    return "Reflection";
  }

  protected override void ShowPrompt(int index)
  {
    string[] prompts = new string[]
    {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
    };

    Random random = new Random();
    int randomIndex = random.Next(prompts.Length);
    Console.WriteLine(prompts[randomIndex]);
    ShowAnimation();
    Thread.Sleep(1000);
  }
}
