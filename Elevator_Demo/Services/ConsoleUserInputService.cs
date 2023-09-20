using System;
using static UserInputService;

public class ConsoleUserInputService : IUserInputService
{
    public int ReadInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                // Parsing succeeded, return the integer value
                return value;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}
