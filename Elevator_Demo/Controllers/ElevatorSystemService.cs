using static UserInputService;
using static UserOutputService;

public class ElevatorSystemService
{
    private Building building;
    private IUserOutputService userOutputService;
    private IUserInputService userInputService;

    public ElevatorSystemService(int numberOfFloors, int numberOfElevators, int elevatorWeightLimit, IUserOutputService userOutputService, IUserInputService userInputService)
    {
        // Initialize the elevator system with the provided parameters and services.
        this.userOutputService = userOutputService;
        this.userInputService = userInputService;

        // Create a new building for the elevator system.
        building = new Building(numberOfFloors, numberOfElevators, elevatorWeightLimit);
    }

    public void Run()
    {
        // Display an initial message for the elevator simulation.
        userOutputService.DisplayMessage("Elevator Simulation:");

        while (true)
        {
            // Display a menu for user interaction.
            userOutputService.DisplayMessage("1. Call Elevator");
            userOutputService.DisplayMessage("2. Set People Waiting");
            userOutputService.DisplayMessage("3. Quit");

            // Read the user's choice.
            int choice = userInputService.ReadInteger("Select an option: ");

            // Process the user's choice.
            switch (choice)
            {
                case 1:
                    // Call the elevator based on user input.
                    CallElevator();
                    break;

                case 2:
                    // Set the number of people waiting on a floor based on user input.
                    SetPeopleWaiting();
                    break;

                case 3:
                    // Exit the elevator simulation gracefully.
                    Environment.Exit(0);
                    break;

                default:
                    // Handle invalid choices by displaying an error message.
                    userOutputService.DisplayMessage("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    private void CallElevator()
    {
        // Prompt the user to enter the floor where they want to call the elevator.
        int floorToCall = userInputService.ReadInteger("Enter the floor to call the elevator: ");

        // Call the elevator from the building to the specified floor.
        building.CallElevator(floorToCall);
    }

    private void SetPeopleWaiting()
    {
        // Prompt the user to enter the floor and the number of people waiting.
        int waitingFloor = userInputService.ReadInteger("Enter the floor where people are waiting: ");
        int numberOfPeople = userInputService.ReadInteger("Enter the number of people waiting: ");

        // Set the number of people waiting on the specified floor in the building.
        building.SetPeopleWaiting(waitingFloor, numberOfPeople);
    }
}
