class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Relaxation Activities Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity (1-4): ");

            string choice = Console.ReadLine();

            if (choice == "1" || choice == "2" || choice == "3")
            {
                Console.Write("Enter the duration in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                {
                    if (choice == "1")
                    {
                        BreathingActivity breathingActivity = new BreathingActivity(duration);
                        breathingActivity.StartActivity();
                    }
                    else if (choice == "2")
                    {
                        ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                        reflectionActivity.StartActivity();
                    }
                    else
                    {
                        ListingActivity listingActivity = new ListingActivity(duration);
                        List<string> items = listingActivity.ListItems();
                        Console.WriteLine($"You listed {items.Count} items.");
                        listingActivity.StartActivity();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid duration. Please enter a positive number.");
                    Thread.Sleep(2000);
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select an activity (1-4).");
                Thread.Sleep(2000);
            }
        }
    }
}