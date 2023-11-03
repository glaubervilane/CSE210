public class ReflectionActivity : BaseActivity
{
    private string[] _reflectionPrompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public ReflectionActivity(int duration) : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration) { }

    protected override void ShowPrompt(int index)
    {
        Random random = new Random();
        int randomIndex = random.Next(_reflectionPrompts.Length);
        Console.WriteLine(_reflectionPrompts[randomIndex]);
        ShowAnimation();
        Thread.Sleep(1000);
    }
}