using System;
using System.Collections.Generic;

// Enumeration representing elevator directions.
public enum ElevatorDirection
{
    Up,
    Down,
    Stationary
}

public class Elevator
{
    public string Name { get; private set; } // Unique identifier for the elevator.
    public int CurrentFloor { get; private set; } // The floor where the elevator is currently located.
    public ElevatorDirection Direction { get; private set; } // The direction in which the elevator is moving.
    public int WeightLimit { get; private set; } // The maximum weight (in KG) the elevator can carry.

    private int PeopleInside; // The current number of people inside the elevator.
    public bool IsMoving; // Indicates whether the elevator is currently in motion.
    private Queue<int> destinationQueue = new Queue<int>(); // Queue of destination floors for the elevator.

    public Elevator(string name, int weightLimit)
    {
        Name = name;
        CurrentFloor = 1; // The elevator starts on the first floor.
        Direction = ElevatorDirection.Stationary; // Initially, the elevator is stationary.
        WeightLimit = weightLimit;
        PeopleInside = 0;
        IsMoving = false;
    }

    public void MoveToFloor(int targetFloor)
    {
        if (targetFloor > CurrentFloor)
        {
            Direction = ElevatorDirection.Up;
        }
        else if (targetFloor < CurrentFloor)
        {
            Direction = ElevatorDirection.Down;
        }
        else
        {
            Direction = ElevatorDirection.Stationary;
            IsMoving = false;
            Console.WriteLine($"{Name} is already on floor {CurrentFloor}.");
            return;
        }

        IsMoving = true;
        Console.WriteLine($"{Name} moving from floor {CurrentFloor} to floor {targetFloor} (Direction: {Direction})");
        CurrentFloor = targetFloor;
        IsMoving = false;
        Console.WriteLine($"{Name} successfully reached floor {targetFloor}");
    }

    public bool LoadPassengers(int numberOfPeople, int totalWeight)
    {
        int potentialWeight = PeopleInside + totalWeight;

        if (potentialWeight <= WeightLimit)
        {
            PeopleInside = potentialWeight;
            Console.WriteLine($"{numberOfPeople} people loaded into {Name}. Current weight: {PeopleInside} Kg.");
            return true;
        }
        else
        {
            Console.WriteLine($"{Name} weight limit exceeded. Cannot load more people.");
            return false;
        }
    }

    public void UnloadPassengers(int destinationFloor)
    {
        while (destinationQueue.Count > 0 && destinationQueue.Peek() == destinationFloor)
        {
            if (PeopleInside > 0)
            {
                PeopleInside--;
            }
            destinationQueue.Dequeue();
            Console.WriteLine($"1 person offloaded on floor {destinationFloor} from Elevator {Name}. Current weight: {PeopleInside} Kg.");
        }
    }

    public void AddDestination(int destinationFloor)
    {
        destinationQueue.Enqueue(destinationFloor); // Add a destination floor to the queue.
    }

    public bool IsEmpty()
    {
        return PeopleInside == 0; // Check if the elevator is empty.
    }

    public bool IsIdle()
    {
        return !IsMoving && destinationQueue.Count == 0; // Check if the elevator is idle (not moving and no pending destinations).
    }
}
