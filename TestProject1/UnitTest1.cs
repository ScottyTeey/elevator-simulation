using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using NUnit.Framework;

namespace Elevator_Demo
{

    [TestFixture]
    public class ElevatorManagerTests
    {
        [Test]
        public void FindNearestElevator_Should_Return_Nearest_Elevator()
        {
            // Arrange
            int numberOfElevators = 3;
            int elevatorWeightLimit = 1000;
            var elevatorManager = new ElevatorManager(numberOfElevators, elevatorWeightLimit);
            Elevator elevator1 = elevatorManager.FindNearestElevator(3);
            Elevator elevator2 = elevatorManager.FindNearestElevator(5);

            // Act
            Elevator nearestElevator = elevatorManager.FindNearestElevator(4);

            // Assert
            Assert.IsNotNull(nearestElevator);
            Assert.That(nearestElevator, Is.EqualTo(elevator1).Or.EqualTo(elevator2));
        }

        [Test]
        public void AllElevatorsAreIdle_Should_Return_True_When_All_Elevators_Idle()
        {
            // Arrange
            int numberOfElevators = 2;
            int elevatorWeightLimit = 1000;
            var elevatorManager = new ElevatorManager(numberOfElevators, elevatorWeightLimit);

            // Act & Assert
            Assert.IsTrue(elevatorManager.AllElevatorsAreIdle());
        }

        [Test]
        public void AllElevatorsAreIdle_Should_Return_False_When_At_Least_One_Elevator_Is_Not_Idle()
        {
            // Arrange
            int numberOfElevators = 2;
            int elevatorWeightLimit = 1000;
            var elevatorManager = new ElevatorManager(numberOfElevators, elevatorWeightLimit);
            elevatorManager.FindNearestElevator(3).AddDestination(2); // Simulate elevator movement

            // Act & Assert
            Assert.IsFalse(elevatorManager.AllElevatorsAreIdle());
        }

        // Add more test methods for ElevatorManager, Elevator, and Building as needed.
    }


}