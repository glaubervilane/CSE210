using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");

        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        string formattedName = $"{lastName}, {firstName} {lastName}";

        Console.WriteLine($"Your name is {formattedName}.");
    }
}