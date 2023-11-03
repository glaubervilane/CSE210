public class ListingActivity : BaseActivity
{
    public ListingActivity(int duration) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration) { }

    protected override void ShowPrompt(int index)
    {
        Console.WriteLine("Think of something: ");
        ShowAnimation();
    }
}