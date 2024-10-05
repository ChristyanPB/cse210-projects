using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            
            if (number == 0)
                break;
                
            numbers.Add(number);
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        double average = (double)sum / numbers.Count;

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
                max = number;
        }

        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
                smallestPositive = number;
        }

        List<int> sortedNumbers = new List<int>(numbers);
        for (int i = 0; i < sortedNumbers.Count - 1; i++)
        {
            for (int j = 0; j < sortedNumbers.Count - 1 - i; j++)
            {
                if (sortedNumbers[j] > sortedNumbers[j + 1])
                {
                    int temp = sortedNumbers[j];
                    sortedNumbers[j] = sortedNumbers[j + 1];
                    sortedNumbers[j + 1] = temp;
                }
            }
        }

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        
        Console.WriteLine("The sorted list is:");
        foreach (int number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }
}