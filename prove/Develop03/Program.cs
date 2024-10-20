using System;
using System.Collections.Generic;
using System.Diagnostics;

/*
Enhancements:
1. Scripture library: Load multiple scriptures from a file for variety.
2. Game modes: Added random selection, user choice, and timed challenge.
3. Scoring system: Tracks user progress across different modes.
*/

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = Scripture.LoadFromFile("scriptures.txt");
        int score = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture Memorizer!");
            Console.WriteLine("1. Memorize a random scripture");
            Console.WriteLine("2. Choose a specific scripture");
            Console.WriteLine("3. Time challenge mode");
            Console.WriteLine("4. View score");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    score += MemorizeScripture(scriptures[new Random().Next(scriptures.Count)]);
                    break;
                case "2":
                    score += ChooseAndMemorizeScripture(scriptures);
                    break;
                case "3":
                    score += TimeChallenge(scriptures[new Random().Next(scriptures.Count)]);
                    break;
                case "4":
                    Console.WriteLine($"\nYour current score is: {score}");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Thank you for using the Scripture Memorizer. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static int MemorizeScripture(Scripture scripture)
    {
        int wordsHidden = 0;
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            int wordsToHide = new Random().Next(1, 4);  // Hide 1 to 3 words at a time
            scripture.HideRandomWords(wordsToHide);
            wordsHidden += wordsToHide;
        }
        return wordsHidden;
    }

    static int ChooseAndMemorizeScripture(List<Scripture> scriptures)
    {
        Console.WriteLine("\nAvailable scriptures:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayText()}");
        }
        Console.Write("Choose a scripture (1-" + scriptures.Count + "): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= scriptures.Count)
        {
            return MemorizeScripture(scriptures[choice - 1]);
        }
        Console.WriteLine("Invalid selection. Returning to main menu.");
        return 0;
    }

    static int TimeChallenge(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine("Time Challenge! You have 30 seconds to memorize the scripture.");
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress Enter when you're ready to begin...");
        Console.ReadLine();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.Clear();
        Console.WriteLine("Type out the complete scripture:");
        string userInput = Console.ReadLine();
        stopwatch.Stop();

        int timeTaken = (int)stopwatch.Elapsed.TotalSeconds;
        int score = 0;

        if (timeTaken <= 30)
        {
            if (userInput.Trim().Equals(scripture.GetFullText(), StringComparison.OrdinalIgnoreCase))
            {
                score = 100 + (30 - timeTaken) * 2;  // Bonus points for finishing early
                Console.WriteLine($"Excellent! Scripture correct. Score: {score}");
            }
            else
            {
                Console.WriteLine("Sorry, the scripture is not exactly correct. Keep practicing!");
            }
        }
        else
        {
            Console.WriteLine("Time's up! Keep practicing to improve your speed.");
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        return score;
    }
}