using System;
using System.Threading;

public class ListingActivity : BaseActivity
{
  public ListingActivity(int duration) : base(duration) { }

  protected override string GetActivityName()
  {
    return "Listing";
  }

  protected override void ShowPrompt(int index)
  {
    Console.WriteLine("Think of something: ");
    ShowAnimation();
  }
}
