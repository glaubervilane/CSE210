public class ListingActivity : BaseActivity
{
    public ListingActivity(int duration) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration) { }

    protected override void ShowPrompt(int index)
    {
        Console.WriteLine("Think of something: ");
        ShowAnimation();
    }
    
    public List<string> ListItems()
    {
        List<string> items = new List<string>();
        Console.WriteLine("Enter items (one per line) and press Enter. Enter 'done' to finish.");
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (input.ToLower() == "done")
                break;
            items.Add(input);
        }
        return items;
    }
}