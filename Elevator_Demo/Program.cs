using static UserInputService;

class Program
{
    static void Main(string[] args)
    {
        var userInputService = new ConsoleUserInputService();

        // Prompt the user to enter essential building and elevator parameters.
        int numberOfFloors = ReadInteger(userInputService, "Enter the number of floors in the building: ", minValue: 1, maxValue: 100);
        int numberOfElevators = ReadInteger(userInputService, "Enter the number of elevators in the building: ", minValue: 1, maxValue: 10);
        int elevatorWeightLimit = ReadInteger(userInputService, "Enter the weight limit for each elevator (in Kg): ", minValue: 100, maxValue: 10000);

        // Create an instance of the ElevatorSystemService with the provided parameters and user input/output services.
        var elevatorSystem = new ElevatorSystemService(
            numberOfFloors,
            numberOfElevators,
            elevatorWeightLimit,
            new ConsoleUserOutputService(),
            userInputService
        );

        // Start the elevator simulation system.
        elevatorSystem.Run();
    }

    // Helper method to read an integer from the user input service with validation.
    static int ReadInteger(IUserInputService userInputService, string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        while (true)
        {
            int value = userInputService.ReadInteger(prompt);

            if (value >= minValue && value <= maxValue)
            {
                return value;
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter an integer between {minValue} and {maxValue}.");
            }
        }
    }
}
