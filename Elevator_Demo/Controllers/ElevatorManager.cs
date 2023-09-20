using System;
using System.Collections.Generic;

public class ElevatorManager
{
    private List<Elevator> elevators = new List<Elevator>(); // List to store instances of Elevator.

    public ElevatorManager(int numberOfElevators, int elevatorWeightLimit)
    {
        // Initialize the ElevatorManager with the specified number of elevators and elevator weight limit.
        for (int i = 0; i < numberOfElevators; i++)
        {
            string elevatorName = $"Elevator {i + 1}";
            elevators.Add(new Elevator(elevatorName, elevatorWeightLimit)); // Create and add elevator instances to the list.
        }
    }

    // Method to find the nearest available elevator to a specified floor.
    public Elevator FindNearestElevator(int floor)
    {
        Elevator nearestElevator = null; // Initialize the nearest elevator as null.
        int minDistance = int.MaxValue; // Initialize the minimum distance as a large value.

        // Iterate through all elevators to find the nearest one.
        foreach (var elevator in elevators)
        {
            int distance = Math.Abs(elevator.CurrentFloor - floor); // Calculate the distance between the elevator and the specified floor.

            // Check if the elevator is closer than the current nearest elevator and if it's either empty or stationary.
            if (distance < minDistance && (elevator.IsEmpty() || elevator.Direction == ElevatorDirection.Stationary))
            {
                nearestElevator = elevator;
                minDistance = distance;
            }
        }

        // If no elevator is available (all occupied), return the first elevator in the list as a fallback.
        return nearestElevator ?? elevators[0];
    }

    // Method to check if all elevators in the manager are idle (not moving and no pending destinations).
    public bool AllElevatorsAreIdle()
    {
        foreach (var elevator in elevators)
        {
            if (!elevator.IsIdle())
            {
                return false; // If any elevator is not idle, return false.
            }
        }
        return true; // If all elevators are idle, return true.
    }
}
