using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 21); // Generate a number between 1 and 20
        int guessCount = 0;

        Console.WriteLine("I'm thinking of a number between 1 and 20.");

        while (true)
        {
            Console.Write("Your guess: ");
            int guess = Convert.ToInt32(Console.ReadLine());
            guessCount++;

            if (guess == magicNumber)
            {
                Console.WriteLine($"You got it in {guessCount} guesses!");
                break;
            }
            
            Console.WriteLine(guess < magicNumber ? "Too low!" : "Too high!");
        }
    }
}