using System;
using System.Collections.Generic;

public class Building
{
    private List<int> peopleWaiting = new List<int>(); // Keeps track of the number of people waiting on each floor.
    private List<Queue<int>> elevatorQueues = new List<Queue<int>>(); // Maintains queues of destination floors for each elevator.
    private ElevatorManager elevatorManager; // Manages the elevators in the building.

    // Constructor initializes the building with the specified number of floors, elevators, and elevator weight limit.
    public Building(int numberOfFloors, int numberOfElevators, int elevatorWeightLimit)
    {
        // Initialize the elevator manager with the specified number of elevators and weight limit.
        elevatorManager = new ElevatorManager(numberOfElevators, elevatorWeightLimit);

        // Initialize lists for tracking people waiting on each floor and elevator queues.
        for (int i = 0; i < numberOfFloors; i++)
        {
            peopleWaiting.Add(0); // Initially, no one is waiting on any floor.
            elevatorQueues.Add(new Queue<int>()); // Initialize empty destination queues for each elevator.
        }
    }

    // Method to call an elevator to a specified floor.
    public void CallElevator(int floor)
    {
        // Find the nearest available elevator to the specified floor.
        Elevator nearestElevator = elevatorManager.FindNearestElevator(floor);

        Console.WriteLine($"Elevator called to floor {floor}");

        nearestElevator.IsMoving = true;
        nearestElevator.MoveToFloor(floor);

        Console.Write("Enter the number of people inside the elevator: ");
        int numberOfPeople = int.Parse(Console.ReadLine());

        int totalWeight = 0;

        // For each passenger, specify their destination floor and weight, and load them into the elevator.
        for (int i = 0; i < numberOfPeople; i++)
        {
            Console.Write($"Enter the destination floor for passenger {i + 1}: ");
            int destinationFloor = int.Parse(Console.ReadLine());
            nearestElevator.AddDestination(destinationFloor);

            Console.Write($"Enter the weight of passenger {i + 1} (in Kg): ");
            int passengerWeight = int.Parse(Console.ReadLine());
            totalWeight += passengerWeight;
        }

        // Load passengers into the elevator and track their total weight.
        nearestElevator.LoadPassengers(numberOfPeople, totalWeight);

        // Unload passengers from the elevator at the specified floor.
        UnloadPassengers(nearestElevator, floor);
    }

    // Method to set the number of people waiting on a specific floor.
    public void SetPeopleWaiting(int floor, int numberOfPeople)
    {
        peopleWaiting[floor - 1] = numberOfPeople; // Update the count of people waiting on the specified floor.
        Console.WriteLine($"{numberOfPeople} people are now waiting on floor {floor}");
    }

    // Method to unload passengers from the elevator at a specified floor.
    private void UnloadPassengers(Elevator elevator, int floor)
    {
        elevator.UnloadPassengers(floor); // Unload passengers at the specified floor.
        peopleWaiting[floor - 1] = 0; // Reset the count of people waiting on that floor.
    }
}
