using System;
using System.Threading;

public abstract class BaseActivity
{
  private int _duration;

  public BaseActivity(int duration)
  {
    _duration = duration;
  }

  public void StartActivity()
  {
    Console.WriteLine($"Prepare to begin {GetActivityName()} activity...");
    Thread.Sleep(3000);
    for (int i = 1; i <= _duration; i++)
    {
      ShowPrompt(i);
    }
    EndActivity();
  }

  protected abstract string GetActivityName();

  protected abstract void ShowPrompt(int index);

  private void EndActivity()
  {
    Console.WriteLine("You've done a good job!");
    Console.WriteLine($"You have completed the {GetActivityName()} activity in {_duration} seconds.");
    Thread.Sleep(3000);
  }

  protected void ShowAnimation()
  {
    Console.Write("Loading");
    for (int i = 0; i < 3; i++)
    {
      Thread.Sleep(1000);
      Console.Write(".");
    }
    Console.WriteLine();
  }
}
